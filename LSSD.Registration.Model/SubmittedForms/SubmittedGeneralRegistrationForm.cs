using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public class SubmittedGeneralRegistrationForm : BaseSubmittedForm, IGUIDable, ISubmittedForm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public GeneralRegistrationFormSubmission Form { get; set; }

        public SubmittedGeneralRegistrationForm(GeneralRegistrationFormSubmission Form)
        {
            this.Form = Form;
        }
    }
}
