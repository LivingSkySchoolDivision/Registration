using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class StVitalExtraSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(StVitalExtraRequirements stVitalExtraRequirements) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();
            
            if (stVitalExtraRequirements != null) {
                sectionParts.Add(ParagraphHelper.Paragraph("St. Vital Catholic School Admission Policy :", LSSDDocumentStyles.SectionTitle));
          
                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Form submitter acknowledges that they understand policy:"),
                            TableHelper.ValueCell(stVitalExtraRequirements.AcknowledgesPolicy)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Child is already baptized in Catholic faith:"),
                            TableHelper.ValueCell(stVitalExtraRequirements.ChildIsCatholic)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Will commit to baptising within 1 year:"),
                            TableHelper.ValueCell(stVitalExtraRequirements.ChildIsCatholic ? "N/A" : (stVitalExtraRequirements.CommitToBaptize ? "Yes" : "No"))
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Acknowledges failure to baptize means discontinuing enrolment at St Vital:"),
                            TableHelper.ValueCell(stVitalExtraRequirements.ChildIsCatholic ? "N/A" : (stVitalExtraRequirements.AcknowledgeFailureState ? "Yes" : "No"))
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Understands that contact info will be shared with St. Vital Parish:"),
                            TableHelper.ValueCell(stVitalExtraRequirements.ShareInfoWithParish)
                        )
                    )                    
                );

                sectionParts.Add(ParagraphHelper.WhiteSpace());
            }

            return sectionParts;
        }

    }
}