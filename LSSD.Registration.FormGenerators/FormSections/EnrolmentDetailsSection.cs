using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class EnrolmentDetailsSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(EnrolmentInfo EnrolmentInfo) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (EnrolmentInfo != null) {
                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("No Previous Schooling"),
                            TableHelper.ValueCell(EnrolmentInfo.NoPreviousSchooling),
                            TableHelper.LabelCell("Exchange Student"),
                            TableHelper.ValueCell(EnrolmentInfo.ExchangeStudent)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Transfer from another province"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromAnotherProvince),
                            TableHelper.LabelCell("Transfer from Home-Based"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromHomeBased)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Transfer from another SASK school"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromAnotherSaskSchool),
                            TableHelper.LabelCell("Transfer from another country"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromAnotherCountry)
                        )
                    )
                );

                sectionParts.Add(ParagraphHelper.WhiteSpace());
            }
            
            return sectionParts;
        }

    }
}