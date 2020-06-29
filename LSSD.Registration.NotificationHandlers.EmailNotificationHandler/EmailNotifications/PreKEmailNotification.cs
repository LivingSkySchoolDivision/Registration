using System;
using LSSD.Registration.FormGenerators;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.NotificationHandlers.EmailNotificationHandler
{
    public class PreKEmailNotification : IEmailNotification
    {

        SubmittedPreKApplicationForm _form;
        TimeZoneInfo _timeZone;
        FormFactory _factory;

        public PreKEmailNotification(SubmittedPreKApplicationForm Form, FormFactory Factory, TimeZoneInfo TimeZone)
        {
            this._form = Form;
            this._timeZone = TimeZone;
            this._factory = Factory;
        }

        public string AttachmentFilename {
            get {
                return _factory.GenerateForm(_form, _timeZone);                
            }
        }

        public string Body {
            get {
                return @"
                        <html>
                        <body>
                        <h3>Pre-K Application for " + _form.Form.Student.LegalFirstName + " " + _form.Form.Student.LegalLastName + @"</h3>
                        <p>Attached is a pre-kindergarten application for " + _form.Form.Student.LegalFirstName + " " + _form.Form.Student.LegalLastName + @", 
                        submitted " + _form.DateReceived(_timeZone).ToLongDateString() + " at " + _form.DateReceived(_timeZone).ToShortTimeString() + @"</p> 
                        <p>The online registration system is open to anyone on the Internet, and so it is possible to send fake or abusive registrations. If you believe the attached file to be fake or abusive, it is safe to delete and forget about. All forms have a unique ID associated with them, which is printed on the form itself - the form attached to this email has the ID: " + _form.Id + @". </p>
                        <p>If you have trouble opening this file, please create a Help Desk Ticket at https://helpdesk.lskysd.ca.</p>
                        <p>Note that parents may select up to three school choices, and all three schools are sent this email.</p>
                        <p>The attached file may contain private personal information - please consider this when forwarding this email message.</p>
                        <p>This is an automated email message. Replying to this email will create a Help Desk ticket.</p>
                        </body>
                        </html>"; 
            }
        }

        public string Subject {
            get {
                return $"Pre-K Application for {_form.Form.Student.LegalFirstName} {_form.Form.Student.LegalLastName}";
            }
        }

        public string FriendlyAttachmentName 
        {
            get {
                return $"PREK-{FormFactory.SanitizeFilename(_form.Form.Student.LegalLastName.ToUpper())}-{FormFactory.SanitizeFilename(_form.Form.Student.LegalFirstName.ToUpper())}.docx";
            }
        }
    }
}