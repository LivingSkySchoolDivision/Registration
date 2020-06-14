using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class SubmittedBySection
    {
        public static IEnumerable<OpenXmlElement> GetSection(FormSubmitter submittedBy) 
        {
            return new List<OpenXmlElement>() {
                TableHelper.StyledTable(
                    new TableRow(
                        TableHelper.LabelCell("Submitted By", JustificationValues.Left, 50),
                        TableHelper.LabelCell("Contact Details", JustificationValues.Left, 50)
                    ),
                    new TableRow(
                        TableHelper.ValueCell($"{submittedBy.FirstName} {submittedBy.LastName}", JustificationValues.Left),
                        TableHelper.ValueCell(submittedBy.ContactDetails)
                    )
                ),
                ParagraphHelper.WhiteSpace()
            };
                
        }

    }
}