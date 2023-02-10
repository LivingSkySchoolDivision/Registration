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
        [BirthdayValidator(MinimumAge = 2, MaximumAge = 21)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public Address PrimaryAddress { get; set; }
        [Required]
        public Address MailingAddress { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LandDescription { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string PreviousSchools { get; set; }        
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string MedicalNotes { get; set; }
        public string CellPhone { get;set; }

        public Student()
        {
            this.PrimaryAddress = new Address();
            this.MailingAddress = new Address();
        }

        public string GetLegalName() {
            if (!string.IsNullOrEmpty(this.LegalMiddleName)) {
                return $"{this.LegalFirstName} {this.LegalMiddleName} {this.LegalLastName}";
            } else {
                return $"{this.LegalFirstName} {this.LegalLastName}";
            } 
        }

        public string GetPreferredName() {
            if (this.HasPreferredName) {
                if (!string.IsNullOrEmpty(this.MiddleName)) {
                    return $"{this.FirstName} {this.MiddleName} {this.LastName}";
                } else {
                    return $"{this.FirstName} {this.LastName}";
                } 
            } else { 
                if (!string.IsNullOrEmpty(this.LegalMiddleName)) {
                    return $"{this.LegalFirstName} {this.LegalMiddleName} {this.LegalLastName}";
                } else {
                    return $"{this.LegalFirstName} {this.LegalLastName}";
                } 
            }
        }


        public int GetAge()
        {
            if (this.DateOfBirth.HasValue) {
                return GetAge(DateTime.Today);
            } else {
                return 0;
            }
        }

        public int GetAge(DateTime OnThisDate)
        {
            if (this.DateOfBirth.HasValue) {
                int age = OnThisDate.Year - this.DateOfBirth.Value.Year;
                // The above age includes the year they're currently working on
                // But, in Canada anyway, that doesn't count until your birthday
                // So remove one, unless it's their birthday
                if (this.DateOfBirth > OnThisDate.AddYears(-age)) age--;
                return age;
            } else {
                return 0;
            }
        }

        public string GetDateOfBirthWithAge(DateTime OnThisDate) {
            if (this.DateOfBirth.HasValue) {
                return $"{this.DateOfBirth.Value.ToLongDateString()} (age: {GetAge(OnThisDate)})";
            } else {
                return "No DOB submitted";
            }
        }

        public string GetDateOfBirthWithAge() {
            if (this.DateOfBirth.HasValue) {
                return GetDateOfBirthWithAge(DateTime.Today);
            } else {
                return "No DOB submitted";
            }
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
