using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public class SubmittedPreKApplicationForm : BaseSubmittedForm, IGUIDable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PreKRegistrationFormSubmission Form { get; set; }

        public SubmittedPreKApplicationForm(PreKRegistrationFormSubmission Form, string IPAddress) : base(IPAddress)
        {
            this.Form = Form;
        }

        public SubmittedPreKApplicationForm(PreKRegistrationFormSubmission Form) : base(string.Empty)
        {
            this.Form = Form;
        }
    }
}
