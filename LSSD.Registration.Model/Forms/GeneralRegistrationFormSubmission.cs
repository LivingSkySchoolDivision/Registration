using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class GeneralRegistrationFormSubmission : BaseFormSubmission
    {
        [Required]
        public SelectedSchool School { get; set; }

        [Required]
        public GradeInfo Grade { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public ContactsInfo Contacts { get; set; }
        [Required]
        public SiblingInfo Siblings { get; set; }
        public BussingInfo BussingInfo { get; set; }
        [Required]
        public FirstNationsInfo FirstNationsInfo { get; set; }
        [Required]
        public EALInfo EALInfo { get; set; }
        [Required]
        public EnrolmentInfo EnrollmentDetails { get; set; }
        [Required]
        public CitizenshipInfo Citizenship { get; set; }
        public StVitalExtraRequirements StVitalExtraRequirements { get; set;}
    }
}
