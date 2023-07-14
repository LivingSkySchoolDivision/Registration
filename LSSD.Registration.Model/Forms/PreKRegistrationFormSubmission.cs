using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class PreKRegistrationFormSubmission : BaseFormSubmission
    {
        [Required]
        public SchoolPreferenceList SchoolPreferences { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public SiblingInfo Siblings { get; set; }
        [Required]
        public PreKInfo PreKInfo { get; set; }
        [Required]
        public ContactsInfo Contacts { get; set; }
        public StudentConsentInfo Consent { get; set; }
        public FirstNationsInfo FirstNationsInfo { get; set; }
    }
}
