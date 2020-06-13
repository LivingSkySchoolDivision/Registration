using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class SchoolPreferencesSection 
    {        
        private const string _defaultBorderColor = "C0C0C0";

        public static IEnumerable<OpenXmlElement> GetSection(SchoolPreferenceList SchoolPreferences) 
        {
            return new List<OpenXmlElement>() {
                new Table(
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
                                    new Text("First school choice")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
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
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
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
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
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
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
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
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
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
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Value"
                                    }
                                }
                            }
                        )
                    )
                )
            };
        }
    }
}