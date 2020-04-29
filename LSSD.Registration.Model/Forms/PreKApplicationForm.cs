using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class PreKApplicationForm
    {
        public Student Applicant { get; set; }

        public string SocialIssues { get; set; }
        public bool HasSpeechIssues { get; set; }
        public bool HasLanguageIssues { get; set; }
        public bool HasGrossMotorIssues { get; set; }
        public bool HasFineMotorsIssues { get; set; }
        public string OtherDifficulties { get; set; }
        public bool OnlyOneParent { get; set; }
        public bool LackOfFamilySupportSystem { get; set; }
        public string TraumaticExperience { get; set; }
        public string HealthcareIssues { get; set; }
        public bool LowIncomeFamily { get; set; }
        public bool LowEducatedPrimaryCaregiver { get; set; }
        public bool TeenParent { get; set; }
        public bool FosterCare { get; set; }
        public bool LowOpportunityWithOthersOfSameAge { get; set; }
        public string ReferredByAgencies { get; set; }
        public bool CanUseBathroomOnOwn { get; set; }

        public bool AssistanceFromKidsFirst { get; set; }
        public bool AssistanceFromEarlychildhoodIntervention { get; set; }
        public bool AssistanceFromOccupationOrPhysicalTherapost { get; set; }
        public bool AssistanceFromEarlyChildhoodPsychologist { get; set; }
        public bool AssistanceFromLicensedChildCare { get; set; }
        public bool AssistanceFromAutismConsultant { get; set; }
        public bool AssistanceFromSpeechLanguagePathologist { get; set; }
        public bool AssistanceFromSocialServices { get; set; }
        public bool AssistanceFromKinsmenChildDevelopmentCenter { get; set; }
        public bool AssistanceFromAboriginalHeadstart { get; set; }

        public bool ConsentToShareInformationFromAssistanceAgencies { get; set; }
        public DateTime DateOfConsentToShareInformationFromAssistanceAgencies { get; set; }

        public string CustodyConcerns { get; set; }
        public string OtherConcerns { get; set; }


        public PreKApplicationForm()
        {
            this.Applicant = new Student();
        }
    }
}
