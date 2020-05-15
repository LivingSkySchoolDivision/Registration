using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LSSD.Registration.Model
{
    public class BussingInfo : IValidatableObject
    {
        [Required]
        public bool RequiresBussing { get; set; }
        
        [Required]
        public bool WeighsMoreThan18kg { get; set; }
        public bool ReadAndUnderstandsRules { get; set; }
        public string LandDescription { get; set; }
        public bool UseLandDescription { get; set; }
        public Address BussingAddress { get; set; }
        public string Comments { get; set; }
        public bool AM { get; set; }
        public bool PM { get; set; }

        public BussingInfo()
        {
            this.BussingAddress = new Address();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (!this.ReadAndUnderstandsRules)
            {
                errors.Add(new ValidationResult(
                    "Please indicate that you have read and understand the rules to complete your bussing request.", new[] { nameof(ReadAndUnderstandsRules) }));
            }

            if ((!BussingAddress.IsValidCivic) && (string.IsNullOrEmpty(LandDescription)))
            {
                errors.Add(new ValidationResult(
                    "Please provide a civic address or land location.", new[] { nameof(BussingAddress), nameof(LandDescription) }));
            }

            if (!AM && !PM)
            {
                errors.Add(new ValidationResult(
                    "Please select a bussing service.", new[] { nameof(AM), nameof(PM) }));
            }

            return errors;
        }
    }
}
