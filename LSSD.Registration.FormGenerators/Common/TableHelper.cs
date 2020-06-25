using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Extensions;

namespace LSSD.Registration.FormGenerators.Common 
{
    static class TableHelper 
    {

        public static Table StyledTable(params OpenXmlElement[] childItems) {
            Table table = new Table(
                new TableLayout() {  Type = TableLayoutValues.Autofit },
                new TableWidth() { 
                    Type = TableWidthUnitValues.Pct, 
                    Width = $"{95 * 50}"
                    },
                LSSDTableStyles.Borders(),
                LSSDTableStyles.Margins()
            );

            foreach(OpenXmlElement e in childItems) {
                table.AppendChild(e);
            }

            return table;
        }

        public static Table StyledTableForColumns(params OpenXmlElement[] childItems) {
            Table table = new Table(
                new TableLayout() {  Type = TableLayoutValues.Autofit },
                new TableWidth() { 
                    Type = TableWidthUnitValues.Pct, 
                    Width = $"{90 * 50}"
                    },
                LSSDTableStyles.Borders(),
                LSSDTableStyles.Margins()
            );

            foreach(OpenXmlElement e in childItems) {
                table.AppendChild(e);
            }

            return table;
        }

        public static Table MakeTable(IEnumerable<KeyValuePair<string, bool>> items) {
            return MakeTable(items, 95, LSSDTableStyles._defaultBorderColor);
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

        public static TableCell LabelCell(string Label, JustificationValues Alignment) {
            return LabelCell(Label, Alignment, 1);
        }

        
        public static TableCell LabelCell(string Label, JustificationValues Alignment, int ColSpan, double WidthPercent) {
            TableCell tc = LabelCell(Label, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;
        }

        public static TableCell LabelCell(string Label, JustificationValues Alignment, int ColSpan, int WidthPercent) {
            TableCell tc = LabelCell(Label, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;
        }

        public static TableCell LabelCell(string Label, JustificationValues Alignment, int ColSpan) {
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
                },
                new TableCellProperties(
                    new GridSpan() { Val = ColSpan }
                )
            );          

            return tc;
        }

        public static TableCell ValueCell(Run Value)  {
            return ValueCell(Value, JustificationValues.Left);
        }

        public static TableCell ValueCell(string Value)  {
            return ValueCell(new Run(Value));
        }

        public static TableCell ValueCell(Run Value, JustificationValues Alignment)  {
            return ValueCell(Value, Alignment, 1);
        }
        public static TableCell ValueCell(string Value, JustificationValues Alignment)  {
            return ValueCell(new Run(Value), Alignment, 1);
        }

        public static TableCell ValueCell(string Value, JustificationValues Alignment, int ColSpan)  {
            return ValueCell(new Run(Value), Alignment, ColSpan);
        }
        public static TableCell ValueCell(Run Value, JustificationValues Alignment, int ColSpan, double WidthPercent)  {
            TableCell tc = ValueCell(Value, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;

        }
        
        public static TableCell ValueCell(string Value, JustificationValues Alignment, int ColSpan, double WidthPercent)  {
            TableCell tc = ValueCell(Value, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;

        }
        
        public static TableCell ValueCell(Run Value, JustificationValues Alignment, int ColSpan, int WidthPercent)  {
            TableCell tc = ValueCell(Value, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;

        }
        
        public static TableCell ValueCell(string Value, JustificationValues Alignment, int ColSpan, int WidthPercent)  {
            TableCell tc = ValueCell(Value, Alignment);
            tc.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return tc;

        }

        public static TableCell ValueCell(Run Value, JustificationValues Alignment, int ColSpan)  {
            TableCell tc = new TableCell(
                new Paragraph(
                    Value
                )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = Alignment }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = "Field Value"
                        }
                    }
                },
                new TableCellProperties(
                    new GridSpan() { Val = ColSpan }
                )
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
        
        public static TableRow FieldTableRow(string Label, string Value, JustificationValues Alignment, double LabelWidthPercent) {
            return new TableRow(
                LabelCell(Label, Alignment, 1, LabelWidthPercent),
                ValueCell(Value)
            );
        }

        public static TableRow FieldTableRow(string Label, bool Value, JustificationValues Alignment, double LabelWidthPercent) {
            return new TableRow(
                LabelCell(Label, Alignment, 1, LabelWidthPercent),
                ValueCell(Value)
            );
        } 

        public static TableRow FieldTableRow(string Label, string Value) {
            return new TableRow(
                LabelCell(Label),
                ValueCell(Value)
            );
        } 

        public static TableRow FieldTableRow(string Label, bool Value) {
            return new TableRow(
                LabelCell(Label),
                ValueCell(Value)
            );
        } 

        

    }
}