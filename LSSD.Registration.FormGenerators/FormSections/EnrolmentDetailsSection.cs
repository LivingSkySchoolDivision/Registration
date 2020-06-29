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
                            TableHelper.LabelCell("No Previous Schooling:").WithWidth(40),
                            TableHelper.ValueCell(EnrolmentInfo.NoPreviousSchooling).WithWidth(5),
                            TableHelper.LabelCell("Transfer from Home-Based:"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromHomeBased)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Transfer from another SASK school:"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromAnotherSaskSchool),
                            TableHelper.ValueCell(EnrolmentInfo.SchoolTransferredFrom).WithColspan(2)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Transfer from another country:"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromAnotherCountry),
                            TableHelper.ValueCell(EnrolmentInfo.CountryTransferredFrom).WithColspan(2)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Exchange Student:").WithWidth(40),
                            TableHelper.ValueCell(EnrolmentInfo.ExchangeStudent).WithWidth(5),
                            TableHelper.ValueCell(EnrolmentInfo.ExchangeStudentFrom).WithColspan(2)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Transfer from another province:"),
                            TableHelper.ValueCell(EnrolmentInfo.TransferFromAnotherProvince),
                            TableHelper.ValueCell(EnrolmentInfo.ProvinceTransferredFrom).WithColspan(2)
                        )
                    )
                );


                sectionParts.Add(ParagraphHelper.WhiteSpace());
            }
            
            return sectionParts;
        }

    }
}