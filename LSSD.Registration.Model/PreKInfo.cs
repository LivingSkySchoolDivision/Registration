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
        public bool ConsentToShareFromAgencies { get; set; }
        public DateTime ConsentGrantedDate { get; set; }
        public string Concerns { get; set; }

        public bool AssistanceFromKidsFirst { get; set; }
        public bool AssistanceFromEarlyChildhoodIntervention { get; set; }
        public bool AssistanceFromOccupationOrPhysicalTherapist { get; set; }
        public bool AssistanceFromChildhoodPsychologist { get; set; }
        public bool AssistanceFromPreSchoolOrDaycare { get; set; }
        public bool AssistanceFromLicensedChildCare { get; set; }
        public bool AssistanceFromAutismConsultant { get; set; }
        public bool AssistanceFromSpeechLangagePathologist { get; set; }
        public bool AssistanceFromSocialServices { get; set; }
        public bool AssistanceFromKinsmenChildDevCenter { get; set; }
        public bool AssistanceFromAboriginalHeadstart { get; set; }

        public PreKInfo()
        {
            this.LanguageSpokenAtHome = FormDefaults.Language;
        }

    }
}
