using System;
using LSSD.Registration.FormGenerators;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.NotificationHandlers.EmailNotificationHandler
{
    public class GeneralRegistrationEmailNotification : IEmailNotification
    {

        SubmittedGeneralRegistrationForm _form;
        TimeZoneInfo _timeZone;
        FormFactory _factory;

        public GeneralRegistrationEmailNotification(SubmittedGeneralRegistrationForm Form, FormFactory Factory, TimeZoneInfo TimeZone)
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
                        <h3>Online Registration Form for " + _form.Form.Student.LegalFirstName + " " + _form.Form.Student.LegalLastName + @"</h3>
                        <p>Attached is a registration form for " + _form.Form.Student.LegalFirstName + " " + _form.Form.Student.LegalLastName + @", 
                        submitted " + _form.DateReceived(_timeZone).ToLongDateString() + " at " + _form.DateReceived(_timeZone).ToShortTimeString() + @". This form was submitted via the Living Sky SD Online Registration site (https://registration.lskysd.ca)</p> 
                        <p>This system has <b>not</b> automatically enrolled this student in SchoolLogic. It is the school's responsibility to validate this form and enrol the student, or to contact the form submitter for clarifications if necessary.</p>
                        <p>The online registration system is open to anyone on the Internet, and so it is possible to send fake or abusive registrations. If you believe the attached file to be fake or abusive, it is safe to delete and forget about. All forms have a unique ID associated with them, which is printed on the form itself - the form attached to this email has the ID: " + _form.Id + @". </p>
                        <p>If you have trouble opening this file, please create a Help Desk Ticket at https://helpdesk.lskysd.ca.</p>
                        <p>The attached file may contain private personal information - please consider this when forwarding this email message.</p>
                        <p>This is an automated email message. Replying to this email will create a Help Desk ticket.</p>
                        </body>
                        </html>"; 
            }
        }

        public string Subject {
            get {
                return $"Online Registration Form for {_form.Form.Student.LegalFirstName} {_form.Form.Student.LegalLastName}";
            }
        }

        public string FriendlyAttachmentName 
        {
            get {
                return $"K12REG-{FormFactory.SanitizeFilename(_form.Form.Student.LegalLastName.ToUpper())}-{FormFactory.SanitizeFilename(_form.Form.Student.LegalFirstName.ToUpper())}.docx";
            }
        }
    }
}