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
        [Required]
        public DateTime? DateOfBirth { get; set; }

        public Sibling()
        {
        }
    }
}
