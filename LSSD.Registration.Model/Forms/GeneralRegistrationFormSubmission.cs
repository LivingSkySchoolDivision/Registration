using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class GeneralRegistrationFormSubmission : RegistrationFormSubmission
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public Student Student { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Sibling> Siblings { get; set; }
        public BussingInfo BussingInfo { get; set; }
        public FirstNationsInfo FirstNationsInfo { get; set; }
        public EALInfo EALInfo { get; set; }
        public EnrollmentInfo EnrollmentInfo { get; set; }
    }
}
