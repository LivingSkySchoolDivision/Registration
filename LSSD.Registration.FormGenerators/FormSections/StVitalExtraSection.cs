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
                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Acknowledges Policy"),                        
                            TableHelper.LabelCell("Child is baptized"),                      
                            TableHelper.LabelCell("Child will be baptized within 1 year")
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.ValueCell(stVitalExtraRequirements.AcknowledgesPolicy ? "Yes" : "No"),
                            TableHelper.ValueCell(stVitalExtraRequirements.ChildIsCatholic ? "Yes" : "No"),                            
                            TableHelper.ValueCell(stVitalExtraRequirements.CommitToBaptize ? "Yes" : "No")
                        )
                    )  
                );

                sectionParts.Add(ParagraphHelper.WhiteSpace());
            }

            return sectionParts;
        }

    }
}