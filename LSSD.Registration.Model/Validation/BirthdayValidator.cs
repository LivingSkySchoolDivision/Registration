using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model.Validation
{
    class BirthdayValidator : ValidationAttribute
    {
        public int MinimumAge { get; set; } = 3;
        public int MaximumAge { get; set; } = 21;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.TryParse(value.ToString(), out DateTime birthdate))
            {
                if (birthdate.ToUniversalTime() > DateTime.Now.ToUniversalTime().AddYears(MinimumAge * -1))
                {
                    return new ValidationResult("Age must be at least " + MinimumAge, new[] { validationContext.MemberName });
                }

                if (birthdate.ToUniversalTime() < DateTime.Now.ToUniversalTime().AddYears(MaximumAge * -1))
                {
                    return new ValidationResult("Age cannot exceed " + MaximumAge, new[] { validationContext.MemberName });
                }

                return null;
            }

            return new ValidationResult("Unable to parse date", new[] { validationContext.MemberName });
        }

    }
}
