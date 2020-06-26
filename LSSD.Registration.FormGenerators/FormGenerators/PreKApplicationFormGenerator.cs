using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.FormGenerators.FormSections;

namespace LSSD.Registration.FormGenerators.FormGenerators {

    class PreKApplicationFormGenerator 
    {
        // For help with how to work with OpenXml documents:
        // https://docs.microsoft.com/en-us/office/open-xml/how-do-i

        public void Generate(SubmittedPreKApplicationForm Form, TimeZoneInfo TimeZone, string FileName) 
        {
            if (File.Exists(FileName)) {
                File.Delete(FileName);
            }

            using (WordprocessingDocument document = WordprocessingDocument.Create(FileName, WordprocessingDocumentType.Document)) { 
                                
                // Create the main document part
                MainDocumentPart mainPart = document.AddMainDocumentPart();                
                LSSDDocumentStyles.AddStylesToDocument(document);

                mainPart.Document = GenerateBody(Form, TimeZone);
            }
        }

        private Document GenerateBody(SubmittedPreKApplicationForm Form, TimeZoneInfo TimeZone) {

            List<OpenXmlElement> pageParts = new List<OpenXmlElement>();

            // Now add all the generated parts
            // The code for these parts is in /FormSections
            pageParts.AddRange(PageTitleSection.GetSection(Form, TimeZone)); 
            pageParts.AddRange(SchoolPreferencesSection.GetSection(Form.Form.SchoolPreferences));
            pageParts.AddRange(StudentInfoSection.GetSection(Form.Form.Student, TimeZone, true));
            pageParts.AddRange(SubmittedBySection.GetSection(Form.Form.SubmittedBy));    
            pageParts.AddRange(SiblingSection.GetSection(Form.Form.Siblings));
            pageParts.AddRange(PreKInfoSection.GetSection(Form.Form.PreKInfo)); 
            pageParts.AddRange(FormEndSection.GetSection(Form, TimeZone)); 
            return new Document(new Body(pageParts));
        }
    }
}