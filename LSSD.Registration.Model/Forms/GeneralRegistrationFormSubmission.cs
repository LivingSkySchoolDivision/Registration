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
        public ContactsInfo Contacts { get; set; }
        public SiblingInfo Siblings { get; set; }
        public BussingInfo BussingInfo { get; set; }
        public FirstNationsInfo FirstNationsInfo { get; set; }
        public EALInfo EALInfo { get; set; }
        public EnrolmentInfo EnrollmentDetails { get; set; }
        public CitizenshipInfo Citizenship { get; set; }
    }
}
