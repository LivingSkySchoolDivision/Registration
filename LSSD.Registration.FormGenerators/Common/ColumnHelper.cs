using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace LSSD.Registration.FormGenerators.Common 
{
    public static class ColumnHelper 
    {
        public static OpenXmlElement SetPreviousSectionToColumns(int ColumnCount) {
            return SetPreviousSectionToColumns(ColumnCount, 0, 
                new PageMargin() {
                    Top = 720,
                    Bottom = 720,
                    Right = 720,
                    Left = 720
                });
        }

        public static OpenXmlElement SetPreviousSectionToColumns(int ColumnCount, int SpaceBetween) {
            return SetPreviousSectionToColumns(ColumnCount, SpaceBetween, 
                new PageMargin() {
                    Top = 720,
                    Bottom = 720,
                    Right = 720,
                    Left = 720
                });
        }

        public static OpenXmlElement SetPreviousSectionToColumns(int ColumnCount, int SpaceBetween, int Margins) {
            return SetPreviousSectionToColumns(ColumnCount, SpaceBetween, 
                new PageMargin() {
                    Top = Margins,
                    Bottom = Margins,
                    Right = (uint)Margins,
                    Left = (uint)Margins
                });
        }

        public static OpenXmlElement SetPreviousSectionToColumns(int ColumnCount, int SpaceBetween, PageMargin Margins) {

            return new Paragraph(
                    new ParagraphProperties(
                        new SectionProperties(
                            new Columns() {
                                ColumnCount = (DocumentFormat.OpenXml.Int16Value)ColumnCount,
                                Space = $"{SpaceBetween}" 
                            },
                            new DocGrid() {
                                LinePitch = 360
                            },
                            new SectionType() {
                                Val = SectionMarkValues.Continuous
                            },
                            Margins                            
                        )
                    )                    
                );
        }

        public static OpenXmlElement ColumnBreak() {
            return new Paragraph(
                new Run(
                    new Break() { 
                        Type = BreakValues.Column 
                        }
                    )
                ) {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = LSSDDocumentStyles.WhiteSpace
                        }
                    }
                };
        }
    }

}