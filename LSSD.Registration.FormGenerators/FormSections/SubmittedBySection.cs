using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class SubmittedBySection
    {
        public static IEnumerable<OpenXmlElement> GetSection(FormSubmitter submittedBy) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Submitted By Information")
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Field Value"
                        }
                    }  
                }        
            };
        }

    }
}