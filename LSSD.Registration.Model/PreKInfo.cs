using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class PreKInfo
    {
        public int Id { get; set; }

        public string LanguageSpokenAtHome { get; set; }
        public string SocialEmotionalOrBehaviorIssues { get; set; }
        public string ReferredByOtherAgency { get; set; }
        public bool SpeechDifficulties { get; set; }
        public bool LanguageDifficulties { get; set; }
        public bool GrossMotorDifficulties { get; set; }
        public bool FineMotorDifficulties { get; set; }
        public string OtherDifficulties { get; set; }
        public bool OnlyOneParentInHome { get; set; }
        public bool FrequentParentAbsence { get; set; }
        public bool NoFamilySupportSystem { get; set; }
        public string TraumaticExperiences { get; set; }
        public string HealthcareCrisis { get; set; }
        public bool LowIncomeFamily { get; set; }
        public bool PrimaryCaregiverLessThanHighSchoolEducation { get; set; }
        public bool TeenParent { get; set; }
        public bool InFosterCare { get; set; }
        public bool LittleOpportunityToInteractWithSameAge { get; set; }
        public bool CanUseBathroomAlone { get; set; }
        public bool PottyTrainingInProgress { get; set; }
        public List<StudentAssistanceProvider> AssistanceProviders { get; set; }
        public bool ConsentToShareInfoBetweenAssistanceProvidersAndSchool { get; set; }
        public DateTime ConsentGrantedDate { get; set; }
        public string Concerns { get; set; }

    }
}
