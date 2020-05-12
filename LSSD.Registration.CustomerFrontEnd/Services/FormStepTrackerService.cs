using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.CustomerFrontEnd.Services
{
    public class FormStepTrackerService
    {
        public event Action StepHasChanged;

        Dictionary<string, int> currentStepByFormName = new Dictionary<string, int>();

        private void flagChanged()
        {
            StepHasChanged?.Invoke();
        }

        public int Step(string FormName)
        {
            if (currentStepByFormName.ContainsKey(FormName))
            {
                return currentStepByFormName[FormName];
            }

            return 0;
        }

        public void SetStep(string FormName, int Num)
        {
            if (!currentStepByFormName.ContainsKey(FormName))
            {
                currentStepByFormName.Add(FormName, Num);
            } else
            {
                currentStepByFormName[FormName] = Num;
            }
        }

        public void NextStep(string FormName)
        {
            if (!currentStepByFormName.ContainsKey(FormName))
            {
                currentStepByFormName.Add(FormName,0);
            }

            currentStepByFormName[FormName]++;
            flagChanged();
        }

        public void PreviousStep(string FormName)
        {
            if (currentStepByFormName.ContainsKey(FormName))
            {
                currentStepByFormName[FormName]--;
                if (currentStepByFormName[FormName] < 0)
                {
                    currentStepByFormName[FormName] = 0;
                }
                flagChanged();
            }
        }
    }
}
