using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class SchoolPreferencesSection {
        public static IEnumerable<OpenXmlElement> GetSection(SchoolPreferenceList SchoolPreferences) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("School Preferences")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Section Title"
                        }
                    }
                },
                new Table(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "5000" }, // 100% of the page
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("First school choice")                                    
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
                                    new Text("Second school choice")                                    
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
                                    new Text("Third school choice")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Label"
                                    }
                                }
                            }
                        )
                    ),
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(SchoolPreferences?.FirstChoice.Name)                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Value"
                                    }
                                }
                            }
                        ),                         
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(SchoolPreferences?.SecondChoice.Name)                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Value"
                                    }
                                }
                            }
                        ),
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(SchoolPreferences?.ThirdChoice.Name)                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Value"
                                    }
                                }
                            }
                        )
                    )
                ),
                new Paragraph()
            };
        }
    }
}