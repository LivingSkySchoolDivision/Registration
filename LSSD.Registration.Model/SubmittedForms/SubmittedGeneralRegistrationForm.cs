using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public class SubmittedGeneralRegistrationForm : BaseSubmittedForm, IGUIDable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public GeneralRegistrationFormSubmission Form { get; set; }

        public SubmittedGeneralRegistrationForm(GeneralRegistrationFormSubmission Form, string IPAddress) : base(IPAddress)
        {
            this.Form = Form;
        }
    }
}
