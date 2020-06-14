using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.FormGenerators.Common;

namespace LSSD.Registration.FormGenerators.FormSections 
{
    class SiblingSection 
    {
        private const string _defaultBorderColor = "C0C0C0";
        
        public static IEnumerable<OpenXmlElement> GetSection(SiblingInfo Siblings) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (Siblings?.Siblings.Count > 0) {
                Table siblingTable = new Table(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "5000" }, // 100% of the page
                    new TableCellMarginDefault(
                        new TopMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                        new LeftMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                        new BottomMargin() { Width = "25", Type = TableWidthUnitValues.Dxa },
                        new RightMargin() { Width = "100", Type = TableWidthUnitValues.Dxa }
                    ),
                    new TableBorders(
                        new TopBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 6,
                            Color = _defaultBorderColor
                        },
                        new BottomBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 6,
                            Color = _defaultBorderColor
                        },
                        new LeftBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 6,
                            Color = _defaultBorderColor
                        },
                        new RightBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 6,
                            Color = _defaultBorderColor
                        },
                        new InsideHorizontalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 6,
                            Color = _defaultBorderColor
                        },
                        new InsideVerticalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 6,
                            Color = _defaultBorderColor
                        }
                    ),
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("Sibling Name")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = LSSDDocumentStyles.FieldLabel
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
                                        Val = LSSDDocumentStyles.FieldLabel
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
                                        Val = LSSDDocumentStyles.FieldLabel
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
                                        Val = LSSDDocumentStyles.FieldValue
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
                                        Val = LSSDDocumentStyles.FieldValue
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
                                        Val = LSSDDocumentStyles.FieldValue
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
                            Val = LSSDDocumentStyles.FieldValue
                        }
                    }  
                }
                );
            }


            return sectionParts;
        }
    }
}