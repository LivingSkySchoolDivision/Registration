using System;
using System.Collections.Generic;
using LSSD.Registration.Model.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Sibling
    {
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string FirstName { get; set; }
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LastName { get; set; }
        [MaxLength(200, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string SchoolAttending { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Sibling()
        {
        }

        public bool IsEmpty()
        {
            if (
                string.IsNullOrEmpty(this.FirstName) &&
                string.IsNullOrEmpty(this.LastName) &&
                string.IsNullOrEmpty(SchoolAttending) &&
                this.DateOfBirth == null
                )
            {
                return true;
            }
            return false;
        }
    }
}
