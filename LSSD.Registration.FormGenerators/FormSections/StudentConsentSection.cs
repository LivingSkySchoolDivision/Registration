using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Extensions;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class StudentConsentSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(StudentConsentInfo sectionInfo)
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();
            sectionParts.Add(ParagraphHelper.Paragraph("Student Consent / Media Release", LSSDDocumentStyles.SectionTitle));

            if (sectionInfo != null) {
                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Grants consent to share with school/school division:").WithWidth(40),
                            TableHelper.ValueCell(sectionInfo.ShareWithSchoolDivision).WithWidth(5),
                            TableHelper.LabelCell("Understands consent limited to this school:").WithWidth(40),
                            TableHelper.ValueCell(sectionInfo.UnderstandsLimitedBySchool).WithWidth(5)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Grants consent to share with media:"),
                            TableHelper.ValueCell(sectionInfo.ShareWithMedia),
                            TableHelper.LabelCell("Understands consent can be revoked at any time:"),
                            TableHelper.ValueCell(sectionInfo.UnderstandsCanBeRevoked)
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Verified answers to above:"),
                            TableHelper.ValueCell(sectionInfo.UnderstandsGivenAnswers),
                            TableHelper.LabelCell("Gave consent voluntarily:"),
                            TableHelper.ValueCell(sectionInfo.GaveConsentVoluntarily)
                        )
                    )
                );
            }
            sectionParts.Add(ParagraphHelper.WhiteSpace());

            return sectionParts;
        }

    }
}