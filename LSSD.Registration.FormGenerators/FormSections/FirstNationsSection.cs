using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class FirstNationsSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(FirstNationsInfo FNInfo) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();
            
            sectionParts.Add(ParagraphHelper.Paragraph("Students of First Nations Ancestry", LSSDDocumentStyles.SectionTitle));

            if (FNInfo != null ) {
                if (FNInfo.IsDeclaringFirstNationsInfo) {
                    sectionParts.Add(
                        TableHelper.StyledTable(
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Aboriginal group:"),
                                TableHelper.ValueCell(FNInfo.AboriginalStatus),
                                TableHelper.LabelCell("Status Number:"),
                                TableHelper.ValueCell(FNInfo.StatusNumber)
                            ),
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Resides On Reserve:"),
                                TableHelper.ValueCell(FNInfo.ResidesOnReserve),
                                TableHelper.LabelCell("Reserve of Residence:"),
                                TableHelper.ValueCell(FNInfo.ReserveName)
                            ),
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Band Name:"),
                                TableHelper.ValueCell(FNInfo.BandName),
                                TableHelper.LabelCell("Reserve House:"),
                                TableHelper.ValueCell(FNInfo.ReserveHouse)
                            )
                        )
                    );
                } else {
                    sectionParts.Add(ParagraphHelper.Paragraph("No First Nations information was declared.", LSSDDocumentStyles.NormalParagraph));            
                }
                
            } else {
                sectionParts.Add(ParagraphHelper.Paragraph("No First Nations data was collected.", LSSDDocumentStyles.NormalParagraph));
            }

            sectionParts.Add(ParagraphHelper.WhiteSpace());
            
            return sectionParts;
        }

    }
}