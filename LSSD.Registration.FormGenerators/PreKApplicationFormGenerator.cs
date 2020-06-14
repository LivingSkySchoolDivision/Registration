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

namespace LSSD.Registration.FormGenerators {

    public class PreKApplicationFormGenerator 
    {
        // For help with how to work with OpenXml documents:
        // https://docs.microsoft.com/en-us/office/open-xml/how-do-i

        public PreKApplicationFormGenerator(SubmittedPreKApplicationForm form, TimeZoneInfo TimeZone) 
        {
            // Generate in a temp folder
            // Read the completed file into a stream of some sort
            // Deliver the file to the consumer of this generator
            // Delete the file
            // Don't do all this in the constructor
            Generate(form, TimeZone);
        }
        
        public void Generate(SubmittedPreKApplicationForm Form, TimeZoneInfo TimeZone) 
        {
            string filename = Form.Id.ToString() + ".docx";

            if (File.Exists(filename)) {
                File.Delete(filename);
            }

            using (WordprocessingDocument document = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document)) { 
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
            pageParts.AddRange(AdministrativeSection.GetSection(Form, TimeZone)); 
            pageParts.AddRange(PreKStudentInfoSection.GetSection(Form.Form.Student, TimeZone));
            pageParts.AddRange(SchoolPreferencesSection.GetSection(Form.Form.SchoolPreferences));
            pageParts.AddRange(SiblingSection.GetSection(Form.Form.Siblings)); 
            pageParts.AddRange(SubmittedBySection.GetSection(Form.Form.SubmittedBy));           
            pageParts.Add(ParagraphHelper.PageBreak());
            pageParts.AddRange(PreKInfoSection.GetSection(Form.Form.PreKInfo));   

            // Set the default for the document to be in a single column, 
            // in case anything before this adds additional columns
            pageParts.Add(ColumnHelper.SetPreviousSectionToColumns(1));
          
            return new Document(new Body(pageParts));
        }
    }
}