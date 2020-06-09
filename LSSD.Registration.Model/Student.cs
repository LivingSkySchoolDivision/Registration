using LSSD.Registration.Model.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Student : IValidatableObject
    {
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LastName { get; set; }
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LegalFirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LegalLastName { get; set; }
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LegalMiddleName { get; set; }
        public bool HasPreferredName { get; set; }
        public bool HasLandLocation { get; set; }
        public bool MailingAddressSameAsPhysical { get; set; }
        [MaxLength(32, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Gender { get; set; }
        [Required]
        [BirthdayValidator(MinimumAge = 3, MaximumAge = 21)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public Address PrimaryAddress { get; set; }
        [Required]
        public Address MailingAddress { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LandDescription { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string PreviousSchools { get; set; }
        [MaxLength(25, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string HealthServicesNumber { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string MedicalNotes { get; set; }

        public Student()
        {
            this.PrimaryAddress = new Address();
            this.MailingAddress = new Address();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.PrimaryAddress != null)
            {
                if (string.IsNullOrEmpty(this.PrimaryAddress.Province))
                {
                    errors.Add(new ValidationResult(
                        "Please provide a province for the primary address.", new[] { nameof(PrimaryAddress) }));
                }

                if (string.IsNullOrEmpty(this.PrimaryAddress.Country))
                {
                    errors.Add(new ValidationResult(
                        "Please provide a country for the primary address.", new[] { nameof(PrimaryAddress) }));
                }

                if (string.IsNullOrEmpty(this.PrimaryAddress.City))
                {
                    errors.Add(new ValidationResult(
                        "Please provide a city for the primary address.", new[] { nameof(PrimaryAddress) }));
                }

                // Require a house & street _or_ a land location
                if (
                    (!this.PrimaryAddress.IsValidCivic())
                    && (string.IsNullOrEmpty(this.LandDescription))
                    )
                {
                    errors.Add(new ValidationResult(
                        "Please provide either a primary address or a land description of primary residence.", new[] { nameof(PrimaryAddress) }));
                }
            } else
            {
                errors.Add(new ValidationResult(
                    "Please provide a primary address.", new[] { nameof(PrimaryAddress) }));
            }

            if (!string.IsNullOrEmpty(this.LandDescription))
            {
                if ((this.MailingAddress == null) || (this.MailingAddress?.IsValidMailing() == false))
                {
                    errors.Add(new ValidationResult(
                        "Mailing address is required when providing land description.", new[] { nameof(MailingAddress) }));
                 }
            }

            if ((this.MailingAddress == null || (this.MailingAddress?.IsEmpty() == true)) && !this.MailingAddressSameAsPhysical)
            {
                errors.Add(new ValidationResult(
                    "Please enter a mailing address", new[] { nameof(MailingAddress) }));
            }


            return errors;
        }
    }
}
