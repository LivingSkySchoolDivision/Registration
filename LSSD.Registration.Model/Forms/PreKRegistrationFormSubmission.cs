using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class PreKRegistrationFormSubmission : RegistrationFormSubmission
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public ContactsInfo Contacts { get; set; }
        public SiblingInfo Siblings { get; set; }
        public PreKInfo PreKInfo { get; set; }
        public BussingInfo BussingInfo { get; set; }
        public FirstNationsInfo FirstNationsInfo { get; set; }
        public EALInfo EALInfo { get; set; }
    }
}
