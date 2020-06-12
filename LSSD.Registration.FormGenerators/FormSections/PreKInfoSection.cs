using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class PreKInfoSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(PreKInfo PreKInfo) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("PreK Information")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Section Title"
                        }
                    }  
                },
                new Paragraph()          
            };
        }
    }
}