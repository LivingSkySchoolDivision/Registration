using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace LSSD.Registration.FormGenerators {

    public class TestFormGenerator {

        public TestFormGenerator(string OutputFilename) 
        {
            Generate(OutputFilename);
        }

        public void Generate(string filename) 
        {
            using (WordprocessingDocument document = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document)) {
                
                // Create the main document part
                MainDocumentPart mainPart = document.AddMainDocumentPart();

                // Create document structure
                mainPart.Document = new Document(
                    new Body(
                        new Paragraph(
                            new Run(
                                new Text("Hello world")
                            )
                        )
                    )
                );

            }

            //document.Close();
        }


    }
}