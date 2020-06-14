using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class PreKInfo
    {
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string SocialEmotionalOrBehaviourIssues { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string ReferredByOtherAgency { get; set; }
        public bool SpeechDifficulties { get; set; }
        public bool LanguageDifficulties { get; set; }
        public bool GrossMotorDifficulties { get; set; }
        public bool FineMotorDifficulties { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string OtherDifficulties { get; set; }
        public bool OnlyOneParentInHome { get; set; }
        public bool NoFamilySupportSystem { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string TraumaticExperiences { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string HealthcareCrisis { get; set; }
        public bool LowIncomeFamily { get; set; }
        public bool PrimaryCaregiverLessThanHighSchoolEducation { get; set; }
        public bool TeenParent { get; set; }
        public bool InFosterCare { get; set; }
        public bool LittleOpportunityToInteractWithSameAge { get; set; }
        public bool CanUseBathroomAlone { get; set; }
        public bool PottyTrainingInProgress { get; set; }
        public bool ConsentToShareFromAgencies { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string OtherConcerns { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string CustodyConcerns { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string MedicalConcerns { get; set; }

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
    }
}
