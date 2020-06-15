using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class PreKStudentInfoSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(Student Student, TimeZoneInfo TimeZone) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();
                   
            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(1, 100));

            sectionParts.Add(
                TableHelper.StyledTableForColumns(
                    TableHelper.FieldTableRow("Legal Name:", Student.GetLegalName()),
                    TableHelper.FieldTableRow("Preferred Name:", Student.GetPreferredName()),
                    TableHelper.FieldTableRow("Gender:", Student.Gender)
                )
            );

            sectionParts.Add(
                TableHelper.StyledTableForColumns(
                    TableHelper.FieldTableRow("Date of Birth:", Student.GetDateOfBirthWithAge()),                    
                    TableHelper.FieldTableRow("Land Description:", Student.LandDescription),
                    TableHelper.FieldTableRow("Medical Notes:", Student.MedicalNotes)
                )
            );

            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(2, 100));
            sectionParts.Add(ParagraphHelper.WhiteSpace());

            // The code below will crash if the addresses are null, so check
            // and make them empty if they are null
            if (Student.PrimaryAddress == null) {
                Student.PrimaryAddress = new Address();
            }

            if (Student.MailingAddress == null) {
                Student.MailingAddress = new Address();
            }

            sectionParts.Add(
              TableHelper.StyledTable(
                    new TableRow(
                        TableHelper.LabelCell("Primary Address"),                        
                        TableHelper.LabelCell("Mailing Address")
                    ),
                    new TableRow(
                        TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(Student.PrimaryAddress.ToFormattedAddress())),
                        TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(Student.MailingAddress.ToFormattedAddress()))
                    )
                )  
            );
            sectionParts.Add(ParagraphHelper.WhiteSpace());
            return sectionParts;
        }

    }
}