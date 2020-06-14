using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Extensions;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class PreKInfoSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(PreKInfo PreKInfo)
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(1));
            
            sectionParts.Add(new Paragraph());

            sectionParts.Add(
                TableHelper.MakeTable(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("Single parent or frequent parent absence", PreKInfo.OnlyOneParentInHome),
                    new KeyValuePair<string, bool>("Lack of family support system", PreKInfo.NoFamilySupportSystem),
                    new KeyValuePair<string, bool>("Low income family in financial need", PreKInfo.LowIncomeFamily),
                    new KeyValuePair<string, bool>("Primary caregiver less than high school education", PreKInfo.PrimaryCaregiverLessThanHighSchoolEducation),
                    new KeyValuePair<string, bool>("Child lives with teen parent", PreKInfo.TeenParent),
                    new KeyValuePair<string, bool>("Child in foster care", PreKInfo.InFosterCare),
                    new KeyValuePair<string, bool>("Little opportunity to interact with other same age", PreKInfo.LittleOpportunityToInteractWithSameAge),
                    new KeyValuePair<string, bool>("Can use bathroom by self", PreKInfo.CanUseBathroomAlone),
                    new KeyValuePair<string, bool>("Bathroom training in progress", PreKInfo.PottyTrainingInProgress),
                })
            );

            sectionParts.Add(ColumnHelper.ColumnBreak());

            sectionParts.Add(
                TableHelper.MakeTable(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("Speech difficulties", PreKInfo.SpeechDifficulties),
                    new KeyValuePair<string, bool>("Language difficulties", PreKInfo.LanguageDifficulties),
                    new KeyValuePair<string, bool>("Gross Motor difficulties", PreKInfo.GrossMotorDifficulties),
                    new KeyValuePair<string, bool>("Fine Motor difficulties", PreKInfo.FineMotorDifficulties)
                })
            );
            sectionParts.Add(new Table(
                LSSDTableStyles.Borders(),
                LSSDTableStyles.Margins(),
                new TableRow(
                    new TableCell(
                        new TableCellProperties(
                            new GridSpan() { Val = 2 }
                        ),
                        ParagraphHelper.Paragraph("Other difficulties:", "Field Label"),
                        ParagraphHelper.Paragraph(PreKInfo.OtherDifficulties, "Field Value")
                    )
                )
            ));

            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(2, 200));

            sectionParts.Add(new Paragraph());
            
            sectionParts.Add(
                TableHelper.MakeTable(new List<KeyValuePair<string, string>>() {
                    new KeyValuePair<string, string>("Social, emotional, or behavior issues:", PreKInfo.SocialEmotionalOrBehaviourIssues),
                    new KeyValuePair<string, string>("Traumatic experience within or impacting the family/child:", PreKInfo.TraumaticExperiences),
                    new KeyValuePair<string, string>("Health care crisis impacting child or family:", PreKInfo.HealthcareCrisis),
                    new KeyValuePair<string, string>("Referred by agency or agencies:", PreKInfo.ReferredByOtherAgency),
                    new KeyValuePair<string, string>("Custody concerns:", PreKInfo.CustodyConcerns),
                    new KeyValuePair<string, string>("Medical concerns:", PreKInfo.MedicalConcerns),
                    new KeyValuePair<string, string>("Other concerns:", PreKInfo.OtherConcerns),
                })
            );

            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(1, 200));

            sectionParts.Add(ParagraphHelper.WhiteSpace());
            sectionParts.Add(ParagraphHelper.Paragraph("Child receives supports from the following:", "Field Label"));
          
            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(1, 200));

            sectionParts.Add(
                TableHelper.MakeTable(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("KidsFirst", PreKInfo.AssistanceFromKidsFirst),
                    new KeyValuePair<string, bool>("Early Childhood Intervention Program", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Occupational/Physical Therapist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Early Childhood Psychologist", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Pre-School/Daycare/Family Day Home", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Licensed Child Care", PreKInfo.AssistanceFromKidsFirst),
                    new KeyValuePair<string, bool>("Autism Consultant or Resource Center", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Speech/Language Pathologist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Social Services", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Kinsmen Child Development Center", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Aboriginal HeadStart", PreKInfo.AssistanceFromKidsFirst),
                    new KeyValuePair<string, bool>("Consent to share information with these agencies", PreKInfo.ConsentToShareFromAgencies)
                }));
            
            // Make this section have 2 columns            
            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(2, 200));
            return sectionParts;
        }

    }
}