using System;
using System.Collections.Generic;
using LSSD.Registration.Model.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Sibling
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolAttending { get; set; }
        [Required]
        [BirthdayValidator(MinimumAge = 3, MaximumAge = 21)]
        public DateTime DateOfBirth { get; set; }

        public Sibling()
        {
            this.DateOfBirth = DateTime.Today;
        }
    }
}
