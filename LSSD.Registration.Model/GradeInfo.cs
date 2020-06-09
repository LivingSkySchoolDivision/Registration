using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class GradeInfo
    {
        [Required]
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Grade { get; set; }
    }
}
