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
            //returnMe.Add(new SectionProperties());

            // Normalize columns (I think)
            returnMe.Add(
                new Paragraph(
                    new ParagraphProperties(
                        new SectionProperties(
                            new Columns() {
                                ColumnCount = 1,
                                Space = "708"
                            },
                            new DocGrid() {
                                LinePitch = 360
                            },
                            new SectionType() {
                                Val = SectionMarkValues.Continuous
                            }
                        )
                    )                    
                )
            );

            // Mark the start of a section by making a paragraph, I think
            returnMe.Add(
                new Paragraph()
            );

            // Add left table
            returnMe.AddRange(
                assistanceColumn1(new List<KeyValuePair<string, bool>>() {
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
                assistanceColumn1(new List<KeyValuePair<string, bool>>() {
                    new KeyValuePair<string, bool>("Autism Consultant", PreKInfo.AssistanceFromEarlyChildhoodIntervention),
                    new KeyValuePair<string, bool>("Speech Language Pathologist", PreKInfo.AssistanceFromOccupationOrPhysicalTherapist),
                    new KeyValuePair<string, bool>("Social Services", PreKInfo.AssistanceFromChildhoodPsychologist),
                    new KeyValuePair<string, bool>("Kinsmen Child Dev Cntr", PreKInfo.AssistanceFromPreSchoolOrDaycare),
                    new KeyValuePair<string, bool>("Aboriginal Headstart", PreKInfo.AssistanceFromKidsFirst)
                }));
            
            // Make this section have 2 columns
            returnMe.Add(
                new Paragraph(
                    new  ParagraphProperties(
                        new SectionProperties(
                            new Columns() { Space = "284", ColumnCount = 2 }, 
                            new DocGrid() { LinePitch = 360 }, 
                            new SectionType { Val = SectionMarkValues.Continuous }
                        )
                    )
                )
            );

/*
            returnMe.Add(
                
            );
*/
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