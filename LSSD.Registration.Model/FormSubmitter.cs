using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class FormSubmitter : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(PhoneNumber) && string.IsNullOrEmpty(EmailAddress))
            {
                errors.Add(new ValidationResult(
                    "Please provide either a phone number or valid email address", new[] { nameof(PhoneNumber), nameof(EmailAddress) }));
            }

            return errors;
        }
    }
}
