using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class FormSubmitter
    {
        [Required]
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string ContactDetails { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string RelationToStudent { get; set; }

        
    }
}
