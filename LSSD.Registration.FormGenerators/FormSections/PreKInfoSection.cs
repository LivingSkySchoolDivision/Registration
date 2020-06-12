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

            sectionParts.AddRange(assistanceSection(PreKInfo));

            sectionParts.Add(new Paragraph());
            return sectionParts;
        }


        private static IEnumerable<OpenXmlElement> assistanceSection(PreKInfo PreKInfo)
        {
            List<OpenXmlElement> returnMe = new List<OpenXmlElement>();
            //returnMe.Add(new SectionProperties());

            returnMe.Add(ColumnHelper.SetPreviousSectionToColumns(1));
            returnMe.Add(ColumnHelper.MarkSectionStart());
               
            // Add left table
            returnMe.AddRange(
                BoolTable.MakeTable(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("KidsFirst", PreKInfo.AssistanceFromKidsFirst),
                    new KeyValuePair<string, bool>("Early Childhood Intervention", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Occupational or Physical Therapist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Childhood Psychologist", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Pre-School or Daycare", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Licensed Child Care", PreKInfo.AssistanceFromKidsFirst),
                }));

            // Add column break between the tables
            returnMe.Add(new Paragraph(new Run(new Break() { Type = BreakValues.Column })));

            // Add right table
            returnMe.AddRange(
                BoolTable.MakeTable(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("Autism Consultant", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Speech Language Pathologist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Social Services", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Kinsmen Child Dev Cntr", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Aboriginal Headstart", PreKInfo.AssistanceFromKidsFirst)
                }));
            
            // Make this section have 2 columns            
            returnMe.Add(ColumnHelper.SetPreviousSectionToColumns(2, 200));
            returnMe.Add(ColumnHelper.MarkSectionStart());
            return returnMe;                
        }

    }
}