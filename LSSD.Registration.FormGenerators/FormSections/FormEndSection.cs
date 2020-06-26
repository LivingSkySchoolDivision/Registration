using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.FormGenerators.FormSections 
{
    class FormEndSection 
    {
        
        public static IEnumerable<OpenXmlElement> GetSection(SubmittedPreKApplicationForm Form, TimeZoneInfo timezone)
        {
            return GetSection(Form, timezone, "LSSD Pre-Kindergarten Application Form", Form.Id.ToString());
        } 

        public static IEnumerable<OpenXmlElement> GetSection(SubmittedGeneralRegistrationForm Form, TimeZoneInfo timezone)
        {
            return GetSection(Form, timezone, "LSSD K-12 Registration Form", Form.Id.ToString());
        } 

        private static IEnumerable<OpenXmlElement> GetSection(BaseSubmittedForm Form, TimeZoneInfo timezone, string Title, string FormId) {
            return new List<OpenXmlElement>() {
                ParagraphHelper.Paragraph(Title, LSSDDocumentStyles.Dim, JustificationValues.Center),
                ParagraphHelper.Paragraph($"Form id: {FormId}, submitted {TimeZoneInfo.ConvertTimeFromUtc(Form.DateReceivedUTC,timezone).ToShortDateString()}", LSSDDocumentStyles.Dim, JustificationValues.Center),
                ParagraphHelper.WhiteSpace()
            };            
        }
    }
}