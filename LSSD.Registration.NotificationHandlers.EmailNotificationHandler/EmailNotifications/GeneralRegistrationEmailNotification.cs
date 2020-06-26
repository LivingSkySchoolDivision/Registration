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