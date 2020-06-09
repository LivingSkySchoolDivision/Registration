using System;
using System.Collections.Generic;
using LSSD.Registration.Model.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Sibling
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
