using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.FormGenerators.Common;

namespace LSSD.Registration.FormGenerators.FormSections 
{
    class SiblingSection 
    {
        private const string _defaultBorderColor = "C0C0C0";
        
        public static IEnumerable<OpenXmlElement> GetSection(SiblingInfo Siblings) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (Siblings?.Siblings.Count > 0) {
                Table siblingTable = TableHelper.StyledTable(
                    new TableRow(
                        TableHelper.LabelCell("Sibling Name"),
                        TableHelper.LabelCell("Date of Birth"),
                        TableHelper.LabelCell("School Attending")                        
                    )
                );
                
                foreach(Sibling sibling in Siblings.Siblings) {
                    siblingTable.AppendChild(
                        new TableRow( 
                            TableHelper.ValueCell($"{sibling.LastName}, {sibling.FirstName}"),
                            TableHelper.ValueCell(sibling.DateOfBirth != null ? sibling.DateOfBirth.GetValueOrDefault().ToLongDateString() : "(not submitted)"),
                            TableHelper.ValueCell(sibling.SchoolAttending) 
                        )
                    );                    
                }

                sectionParts.Add(siblingTable);
            } else {
                sectionParts.Add(
                    ParagraphHelper.Paragraph("No sibling information entered", LSSDDocumentStyles.FieldValue)
                );
            }

            sectionParts.Add(ParagraphHelper.WhiteSpace());

            return sectionParts;
        }
    }
}