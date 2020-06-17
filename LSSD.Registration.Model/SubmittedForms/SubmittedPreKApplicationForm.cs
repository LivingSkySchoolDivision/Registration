using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public class SubmittedPreKApplicationForm : BaseSubmittedForm, IGUIDable, ISubmittedForm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PreKRegistrationFormSubmission Form { get; set; }

        public SubmittedPreKApplicationForm(PreKRegistrationFormSubmission Form)
        {
            this.Form = Form;
        }
    }
}
