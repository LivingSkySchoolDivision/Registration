using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public class SubmittedPreKApplicationForm : BaseSubmittedForm, IGUIDable, ISubmittedForm, INotifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PreKRegistrationFormSubmission Form { get; set; }

        public SubmittedPreKApplicationForm(PreKRegistrationFormSubmission Form)
        {
            this.Form = Form;
        }

        public IEnumerable<SelectedSchool> GetNotifySchools()
        {
            List<SelectedSchool> schools = new List<SelectedSchool>();

            if (Form != null) 
            {
                if (Form.SchoolPreferences != null) 
                {
                    if (Form.SchoolPreferences.FirstChoice != null)
                    {
                        if (!schools.Contains(Form.SchoolPreferences.FirstChoice)) 
                        {
                            schools.Add(Form.SchoolPreferences.FirstChoice);
                        }
                    }
                    
                    if (Form.SchoolPreferences.SecondChoice != null)
                    {
                        if (!schools.Contains(Form.SchoolPreferences.SecondChoice)) 
                        {
                            schools.Add(Form.SchoolPreferences.SecondChoice);
                        }
                    }

                    if (Form.SchoolPreferences.ThirdChoice != null)
                    {
                        if (!schools.Contains(Form.SchoolPreferences.ThirdChoice)) 
                        {
                            schools.Add(Form.SchoolPreferences.ThirdChoice);
                        }
                    }
                }
            }

            return schools;
        }
    }
}
