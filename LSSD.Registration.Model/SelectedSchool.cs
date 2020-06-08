using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class SelectedSchool
    {
        [Required]
        public string DAN { get; set; }
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
