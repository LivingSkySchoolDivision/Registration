using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class EALSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(EALInfo EALInfo) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (EALInfo != null) {
                sectionParts.Add(ParagraphHelper.Paragraph("EAL", LSSDDocumentStyles.SectionTitle));

                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Is EAL:"),
                            TableHelper.ValueCell(EALInfo.IsEAL),
                            TableHelper.LabelCell("First CDN School?:"),
                            TableHelper.ValueCell(EALInfo.IsFirstCanadianSchool)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Entry date to Canada:"),
                            TableHelper.ValueCell(EALInfo.EntryDateToCanada?.ToShortDateString()),
                            TableHelper.LabelCell("Entry date to CDN school:"),
                            TableHelper.ValueCell(EALInfo.EntryDateToCanadianSchool?.ToShortDateString())
                        )
                    )
                );

                sectionParts.Add(ParagraphHelper.WhiteSpace());
            }
            
            return sectionParts;
        }

    }
}