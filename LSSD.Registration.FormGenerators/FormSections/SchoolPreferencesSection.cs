using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.FormGenerators.Common;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class SchoolPreferencesSection 
    {        
        private const string _defaultBorderColor = "C0C0C0";

        public static IEnumerable<OpenXmlElement> GetSection(SchoolPreferenceList SchoolPreferences) 
        {
            return new List<OpenXmlElement>() {
                ColumnHelper.SetPreviousSectionToColumns(1),
                TableHelper.StyledTable(                    
                    new TableRow(
                        TableHelper.LabelCell("First school choice", JustificationValues.Center, (decimal)33.3),
                        TableHelper.LabelCell("Second school choice", JustificationValues.Center, (decimal)33.3),
                        TableHelper.LabelCell("Third school choice", JustificationValues.Center, (decimal)33.3)
                    ),
                    new TableRow(
                        TableHelper.ValueCell(SchoolPreferences?.FirstChoice.Name, JustificationValues.Center),
                        TableHelper.ValueCell(SchoolPreferences?.SecondChoice.Name, JustificationValues.Center),
                        TableHelper.ValueCell(SchoolPreferences?.ThirdChoice.Name, JustificationValues.Center)
                    )
                ),
                ColumnHelper.SetPreviousSectionToColumns(1),
                ParagraphHelper.WhiteSpace()
            };
        }
    }
}