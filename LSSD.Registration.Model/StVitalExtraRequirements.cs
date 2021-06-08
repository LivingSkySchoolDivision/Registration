using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class StVitalExtraRequirements : IValidatableObject
    {
        public bool AcknowledgesPolicy { get; set; }
        public bool ChildIsCatholic { get; set; }
        public bool CommitToBaptize { get; set; }
        public bool ShareInfoWithParish { get; set; }
        public bool AcknowledgeFailureState { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if ((ChildIsCatholic == false) && (CommitToBaptize == false)) 
            {
                 errors.Add(new ValidationResult(
                        "Child must be catholic to register at this school.", new[] { nameof(ChildIsCatholic), nameof(CommitToBaptize) }));
            }

            if ((AcknowledgesPolicy == false)) 
            {
                 errors.Add(new ValidationResult(
                        "You must acknowledge this policy to register at this school.", new[] { nameof(AcknowledgesPolicy) }));
            }

            if ((ShareInfoWithParish == false)) 
            {
                 errors.Add(new ValidationResult(
                        "You must acknowledge that your contact information will be shared.", new[] { nameof(ShareInfoWithParish) }));
            }

            if ((ChildIsCatholic == false) && (AcknowledgeFailureState == false)) 
            {
                 errors.Add(new ValidationResult(
                        "You must commit to this policy to register at this school.", new[] { nameof(AcknowledgeFailureState) }));
            }

            return errors;
        }
    }
}
