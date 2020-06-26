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
            
            sectionParts.Add(
                TableHelper.StyledTable(                    
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Little opportunity to interact with other same age:").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.LittleOpportunityToInteractWithSameAge).WithWidth(5),
                        TableHelper.LabelCell("Low income family in financial need:").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.LowIncomeFamily).WithWidth(5)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Single parent or frequent parent absence:"),
                        TableHelper.ValueCell(PreKInfo.OnlyOneParentInHome),
                        TableHelper.LabelCell("Lack of family support system:"),
                        TableHelper.ValueCell(PreKInfo.NoFamilySupportSystem)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Primary caregiver less than high school education:"),
                        TableHelper.ValueCell(PreKInfo.PrimaryCaregiverLessThanHighSchoolEducation),
                        TableHelper.LabelCell("Speech difficulties:"),
                        TableHelper.ValueCell(PreKInfo.SpeechDifficulties)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Child in foster care:"),
                        TableHelper.ValueCell(PreKInfo.InFosterCare),
                        TableHelper.LabelCell("Language difficulties:"),
                        TableHelper.ValueCell(PreKInfo.LanguageDifficulties)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Can use bathroom by self:"),
                        TableHelper.ValueCell(PreKInfo.CanUseBathroomAlone),
                        TableHelper.LabelCell("Fine Motor difficulties:"),
                        TableHelper.ValueCell(PreKInfo.FineMotorDifficulties)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Bathroom training in progress:"),
                        TableHelper.ValueCell(PreKInfo.PottyTrainingInProgress),
                        TableHelper.LabelCell("Gross Motor difficulties:"),
                        TableHelper.ValueCell(PreKInfo.GrossMotorDifficulties)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Child lives with teen parent:"),
                        TableHelper.ValueCell(PreKInfo.TeenParent),
                        TableHelper.LabelCell(""),
                        TableHelper.ValueCell("")
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Other difficulties:").WithColspan(4)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.ValueCell(PreKInfo.OtherDifficulties).WithColspan(4)
                    )
                )
            );          

            sectionParts.Add(ParagraphHelper.WhiteSpace());
            sectionParts.Add(ParagraphHelper.Paragraph("Child receives supports from the following:", LSSDDocumentStyles.SectionTitle));
          
            sectionParts.Add(
                TableHelper.StyledTable(
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("KidsFirst").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromKidsFirst).WithWidth(5),
                        TableHelper.LabelCell("Early Childhood Intervention Program:").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromEarlyChildhoodIntervention).WithWidth(5)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Occupational/Physical Therapist:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                        TableHelper.LabelCell("Early Childhood Psychologist:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromChildhoodPsychologist)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Pre-School/Daycare/Family Day Home:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromPreSchoolOrDaycare),
                        TableHelper.LabelCell("Licensed Child Care:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromKidsFirst)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Autism Consultant or Resource Center:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                        TableHelper.LabelCell("Speech/Language Pathologist:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromOccupationOrPhysicalTherapist)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Social Services:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromChildhoodPsychologist),
                        TableHelper.LabelCell("Kinsmen Child Development Center:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromPreSchoolOrDaycare)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Aboriginal HeadStart:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromKidsFirst),
                        TableHelper.LabelCell("Consent to share information with these agencies:"),
                        TableHelper.ValueCell(PreKInfo.ConsentToShareFromAgencies)
                    )
                    
                )
            );
            
            sectionParts.Add(ParagraphHelper.PageBreak());

            sectionParts.Add(
                TableHelper.StyledTable(
                    TableHelper.FieldTableRow("Social, emotional, or behavior issues:", PreKInfo.SocialEmotionalOrBehaviourIssues, JustificationValues.Left, 33),
                    TableHelper.FieldTableRow("Traumatic experience within or impacting the family/child:", PreKInfo.TraumaticExperiences, JustificationValues.Left, 33),
                    TableHelper.FieldTableRow("Health care crisis impacting child or family:", PreKInfo.HealthcareCrisis, JustificationValues.Left, 33),
                    TableHelper.FieldTableRow("Referred by agency or agencies:", PreKInfo.ReferredByOtherAgency, JustificationValues.Left, 33),
                    TableHelper.FieldTableRow("Custody concerns:", PreKInfo.CustodyConcerns, JustificationValues.Left, 33),
                    TableHelper.FieldTableRow("Medical concerns:", PreKInfo.MedicalConcerns, JustificationValues.Left, 33),
                    TableHelper.FieldTableRow("Other concerns:", PreKInfo.OtherConcerns, JustificationValues.Left, 33)                    
                )
            );

            sectionParts.Add(ParagraphHelper.WhiteSpace());

            return sectionParts;
        }

    }
}