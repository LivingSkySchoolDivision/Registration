using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Extensions;

namespace LSSD.Registration.FormGenerators.Common 
{
    class BoolTable 
    {
        private const string _defaultBorderColor = "C0C0C0";

        public static IEnumerable<OpenXmlElement> MakeTable(IEnumerable<KeyValuePair<string, bool>> items) {
            return MakeTable(items, 95, _defaultBorderColor);
        }

        public static IEnumerable<OpenXmlElement> MakeTable(IEnumerable<KeyValuePair<string, bool>> items, decimal TablewidthPercent) {
            return MakeTable(items, TablewidthPercent, _defaultBorderColor);
        }

        public static IEnumerable<OpenXmlElement> MakeTable(IEnumerable<KeyValuePair<string, bool>> items, string BorderColor) {
            return MakeTable(items, 95, BorderColor);
        }
        
        public static IEnumerable<OpenXmlElement> MakeTable(IEnumerable<KeyValuePair<string, bool>> items, decimal TablewidthPercent, string BorderColor) {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            Table itemTable = new Table(
                new TableWidth() { 
                    Type = TableWidthUnitValues.Pct, 
                    Width = $"{TablewidthPercent * 50}"
                    },
                new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6,
                        Color = BorderColor
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6,
                        Color = BorderColor
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6,
                        Color = BorderColor
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6,
                        Color = BorderColor
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6,
                        Color = BorderColor
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6,
                        Color = BorderColor
                    }
                ),
                new TableCellMarginDefault(
                    new TopMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                    new LeftMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                    new BottomMargin() { Width = "25", Type = TableWidthUnitValues.Dxa },
                    new RightMargin() { Width = "100", Type = TableWidthUnitValues.Dxa }
                )
            );

            foreach(KeyValuePair<string, bool> item in items) {
                TableRow newRow = new TableRow();
                
                newRow.AppendChild(
                    new TableCell(                        
                        new Paragraph(
                            new Run(
                                new Text(item.Key)
                            )
                        )  {
                            ParagraphProperties = new ParagraphProperties(
                                new Justification() { Val = JustificationValues.Left }
                            ) {
                                ParagraphStyleId = new ParagraphStyleId() {
                                    Val = "Field Label"
                                }                                
                            }
                        }
                    ));

                if (item.Value == true) {
                    newRow.AppendChild(
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(item.Value.ToYesOrNo())
                                )
                            )  {
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
                                    ParagraphStyleId = new ParagraphStyleId() {
                                        Val = "Field Value Yes"
                                    }
                                }
                            }
                        ));
                } else {
                    newRow.AppendChild(
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(item.Value.ToYesOrNo())
                                )
                            )  {
                                ParagraphProperties = new ParagraphProperties(
                                    new Justification() { Val = JustificationValues.Center }
                                ) {
                                    ParagraphStyleId = new ParagraphStyleId() {
                                        Val = "Field Value No"
                                    }
                                }
                            }
                        ));
                }


                itemTable.AppendChild(newRow);
            }

            sectionParts.Add(itemTable);
            return sectionParts;
        }
    }
}