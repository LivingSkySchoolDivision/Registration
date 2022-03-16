using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class StudentConsentInfo : IValidatableObject
    {
        public bool ShareWithSchoolDivision { get; set; }       
        public bool ShareWithMedia { get; set; }     
        public bool UnderstandsLimitedBySchool { get; set; }           
        public bool UnderstandsCanBeRevoked { get; set; }        
        public bool GaveConsentVoluntarily { get; set; }
        public bool UnderstandsGivenAnswers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.UnderstandsLimitedBySchool != true) {
                errors.Add(new ValidationResult("This field is mandatory", new[] { nameof(UnderstandsLimitedBySchool) }));
            }

            if (this.UnderstandsCanBeRevoked != true) {
                errors.Add(new ValidationResult("This field is mandatory", new[] { nameof(UnderstandsCanBeRevoked) }));
            }

            if (this.GaveConsentVoluntarily != true) {
                errors.Add(new ValidationResult("This field is mandatory", new[] { nameof(GaveConsentVoluntarily) }));
            }

            if (this.UnderstandsGivenAnswers != true) {
                errors.Add(new ValidationResult("This field is mandatory", new[] { nameof(UnderstandsGivenAnswers) }));
            }

            return errors;
        }
    }
}
