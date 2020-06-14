using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace LSSD.Registration.FormGenerators.Common 
{
    public static class ParagraphHelper 
    {

        public static OpenXmlElement WhiteSpace() 
        {
            return Paragraph(string.Empty, "Field Value");
        }

        public static OpenXmlElement Paragraph(string Text, string Style) 
        {
            return Paragraph(Text, Style, JustificationValues.Left);
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