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
                        TableHelper.LabelCell("Attends childcare?").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.AttendsChildCare).WithWidth(5),   
                        TableHelper.LabelCell("")                 
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.ValueCell(PreKInfo.ChildCareProviderName).WithColspan(3)
                    )
                )
            );  
            
            sectionParts.Add(ParagraphHelper.WhiteSpace());

            sectionParts.Add(
                TableHelper.StyledTable(                    
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Little opportunity to interact with other same age:").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.LittleOpportunityToInteractWithSameAge).WithWidth(5),
                        TableHelper.LabelCell("Low income family in financial need:").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.LowIncomeFamily).WithWidth(5)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Only one parent in the home"),
                        TableHelper.ValueCell(PreKInfo.OnlyOneParentInHome),
                        TableHelper.LabelCell("Frequent parent absence"),
                        TableHelper.ValueCell(PreKInfo.FrequentParentAbsence)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Teen parent"),
                        TableHelper.ValueCell(PreKInfo.TeenParent),
                        TableHelper.LabelCell("English not first language"),
                        TableHelper.ValueCell(PreKInfo.EnglishAsAdditionalLanguage)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Lack of family support system:"),
                        TableHelper.ValueCell(PreKInfo.NoFamilySupportSystem),
                        TableHelper.LabelCell("Child in foster care:"),
                        TableHelper.ValueCell(PreKInfo.InFosterCare)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Primary caregiver less than high school education:"),
                        TableHelper.ValueCell(PreKInfo.PrimaryCaregiverLessThanHighSchoolEducation),
                        TableHelper.LabelCell("Speech or Language difficulties:"),
                        TableHelper.ValueCell(PreKInfo.SpeechOrLanguageDifficulties)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Motor control difficulties:"),
                        TableHelper.ValueCell(PreKInfo.MotorControlDifficulties),
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

            sectionParts.Add(
                TableHelper.StyledTable(
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Can use bathroom by self?").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.CanUseBathroomAlone).WithWidth(5), 
                        TableHelper.LabelCell("Bathroom training in progress?").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.CanUseBathroomAlone).WithWidth(5)                       
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.ValueCell(PreKInfo.BathroomTrainingDetails).WithColspan(4)
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
                        TableHelper.LabelCell("Early Childhood Intervention Program (ECIP):").WithWidth(40),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromEarlyChildhoodIntervention).WithWidth(5)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Occupational/Physical Therapist:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                        TableHelper.LabelCell("Early Childhood Psychologist:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromChildhoodPsychologist)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Autism Consultant:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromAutismConsultant),
                        TableHelper.LabelCell("Speech/Language Pathologist:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromSpeechLangagePathologist)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Social Services:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromSocialServices),
                        TableHelper.LabelCell("Kinsmen Child Development Center:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromKinsmenChildDevCenter)
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Aboriginal HeadStart:"),
                        TableHelper.ValueCell(PreKInfo.AssistanceFromAboriginalHeadstart),
                        TableHelper.LabelCell(""),
                        TableHelper.ValueCell("")
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