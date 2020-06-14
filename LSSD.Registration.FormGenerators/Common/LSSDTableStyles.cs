using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace LSSD.Registration.FormGenerators.Common {
    static class LSSDTableStyles {
        private const string _defaultBorderColor = "C0C0C0";

        public static OpenXmlElement Margins() {
            return new TableCellMarginDefault(
                    new TopMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                    new LeftMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                    new BottomMargin() { Width = "25", Type = TableWidthUnitValues.Dxa },
                    new RightMargin() { Width = "100", Type = TableWidthUnitValues.Dxa }
                );
        }

        public static OpenXmlElement Borders() {
            return Borders(_defaultBorderColor);
        }

        public static OpenXmlElement Borders(string BorderColor) {
            return new TableBorders(
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
                );
        }

    }
}