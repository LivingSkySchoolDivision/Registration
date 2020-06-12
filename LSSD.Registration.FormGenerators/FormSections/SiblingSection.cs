using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections 
{
    class SiblingSection 
    {
        public static IEnumerable<OpenXmlElement> GetSection(SiblingInfo Siblings) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (Siblings?.Siblings.Count > 0) {
                Table siblingTable = new Table(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "5000" }, // 100% of the page
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("Sibling Name")                                    
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
                                    new Text("Date of Birth")                                    
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
                                    new Text("School Attending")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Label"
                                    }
                                }
                            }
                        )
                    )
                );
                

                foreach(Sibling sibling in Siblings.Siblings) {
                    siblingTable.AppendChild(
                        new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"{sibling.LastName}, {sibling.FirstName}")                                    
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
                                    new Text(sibling.DateOfBirth != null ? sibling.DateOfBirth.GetValueOrDefault().ToLongDateString() : "(not submitted)")                                    
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
                                    new Text(sibling.SchoolAttending)                                    
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
                    );                    
                }

                sectionParts.Add(siblingTable);
            } else {
                sectionParts.Add(
                    new Paragraph(
                    new Run(
                        new Text("No sibling information entered")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Field Value"
                        }
                    }  
                }
                );
            }

            sectionParts.Add(
                new Paragraph()
            );


            return sectionParts;
        }
    }
}