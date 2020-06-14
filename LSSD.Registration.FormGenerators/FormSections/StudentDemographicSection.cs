using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class StudentDemographicSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(Student Student, TimeZoneInfo TimeZone) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Student Information")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = LSSDDocumentStyles.FieldValue
                        }
                    }  
                }        
            };
        }

    }
}