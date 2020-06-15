using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.FormGenerators.FormSections 
{
    class PageTitleSection 
    {
        
        public static IEnumerable<OpenXmlElement> GetSection(SubmittedPreKApplicationForm Form, TimeZoneInfo timezone)
        {
            return GetSection(Form, timezone, "Pre-Kindergarten Application Form", Form.Id.ToString());
        } 

        public static IEnumerable<OpenXmlElement> GetSection(SubmittedGeneralRegistrationForm Form, TimeZoneInfo timezone)
        {
            return GetSection(Form, timezone, "K-12 Registration Form", Form.Id.ToString());
        } 

        private static IEnumerable<OpenXmlElement> GetSection(BaseSubmittedForm Form, TimeZoneInfo timezone, string Title, string FormId) {
            return new List<OpenXmlElement>() {           
                ParagraphHelper.Paragraph("Living Sky School Division No. 202", LSSDDocumentStyles.PageTitle, JustificationValues.Center),     
                ParagraphHelper.Paragraph(Title, LSSDDocumentStyles.PageTitle, JustificationValues.Center),
                ParagraphHelper.Paragraph(
                    $"This form was submitted via https://registration.lskysd.ca on {TimeZoneInfo.ConvertTimeFromUtc(Form.DateReceivedUTC,timezone).ToLongDateString()}", 
                    LSSDDocumentStyles.NormalParagraph, 
                    JustificationValues.Center),
                ParagraphHelper.Paragraph($"Form id: {FormId}", LSSDDocumentStyles.Dim, JustificationValues.Center),
                ParagraphHelper.WhiteSpace()
            };            
        }
    }
}