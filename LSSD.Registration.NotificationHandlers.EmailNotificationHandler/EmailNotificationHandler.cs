using LSSD.Registration.Model;
using LSSD.Registration.Model.Forms;
using LSSD.Registration.Model.SubmittedForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSSD.Registration.NotificationHandlers.EmailNotificationHandler
{
    public class EmailNotificationHandler : INotificationHandler
    {
        List<INotifiable> _backlog = new List<INotifiable>();
        Dictionary<string, string> _schoolEmailsByDAN = new Dictionary<string, string>();
       
        public EmailNotificationHandler(IEnumerable<School> SchoolList)
        {
                foreach(School school in SchoolList) {
                if (!_schoolEmailsByDAN.ContainsKey(school.DAN)) {
                    if (!string.IsNullOrEmpty(school.EmailAddress)) {
                        _schoolEmailsByDAN.Add(school.DAN, school.EmailAddress);
                    }
                }
            }
        }

        public void Handler(object sender, NotificationEventArgs e)
        {
            if (e.NotificationContext.GetType() == typeof(SubmittedPreKApplicationForm)) {
                Console.WriteLine("It's a prek form");
                SubmittedPreKApplicationForm form = (SubmittedPreKApplicationForm)e.NotificationContext;
                Console.WriteLine($" >> {form.Form.SubmittedBy.FirstName} {form.Form.SubmittedBy.LastName}");
                form.NotificationSent = true;
            }

            if (e.NotificationContext.GetType() == typeof(SubmittedGeneralRegistrationForm)) {
                Console.WriteLine("It's a general form");
                
                SubmittedPreKApplicationForm form = (SubmittedPreKApplicationForm)e.NotificationContext;
                
                form.NotificationSent = true;

                
            }
            
        } 
    }
}