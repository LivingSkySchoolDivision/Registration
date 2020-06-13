using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.FormGenerators.FormSections 
{
    class AdministrativeSection 
    {
        public static IEnumerable<OpenXmlElement> GetSection(SubmittedPreKApplicationForm Form, TimeZoneInfo timezone)
        {
            return GetSection(Form, timezone, "LSSD Pre-Kindergarten Application Form");
        } 

        public static IEnumerable<OpenXmlElement> GetSection(SubmittedGeneralRegistrationForm Form, TimeZoneInfo timezone)
        {
            return GetSection(Form, timezone, "LSSD K-12 Registration Form");
        } 

        private static IEnumerable<OpenXmlElement> GetSection(BaseSubmittedForm Form, TimeZoneInfo timezone, string Title) {
            return new List<OpenXmlElement>() {                
                new Paragraph(
                    new Run(
                        new Text(Title)
                    )
                )  {
                    ParagraphProperties = new ParagraphProperties() {
                        ParagraphStyleId = new ParagraphStyleId() { 
                            Val = "Page Title"
                        }
                    }
                },
                new Table(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "5000" }, // 100% of the page
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("Application Received")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Label"
                                    }
                                }
                            }
                        ),
                        new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "1000" },                          
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"{TimeZoneInfo.ConvertTimeFromUtc(Form.DateReceivedUTC, timezone).ToLongDateString()} {TimeZoneInfo.ConvertTimeFromUtc(Form.DateReceivedUTC, timezone).ToShortTimeString()}")                                    
                                )      
                            )  {
                                ParagraphProperties = new ParagraphProperties() {
                                    ParagraphStyleId = new ParagraphStyleId() { 
                                        Val = "Field Value"
                                    }
                                }
                            }
                        )
                    )
                )
            };            
        }
    }
}