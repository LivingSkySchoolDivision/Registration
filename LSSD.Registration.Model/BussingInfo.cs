using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LSSD.Registration.Model
{
    public class BussingInfo : IValidatableObject
    {
        public bool RequiresBussing { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]

        public string LandDescription { get; set; }
        public bool UseLandDescription { get; set; }
        public Address BussingAddress { get; set; }

        public BussingInfo()
        {
            this.BussingAddress = new Address();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (this.RequiresBussing)
            {
                if ((!BussingAddress.IsValidCivic()) && (string.IsNullOrEmpty(LandDescription)))
                {
                    errors.Add(new ValidationResult(
                        "Please provide a civic address or land location.", new[] { nameof(BussingAddress), nameof(LandDescription) }));
                }

            }

            return errors;
        }
    }
}
