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
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string RelationToStudent { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        [MinLength(4, ErrorMessage = "Invalid school year")]
        public string SchoolYearRegisteringFor { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        
    }
}
