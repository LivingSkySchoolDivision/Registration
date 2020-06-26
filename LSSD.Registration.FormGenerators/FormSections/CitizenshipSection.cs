using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class CitizenshipSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(CitizenshipInfo CitizenshipInfo) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (CitizenshipInfo != null) {
                sectionParts.Add(ParagraphHelper.Paragraph("Citizenship", LSSDDocumentStyles.SectionTitle));

                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Birth Country:"),
                            TableHelper.ValueCell(CitizenshipInfo.CountryOfBirth),
                            TableHelper.LabelCell("Citizenship:"),
                            TableHelper.ValueCell(CitizenshipInfo.Citizenship),
                            TableHelper.LabelCell("Residency Type:"),
                            TableHelper.ValueCell(CitizenshipInfo.ResidencyType)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Lang. at home:").WithWidth(16.6),
                            TableHelper.ValueCell(CitizenshipInfo.LanguageSpokenAtHome).WithColspan(2).WithWidth(33.3),
                            TableHelper.LabelCell("Previous Country:").WithWidth(16.6),
                            TableHelper.ValueCell(CitizenshipInfo.PreviousCountry).WithColspan(2).WithWidth(33.3)
                        )
                    )
                );

                sectionParts.Add(ParagraphHelper.WhiteSpace());

            }

            
            return sectionParts;
        }

    }
}