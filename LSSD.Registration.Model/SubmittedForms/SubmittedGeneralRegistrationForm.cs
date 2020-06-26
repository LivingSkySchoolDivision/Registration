using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public class SubmittedGeneralRegistrationForm : BaseSubmittedForm, IGUIDable, ISubmittedForm, INotifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public GeneralRegistrationFormSubmission Form { get; set; }

        public SubmittedGeneralRegistrationForm(GeneralRegistrationFormSubmission Form)
        {
            this.Form = Form;
        }

        public IEnumerable<SelectedSchool> GetNotifySchools()
        {
            List<SelectedSchool> schools = new List<SelectedSchool>();
            if (Form != null) {
                if (Form.School != null) {
                    schools.Add(Form.School);
                }
            }
            return schools;
        }
    }
}
