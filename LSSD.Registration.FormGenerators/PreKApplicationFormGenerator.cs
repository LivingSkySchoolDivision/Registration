using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.FormGenerators {

    public class PreKApplicationFormGenerator {

        // For help with how to work with OpenXml documents:
        // https://docs.microsoft.com/en-us/office/open-xml/how-do-i

        public PreKApplicationFormGenerator(SubmittedPreKApplicationForm form) 
        {
            // Generate in a temp folder
            // Read the completed file into a stream of some sort
            // Deliver the file to the consumer of this generator
            // Delete the file
            // Don't do all this in the constructor
            Generate(form);
        }

        private IEnumerable<OpenXmlElement> GenerateAdministrativeSection(SubmittedPreKApplicationForm Form) {
            return new List<OpenXmlElement>() {
                new Table(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "5000" }, // 100% of the page
                    new TableRow( // Cells automatically fit themselves unless you tell them not to
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("Wide cell")
                                )
                            )
                        ),  
                        new TableCellProperties(
                            //new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }
                        ),                             
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("Wide cell 2")
                                )
                            )
                        )
                    )
                )
            };            
        }

        private IEnumerable<OpenXmlElement> GenerateSchoolPreferenceList(SchoolPreferenceList SchoolPreferences) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("School Preferences")
                    )
                ),
                new Table(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "5000" }, // 100% of the page
                    new TableRow(
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text("Test")
                                )
                            )
                        )
                    )
                )
            };
        }

        private IEnumerable<OpenXmlElement> GenerateStudentDemographicSection(Student Student) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Student Information")
                    )
                )            
            };
        }

        private IEnumerable<OpenXmlElement> GenerateSiblingsSection(SiblingInfo Siblings) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("Sibling Information")
                    )
                )            
            };
        }

        private IEnumerable<OpenXmlElement> GeneratePreKInfoSection(PreKInfo PreKInfo) 
        {
            return new List<OpenXmlElement>() {
                new Paragraph(
                    new Run(
                        new Text("PreK Information")
                    )
                )            
            };
        }

        private Document GenerateBody(SubmittedPreKApplicationForm Form) {

            List<OpenXmlElement> pageParts = new List<OpenXmlElement>();

            // First add the properties for the whole document
            pageParts.Add(
                new SectionProperties(
                        new PageMargin() {
                            Top = 720,
                            Bottom = 720,
                            Right = 720,
                            Left = 720
                        }
                    )
                );

            // Now add all the generated parts
            pageParts.AddRange(GenerateSchoolPreferenceList(Form.Form.SchoolPreferences)); 
            pageParts.AddRange(GenerateStudentDemographicSection(Form.Form.Student));           
            pageParts.AddRange(GenerateSiblingsSection(Form.Form.Siblings));
            pageParts.AddRange(GeneratePreKInfoSection(Form.Form.PreKInfo));
            pageParts.AddRange(GenerateAdministrativeSection(Form)); 
          
            return new Document(new Body(pageParts));
        }

        public void Generate(SubmittedPreKApplicationForm Form) 
        {
            string filename = Form.Id.ToString() + ".docx";

            if (File.Exists(filename)) {
                File.Delete(filename);
            }

            using (WordprocessingDocument document = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document)) { 
                // Create the main document part
                MainDocumentPart mainPart = document.AddMainDocumentPart();
                mainPart.Document = GenerateBody(Form);
            }
        }


    }
}