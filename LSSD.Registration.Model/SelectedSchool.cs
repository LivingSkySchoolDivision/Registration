using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class SelectedSchool
    {
        [Required]
        [MaxLength(25, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string DAN { get; set; }
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Name { get; set; }

        public SelectedSchool(School School)
        {
            if (School != null)
            {
                DAN = School.DAN;
                Name = School.Name;
            }
        }

        public SelectedSchool() { }
    }
}
