using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class PreKRegistrationFormSubmission : RegistrationFormSubmission
    {
        public Student Student { get; set; }
        public SiblingInfo Siblings { get; set; }
        public PreKInfo PreKInfo { get; set; }
    }
}
