using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Extensions;

namespace LSSD.Registration.FormGenerators.Common 
{
    class TableHelper 
    {
        private const string _defaultBorderColor = "C0C0C0";

        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, string>> items) {
            return MakeTable(items, 95, _defaultBorderColor);
        }

        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, string>> items, decimal TablewidthPercent) {
            return MakeTable(items, TablewidthPercent, _defaultBorderColor);
        }

        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, string>> items, string BorderColor) {
            return MakeTable(items, 95, BorderColor);
        }
        
        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, string>> items, decimal TablewidthPercent, string BorderColor) {

            Table itemTable = new Table(
                new TableWidth() { 
                    Type = TableWidthUnitValues.Pct, 
                    Width = $"{TablewidthPercent * 50}"
                    },
                LSSDTableStyles.Borders(BorderColor),
                LSSDTableStyles.Margins()
            );

            foreach(KeyValuePair<string, string> item in items) {
                itemTable.AppendChild(
                    new TableRow(
                        LabelCell(item.Key),
                        ValueCell(item.Value)
                    )
                );
            }

            return itemTable;
        }


        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, bool>> items) {
            return MakeTable(items, 95, _defaultBorderColor);
        }

        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, bool>> items, decimal TablewidthPercent) {
            return MakeTable(items, TablewidthPercent, _defaultBorderColor);
        }

        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, bool>> items, string BorderColor) {
            return MakeTable(items, 95, BorderColor);
        }

        public static OpenXmlElement MakeTable(IEnumerable<KeyValuePair<string, bool>> items, decimal TablewidthPercent, string BorderColor) {

            Table itemTable = new Table(
                new TableWidth() { 
                    Type = TableWidthUnitValues.Pct, 
                    Width = $"{TablewidthPercent * 50}"
                    },
                LSSDTableStyles.Borders(BorderColor),
                LSSDTableStyles.Margins()
            );

            foreach(KeyValuePair<string, bool> item in items) {
                itemTable.AppendChild(
                    new TableRow(
                        LabelCell(item.Key),
                        ValueCell(item.Value)
                    )
                );
            }

            return itemTable;
        }

        public static OpenXmlElement LabelCell(string Label) {
            return new TableCell(
                new Paragraph(
                    new Run(
                        new Text(Label)
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
            );
        }

        public static OpenXmlElement ValueCell(string Value)  {
            return new TableCell(
                new Paragraph(
                    new Run(
                        new Text(Value)
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
            );
        }

        public static OpenXmlElement ValueCell(bool Value) {
            if (Value == true) {
                return new TableCell(
                    new Paragraph(
                        new Run(
                            new Text(Value.ToYesOrNo())
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
                );
            } else {
                return new TableCell(
                    new Paragraph(
                        new Run(
                            new Text(Value.ToYesOrNo())
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
                );
            }
        }
        
        public static OpenXmlElement TableRow(string Label, string Value) {
            return new TableRow(
                LabelCell(Label),
                ValueCell(Value)
            );
        }

        public static OpenXmlElement TableRow(string Label, bool Value) {
            return new TableRow(
                LabelCell(Label),
                ValueCell(Value)
            );
        } 
    }
}