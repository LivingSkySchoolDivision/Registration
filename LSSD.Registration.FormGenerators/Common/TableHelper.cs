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

        public static Table StyledTable(params OpenXmlElement[] childItems) {
            Table table = new Table(
                new TableLayout() {  Type = TableLayoutValues.Autofit },
                LSSDTableStyles.Borders(),
                LSSDTableStyles.Margins()
            );

            foreach(OpenXmlElement e in childItems) {
                table.AppendChild(e);
            }

            return table;
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, string>> items) {
            return MakeTable(items, 95, _defaultBorderColor);            
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, string>> items, decimal TablewidthPercent) {
            return MakeTable(items, TablewidthPercent, _defaultBorderColor);
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, string>> items, string BorderColor) {
            return MakeTable(items, 95, BorderColor);
        }
        
        public static Table MakeTable(IEnumerable<KeyValuePair<string, string>> items, decimal TablewidthPercent, string BorderColor) {

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

        public static Table MakeTable(IEnumerable<KeyValuePair<string, bool>> items) {
            return MakeTable(items, 95, _defaultBorderColor);
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, bool>> items, decimal TablewidthPercent) {
            return MakeTable(items, TablewidthPercent, _defaultBorderColor);
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, bool>> items, string BorderColor) {
            return MakeTable(items, 95, BorderColor);
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, bool>> items, decimal TablewidthPercent, string BorderColor) {

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

        public static TableCell LabelCell(string Label) {
            return LabelCell(Label, JustificationValues.Left);
        }

        public static TableCell LabelCell(string Label, JustificationValues Alignment, bool AutoWidth) {
            TableCell tc = LabelCell(Label, Alignment);
            if (AutoWidth) {
                tc.AppendChild(new TableCellWidth() { Width = "auto" });
            }
            return tc;
        }

        public static TableCell LabelCell(string Label, JustificationValues Alignment, decimal WidthPercent) {
            TableCell tc = LabelCell(Label, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;
        }

        public static TableCell LabelCell(string Label, JustificationValues Alignment) {
            TableCell tc = new TableCell(
                new Paragraph(
                    new Run(
                        new Text(Label)
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = Alignment }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = LSSDDocumentStyles.FieldLabel
                        }
                    }
                }
            );           

            return tc;
        }

        public static TableCell ValueCell(string Value) {
            return ValueCell(Value, JustificationValues.Left);
        }

        public static TableCell ValueCell(string Value, JustificationValues Alignment)  {
            TableCell tc = new TableCell(
                new Paragraph(
                    new Run(
                        new Text(Value)
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = Alignment }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = "Field Value"
                        }
                    }
                }
            );

            return tc;
        }

        public static TableCell ValueCell(bool Value) {
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
        
        public static TableRow FieldTableRow(string Label, string Value, JustificationValues Alignment, decimal LabelWidthPercent) {
            return new TableRow(
                LabelCell(Label, Alignment, LabelWidthPercent),
                ValueCell(Value)
            );
        }

        public static TableRow FieldTableRow(string Label, bool Value, JustificationValues Alignment, decimal LabelWidthPercent) {
            return new TableRow(
                LabelCell(Label, Alignment, LabelWidthPercent),
                ValueCell(Value)
            );
        } 

        public static TableRow TableHeaderRow(IEnumerable<string> Headings) {
            TableRow tr = new TableRow();

            foreach(string heading in Headings) {
                tr.AppendChild(LabelCell(heading));
            }

            return tr;

        }

        public static TableRow TableValuesRow(IEnumerable<string> Values) {
            TableRow tr = new TableRow();

            foreach(string value in Values) {
                tr.AppendChild(ValueCell(value));
            }

            return tr;
        }


    }
}