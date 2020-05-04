using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public abstract class RegistrationFormSubmission
    {
        public FormSubmitter SubmittedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
        public School School { get; set; }
    }
}
