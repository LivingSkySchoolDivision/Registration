using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class StudentDemographicSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(Student Student) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Student Information")
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