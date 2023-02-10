using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.FormGenerators.Common;
using LSSD.Registration.Model;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class StudentInfoSection
    {
        public static IEnumerable<OpenXmlElement> GetSection(Student Student, TimeZoneInfo TimeZone, bool IsPreKForm = false) 
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();
            
            sectionParts.Add(
                TableHelper.StyledTable(
                    TableHelper.FieldTableRow("Legal Name:", Student.GetLegalName()),
                    TableHelper.FieldTableRow("Preferred Name:", Student.GetPreferredName()),
                    TableHelper.FieldTableRow("Gender:", Student.Gender),
                    TableHelper.FieldTableRow("Date of Birth:", Student.GetDateOfBirthWithAge()),
                    TableHelper.FieldTableRow("Medical Notes:", Student.MedicalNotes),
                    TableHelper.FieldTableRow("Land Description:", Student.LandDescription),
                    TableHelper.FieldTableRow("Student Cell #:", Student.CellPhone)
                )
            );

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
                    TableHelper.StickyTableRow(
                        TableHelper.LabelCell("Primary Address"),                        
                        TableHelper.LabelCell("Mailing Address")
                    ),
                    TableHelper.StickyTableRow(
                        TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(Student.PrimaryAddress.ToFormattedAddress())),
                        TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(Student.MailingAddress.ToFormattedAddress()))
                    )
                )  
            );

            // Previous schools 
            if (!string.IsNullOrEmpty(Student.PreviousSchools)) {           
                sectionParts.Add(ParagraphHelper.WhiteSpace());
                sectionParts.Add(
                    TableHelper.StyledTable(
                        TableHelper.StickyTableRow(
                            TableHelper.LabelCell("Previous Schools")
                        ),
                        TableHelper.StickyTableRow(
                            TableHelper.ValueCell(string.IsNullOrEmpty(Student.PreviousSchools) ? "None" : Student.PreviousSchools)
                        )
                    )
                );
            }

            sectionParts.Add(ParagraphHelper.WhiteSpace());
            return sectionParts;
        }

    }
}