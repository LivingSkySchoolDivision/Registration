using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public abstract class RegistrationFormSubmission : IGUIDable
    {
        public Guid Id { get; set; }
        public FormSubmitter SubmittedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
        public SelectedSchool School { get; set; }
        public WorkflowTracking OfficeUseOnly { get; set; }
    }
}
