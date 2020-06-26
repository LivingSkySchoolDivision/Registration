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

        public static Table StyledTableBordered(params OpenXmlElement[] childItems) {
            
            Table table = new Table(
                new TableLayout() {  Type = TableLayoutValues.Autofit },
                new TableWidth() { 
                    Type = TableWidthUnitValues.Pct, 
                    Width = $"{95 * 50}"
                    },
                LSSDTableStyles.ThickOutsideBorders(),
                LSSDTableStyles.Margins()
            );

            foreach(OpenXmlElement e in childItems) {
                table.AppendChild(e);
            }

            return table;
        }

        
        public static TableRow StickyTableRow(params OpenXmlElement[] childItems) 
        {
            TableRow tr = new TableRow(
                new TableRowProperties(
                    new CantSplit()
                ) 
            );        
            
            foreach(OpenXmlElement e in childItems) {
                tr.AppendChild(e);
            }
            return tr;
        }

        public static TableCell WithWidth(this TableCell TC, double WidthPercent) {
            TC.AppendChild(new TableCellWidth() { Width = $"{WidthPercent * 50}", Type = TableWidthUnitValues.Pct });
            return TC;
        }
        public static TableCell WithWidth(this TableCell TC, int WidthPercent) {
            return WithWidth(TC, (double)WidthPercent);
        }

        public static TableCell WithColspan(this TableCell TC, int Columns) {
            TC.AppendChild(new TableCellProperties(new GridSpan() { Val = Columns }));
            return TC;
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
            TableCell tc = new TableCell(
                new Paragraph(
                    new Run(
                        new Text(Label)
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = Alignment },
                        new SpacingBetweenLines() { Before = "0", After = "0" }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = LSSDDocumentStyles.FieldLabel
                        }
                    }
                }                
            );          

            return tc;
        }

        public static TableCell ValueCell(string Value)  {
            return ValueCell(new Run(new Text(Value)));
        }

        public static TableCell ValueCell(Run Value)  {
            return ValueCell(Value, JustificationValues.Left);
        }
        public static TableCell ValueCell(string Value, JustificationValues Alignment)  {
            return ValueCell(new Run(new Text(Value)), Alignment, LSSDDocumentStyles.FieldValue);
        }
        public static TableCell ValueCell(Run Value, JustificationValues Alignment)  {
            return ValueCell(Value, Alignment, LSSDDocumentStyles.FieldValue);
        }

        public static TableCell ValueCell(string Value, JustificationValues Alignment, string Style)  {
            return ValueCell(new Run(new Text(Value)), Alignment, Style);
        }


        public static TableCell ValueCell(Run Value, JustificationValues Alignment, string Style)  {
            TableCell tc = new TableCell(
                new Paragraph(
                    Value
                )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = Alignment },
                        new SpacingBetweenLines() { Before = "0", After = "0" }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = Style
                        }
                    }
                }
            );

            return tc;
        }

        public static TableCell ValueCell(bool Value) {
            string fieldStyle = Value ? LSSDDocumentStyles.FieldValueYes : LSSDDocumentStyles.FieldValueNo;
            return new TableCell(
                new Paragraph(
                    new Run(
                        new Text(Value.ToYesOrNo())
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = JustificationValues.Center },
                        new SpacingBetweenLines() { Before = "0", After = "0" }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = fieldStyle
                        }
                    }
                }
            );

        }
        
        public static TableRow FieldTableRow(string Label, string Value, JustificationValues Alignment, double LabelWidthPercent) {
            return new TableRow(
                LabelCell(Label, Alignment).WithWidth(LabelWidthPercent),
                ValueCell(Value)
            );
        }

        public static TableRow FieldTableRow(string Label, bool Value, JustificationValues Alignment, double LabelWidthPercent) {
            return new TableRow(
                LabelCell(Label, Alignment).WithWidth(LabelWidthPercent),
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