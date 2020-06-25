using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.FormGenerators.Common;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class SchoolAndGradeSection 
    {        
        private const string _defaultBorderColor = "C0C0C0";

        public static IEnumerable<OpenXmlElement> GetSection(SelectedSchool School, GradeInfo Grade) 
        {
            if (School == null) {
                throw new System.Exception("School cannot be null");
            }

            return new List<OpenXmlElement>() {
                TableHelper.StyledTable(                    
                    new TableRow(
                        TableHelper.LabelCell("School", JustificationValues.Center, 1, 66.6),
                        TableHelper.LabelCell("Grade", JustificationValues.Center, 1, 33.3)
                    ),
                    new TableRow(
                        TableHelper.ValueCell($"{School?.Name} ({School?.DAN})", JustificationValues.Center),
                        TableHelper.ValueCell(Grade?.Grade, JustificationValues.Center)
                    )
                ),
                ParagraphHelper.WhiteSpace()
            };
        }
    }
}