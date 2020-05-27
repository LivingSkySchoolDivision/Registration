using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class GradeInfo
    {
        [Required]
        public string Grade { get; set; }
    }
}
