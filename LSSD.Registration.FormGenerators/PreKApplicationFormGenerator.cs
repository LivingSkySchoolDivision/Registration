using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using LSSD.Registration.FormGenerators.Common;

namespace LSSD.Registration.FormGenerators {

    public class PreKApplicationFormGenerator {

        // For help with how to work with OpenXml documents:
        // https://docs.microsoft.com/en-us/office/open-xml/how-do-i

        public PreKApplicationFormGenerator(SubmittedPreKApplicationForm form) 
        {
            // Generate in a temp folder
            // Read the completed file into a stream of some sort
            // Deliver the file to the consumer of this generator
            // Delete the file
            // Don't do all this in the constructor
            Generate(form);
        }

        private IEnumerable<OpenXmlElement> GenerateAdministrativeSection(SubmittedPreKApplicationForm Form) {
            return new List<OpenXmlElement>() {                
                new Paragraph(
                    new Run(
                        new Text("LSSD Pre-Kindergarten Application Form")
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
                                    new Text("Application Received")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Label"
                                    }
                                }
                            }
                        ),
                        new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "1000" },                          
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"{Form.DateReceivedUTC.ToLocalTime().ToLongDateString()} {Form.DateReceivedUTC.ToLocalTime().ToShortTimeString()}")                                    
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

        private IEnumerable<OpenXmlElement> GenerateSchoolPreferenceList(SchoolPreferenceList SchoolPreferences) 
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
                    ),
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(((School)null)?.DAN)                                    
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
                                    new Text(SchoolPreferences?.SecondChoice.DAN)                                    
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
                                    new Text(SchoolPreferences?.SecondChoice.DAN)                                    
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

        private IEnumerable<OpenXmlElement> GenerateStudentDemographicSection(Student Student) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Student Information")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Section Title"
                        }
                    }  
                },
                new Paragraph()         
            };
        }

        private IEnumerable<OpenXmlElement> GenerateSiblingsSection(SiblingInfo Siblings) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Sibling Information")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Section Title"
                        }
                    }  
                },
                new Paragraph()          
            };
        }
        

        private IEnumerable<OpenXmlElement> GeneratePreKInfoSection(PreKInfo PreKInfo) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("PreK Information")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Section Title"
                        }
                    }  
                },
                new Paragraph()          
            };
        }

        private Document GenerateBody(SubmittedPreKApplicationForm Form) {

            List<OpenXmlElement> pageParts = new List<OpenXmlElement>();

            // First add the properties for the whole document
            pageParts.Add(
                new SectionProperties(
                        new PageMargin() {
                            Top = 720,
                            Bottom = 720,
                            Right = 720,
                            Left = 720
                        }
                    )
                );

            // Now add all the generated parts
            pageParts.AddRange(GenerateAdministrativeSection(Form)); 
            pageParts.AddRange(GenerateSchoolPreferenceList(Form.Form.SchoolPreferences)); 
            pageParts.AddRange(GenerateStudentDemographicSection(Form.Form.Student));           
            pageParts.AddRange(GenerateSiblingsSection(Form.Form.Siblings));
            pageParts.AddRange(GeneratePreKInfoSection(Form.Form.PreKInfo));
          
            return new Document(new Body(pageParts));
        }
        

        public void Generate(SubmittedPreKApplicationForm Form) 
        {
            string filename = Form.Id.ToString() + ".docx";

            if (File.Exists(filename)) {
                File.Delete(filename);
            }

            using (WordprocessingDocument document = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document)) { 
                // Create the main document part
                MainDocumentPart mainPart = document.AddMainDocumentPart();                
                LSSDDocumentStyles.AddStylesToDocument(document);
                mainPart.Document = GenerateBody(Form);
            }
        }


    }
}