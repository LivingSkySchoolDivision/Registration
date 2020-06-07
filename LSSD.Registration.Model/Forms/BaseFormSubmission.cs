using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public abstract class BaseFormSubmission
    {
        [Required]
        public FormSubmitter SubmittedBy { get; set; }
    }
}
