using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Extensions;
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
            returnMe.AddRange(assistanceColumn1(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("KidsFirst", PreKInfo.AssistanceFromKidsFirst),
                    new KeyValuePair<string, bool>("Early Childhood Intervention", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Occupational or Physical Therapist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Childhood Psychologist", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Pre-School or Daycare", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Licensed Child Care", PreKInfo.AssistanceFromKidsFirst),
                    new KeyValuePair<string, bool>("Autism Consultant", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Speech Language Pathologist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Social Services", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Kinsmen Child Dev Cntr", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Aboriginal Headstart", PreKInfo.AssistanceFromKidsFirst)
                }));
            return returnMe;                
        }

        private static IEnumerable<OpenXmlElement> assistanceColumn1(IEnumerable<KeyValuePair<string, bool>> items) {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            Table itemTable = new Table();

            foreach(KeyValuePair<string, bool> item in items) {
                itemTable.AppendChild(new TableRow(
                    new TableCell(
                        new Paragraph(
                            new Run(
                                new Text(item.Key)
                            )
                        )  {
                            ParagraphProperties = new ParagraphProperties() {
                                ParagraphStyleId = new ParagraphStyleId() {
                                    Val = "Field Label"
                                }
                            }
                        }
                    ),
                    new TableCell(
                        new Paragraph(
                            new Run(
                                new Text(item.Value.ToYesOrDash())
                            )
                        )  {
                            ParagraphProperties = new ParagraphProperties() {
                                ParagraphStyleId = new ParagraphStyleId() {
                                    Val = "Field Value"
                                }
                            }
                        }
                    )
                ));
            }

            sectionParts.Add(itemTable);
            return sectionParts;
        }

    }
}