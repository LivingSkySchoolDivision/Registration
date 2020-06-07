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

        public static SelectedSchool FromSchool(School school)
        {
            if (school != null)
            {
                return new SelectedSchool()
                {
                    DAN = school.DAN,
                    Name = school.Name
                };
            } else
            {
                return new SelectedSchool();
            }
        }
    }
}
