using LSSD.Registration.Model.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Student : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LegalFirstName { get; set; }
        [Required]
        public string LegalLastName { get; set; }
        public string LegalMiddleName { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [BirthdayValidator(MinimumAge = 3, MaximumAge = 21)]
        public DateTime DateOfBirth { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address MailingAddress { get; set; }
        public string LandDescription { get; set; }
        public string PreviousSchools { get; set; }
        public string HealthServicesNumber { get; set; }
        public string MedicalNotes { get; set; }

        public Student()
        {
            this.PrimaryAddress = new Address();
            this.MailingAddress = new Address();
            this.DateOfBirth = DateTime.Today;
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
                    (string.IsNullOrEmpty(this.PrimaryAddress.Street)) 
                    && (string.IsNullOrEmpty(this.PrimaryAddress.HouseNumber))
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
                if (this.MailingAddress != null)
                {
                    if (
                        (string.IsNullOrEmpty(this.MailingAddress.Country))
                        && (string.IsNullOrEmpty(this.MailingAddress.Province))
                        && (string.IsNullOrEmpty(this.MailingAddress.City))
                        && (string.IsNullOrEmpty(this.MailingAddress.Street))
                        && (string.IsNullOrEmpty(this.MailingAddress.PostalCode))
                        )
                    {
                        errors.Add(new ValidationResult(
                        "Mailing address is required when providing land description.", new[] { nameof(MailingAddress) }));
                    }
                } else
                {
                    errors.Add(new ValidationResult(
                        "Mailing address is required when providing land description.", new[] { nameof(MailingAddress) }));
                }
            }


            return errors;
        }
    }
}
