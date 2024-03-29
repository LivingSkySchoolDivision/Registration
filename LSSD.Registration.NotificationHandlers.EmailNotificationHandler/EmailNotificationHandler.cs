using LSSD.Registration.FormGenerators;
using LSSD.Registration.Model;
using LSSD.Registration.Model.Forms;
using LSSD.Registration.Model.SubmittedForms;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LSSD.Registration.NotificationHandlers.EmailNotificationHandler
{
    public class EmailNotificationHandler : INotificationHandler
    {
        List<INotifiable> _backlog = new List<INotifiable>();
        SMTPConnectionDetails _smtpConnectionDetails = new SMTPConnectionDetails();
        Dictionary<string, string> _schoolEmailsByDAN = new Dictionary<string, string>();
        TimeZoneInfo _timeZone;

        public EmailNotificationHandler(SMTPConnectionDetails SMTPConnectionDetails, TimeZoneInfo TimeZone, IEnumerable<School> SchoolList)
        {
            this._timeZone = TimeZone;
            this._smtpConnectionDetails = SMTPConnectionDetails;
            foreach(School school in SchoolList)
            {
                if (!string.IsNullOrEmpty(school.DAN))
                {
                    if (!_schoolEmailsByDAN.ContainsKey(school.DAN))
                    {
                        // If we have a "notification" email, use that
                        // If we don't, use the general school email
                        if (!string.IsNullOrEmpty(school.NotificationEmailAddress))
                        {
                            _schoolEmailsByDAN.Add(school.DAN, school.NotificationEmailAddress);
                        } else if (!string.IsNullOrEmpty(school.EmailAddress))
                        {
                            _schoolEmailsByDAN.Add(school.DAN, school.EmailAddress);
                        }
                    }
                }
            }
        }

        public void Enqueue(object sender, NotificationEventArgs e)
        {
            _backlog.Add(e.NotificationContext);
        }

        public void Flush(object sender, EventArgs e)
        {
            // If there's no work to do, just stop here
            if (_backlog.Count <= 0)
            {
                return;
            }

            using (FormFactory factory = new FormFactory())
            {
                using (SmtpClient smtpClient = new SmtpClient(_smtpConnectionDetails.Host)
                {
                    Port = _smtpConnectionDetails.Port,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_smtpConnectionDetails.Username, _smtpConnectionDetails.Password)
                })
                {
                    foreach(INotifiable form in _backlog)
                    {
                        // Determine recipients of the message
                        List<string> recipients = new List<string>();
                        foreach(SelectedSchool selectedSchool in form.GetNotifySchools()) {
                            if (_schoolEmailsByDAN.ContainsKey(selectedSchool.DAN)) {
                                if (!recipients.Contains(_schoolEmailsByDAN[selectedSchool.DAN]))
                                {
                                    recipients.Add(_schoolEmailsByDAN[selectedSchool.DAN]);
                                }
                            }
                        }

                        if(recipients.Count == 0) {
                            Console.WriteLine("Unable to send email notification - no email recipients found for school");

                        } else {
                            // Handle the form based on what kind of form it is
                            IEmailNotification emailNotification = null;

                            if (form.GetType() == typeof(SubmittedPreKApplicationForm))
                            {
                                emailNotification = new PreKEmailNotification((SubmittedPreKApplicationForm)form, factory, _timeZone);
                            }

                            if (form.GetType() == typeof(SubmittedGeneralRegistrationForm))
                            {
                                emailNotification = new GeneralRegistrationEmailNotification((SubmittedGeneralRegistrationForm)form, factory, _timeZone);
                            }

                            if (emailNotification != null) {
                                MailMessage msg = new MailMessage();
                                foreach(string addr in recipients) {
                                    msg.To.Add(addr);
                                }

                                msg.Body = emailNotification.Body;
                                msg.Subject = emailNotification.Subject;
                                msg.From = new MailAddress(_smtpConnectionDetails.FromAddress, "LSSD Registration Site");
                                msg.ReplyToList.Add(new MailAddress(_smtpConnectionDetails.ReplyToAddress, "LSSD Registration Site"));
                                msg.IsBodyHtml = true;

                                try
                                {
                                    if (!string.IsNullOrEmpty(emailNotification.AttachmentFilename))
                                    {
                                        using (Attachment fileAttachment = new Attachment(emailNotification.AttachmentFilename) { Name = emailNotification.FriendlyAttachmentName }) {
                                            msg.Attachments.Add(fileAttachment);
                                            smtpClient.Send(msg);
                                        }
                                    } else {
                                        smtpClient.Send(msg);
                                    }

                                    form.NotificationSent = true;
                                }
                                catch(Exception ex) {
                                    //TODO: Log this better
                                    Console.WriteLine($"EXCEPTION: {ex.Message}");
                                }
                            }
                        }


                    }

                    // Empty the queue. Some may have failed, but they won't be marked as notified in the DB, so the next run will catch them.
                    // This prevents an SMTP outage from enqueuing the same email hundreds of times.
                    _backlog.Clear();
                }
            }

        }
    }
}