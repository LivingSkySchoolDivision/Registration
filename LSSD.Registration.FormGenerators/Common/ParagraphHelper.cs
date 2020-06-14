using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace LSSD.Registration.FormGenerators.Common 
{
    public static class ParagraphHelper 
    {
        public static OpenXmlElement PageBreak() {
            return new Paragraph(
                new Run(
                    new Break() { 
                        Type = BreakValues.Page 
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

        public static OpenXmlElement WhiteSpace() 
        {
            return Paragraph(string.Empty, LSSDDocumentStyles.WhiteSpace);
        }

        public static OpenXmlElement Paragraph(string Text, string Style) 
        {
            return Paragraph(Text, Style, JustificationValues.Left);
        }

    
        public static Run ConvertMultiLineString(string InputString) 
        {
            Run returnMe = new Run();

            string[] newLineArray = { Environment.NewLine, "\n", "<br>" };
            string[] textArray = InputString.Split( newLineArray, StringSplitOptions.None );

            foreach ( string line in textArray )
            {
                if (returnMe.ChildElements.Count > 0)
                {
                    returnMe.Append( new Break( ) );
                }

                returnMe.AppendChild(
                    new Text(line)
                );
            }

            return returnMe;
        }

        public static OpenXmlElement Paragraph(string Text, string Style, JustificationValues Alignment) 
        {
            return new Paragraph(
                new Run(
                    new Text(Text)
                )
            )  {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = Alignment }
                    ) {
                        ParagraphStyleId = new ParagraphStyleId() {
                            Val = Style
                        }
                    }
                };
        }
    }

}