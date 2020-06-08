using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class SchoolPreferenceList : IValidatableObject
    {
        public SelectedSchool FirstChoice { get; set; }
        public SelectedSchool SecondChoice { get; set; }
        public SelectedSchool ThirdChoice { get; set; }

        public bool IsFull()
        {
            return (
                (FirstChoice != null) &&
                (SecondChoice != null) &&
                (ThirdChoice != null)
                );
        }

        public bool IsEmpty()
        {
            return (
                (FirstChoice == null) &&
                (SecondChoice == null) &&
                (ThirdChoice == null)
                );
        }

        public void AddSchool(School school)
        {
            if (school != null)
            {
                // Check if the school is already added
                if (FirstChoice != null)
                {
                    if (FirstChoice.DAN == school.DAN)
                    {
                        return;
                    }
                }
                if (SecondChoice != null)
                {
                    if (SecondChoice.DAN == school.DAN)
                    {
                        return;
                    }
                }
                if (ThirdChoice != null)
                {
                    if (ThirdChoice.DAN == school.DAN)
                    {
                        return;
                    }
                }

                // Add in first available spot
                if (FirstChoice == null)
                {
                    FirstChoice = new SelectedSchool(school);
                } else if (SecondChoice == null)
                {
                    SecondChoice = new SelectedSchool(school);

                } else if (ThirdChoice == null)
                {
                    ThirdChoice = new SelectedSchool(school);
                }
                shiftUp();
            }
        }

        public void RemoveSchool(School School)
        {
            if (School != null)
            {
                RemoveSchool(School.DAN);
            }
        }

        public void RemoveSchool(SelectedSchool School)
        {
            if (School != null)
            {
                RemoveSchool(School.DAN);
            }
        }

        public void RemoveSchool(string DAN)
        {
            if (FirstChoice != null)
            {
                if (FirstChoice.DAN == DAN)
                {
                    FirstChoice = null;
                }
            }

            if (SecondChoice != null)
            {
                if (SecondChoice.DAN == DAN)
                {
                    SecondChoice = null;
                }
            }

            if (ThirdChoice != null)
            {
                if (ThirdChoice.DAN == DAN)
                {
                    ThirdChoice = null;
                }
            }
            shiftUp();            
        }

        private void shiftUp()
        {
            if ((SecondChoice == null) && (ThirdChoice != null))
            {
                SecondChoice = ThirdChoice;
                ThirdChoice = null;
            }

            if ((FirstChoice == null) && (SecondChoice != null))
            {
                FirstChoice = SecondChoice;
                SecondChoice = null;
            }

        }

        public bool ContainsDAN(string DAN)
        {
            return (
                FirstChoice?.DAN == DAN ||
                SecondChoice?.DAN == DAN || 
                ThirdChoice?.DAN == DAN
                );
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.IsEmpty())
            {
                errors.Add(new ValidationResult("Please select at least one school."));
            }

            return errors;
        }
    }
}
