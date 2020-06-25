using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LSSD.Registration.Model;
using LSSD.Registration.FormGenerators.Common;
using System.Text;

namespace LSSD.Registration.FormGenerators.FormSections
{
    class ContactsSection
    {
        private const string _defaultBorderColor = "C0C0C0";

        private static Run phoneNumberBlob(string HomePhone, string WorkPhone, string CellPhone) {
            StringBuilder blob = new StringBuilder();
            
            if (!string.IsNullOrEmpty(HomePhone)) {
                blob.Append($"{HomePhone} (Home)\n");
            }

            if (!string.IsNullOrEmpty(WorkPhone)) {
                blob.Append($"{WorkPhone} (Work)\n");
            }

            if (!string.IsNullOrEmpty(CellPhone)) {
                blob.Append($"{CellPhone} (Cell)\n");
            }

            return ParagraphHelper.ConvertMultiLineString(blob.ToString());
        }

        public static IEnumerable<OpenXmlElement> GetSection(ContactsInfo Contacts)
        {
            List<OpenXmlElement> sectionParts = new List<OpenXmlElement>();

            if (Contacts?.Contacts.Count > 0) {
                sectionParts.Add(ParagraphHelper.Paragraph("Contacts", LSSDDocumentStyles.SectionTitle));

                foreach(Contact contact in Contacts.Contacts) {
                    sectionParts.Add(
                        TableHelper.StyledTable(
                            new TableRow(
                                TableHelper.ValueCell(contact.GetDisplayName(), JustificationValues.Left, 4)
                            ),
                            new TableRow(
                                TableHelper.LabelCell("Phone:", JustificationValues.Left, 1, 15),
                                TableHelper.ValueCell(phoneNumberBlob(contact.HomePhone, contact.WorkPhone, contact.CellPhone)),
                                TableHelper.LabelCell("Rcv. Mail:"),
                                TableHelper.ValueCell(contact.ShouldRecieveMailAboutStudent),
                                TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(contact.PrimaryAddress.ToFormattedAddress()))
                            ),
                            new TableRow(
                                TableHelper.LabelCell("Email:"),
                                TableHelper.ValueCell(contact.EmailAddress),
                                TableHelper.LabelCell("Lives With:"),
                                TableHelper.ValueCell(contact.LivesWithStudent)
                            ),
                            new TableRow(
                                TableHelper.LabelCell("Alt contact info:"),
                                TableHelper.ValueCell(contact.AlternateContactInfo),
                                TableHelper.LabelCell("Employer:"),
                                TableHelper.ValueCell(contact.Employer),
                                TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(contact.MailingAddress.ToFormattedAddress()))
                            ),
                            new TableRow(                                
                                TableHelper.LabelCell("Primary Addr", JustificationValues.Left, 2),
                                TableHelper.LabelCell("Mailing Addr", JustificationValues.Left, 2)
                            ),
                            new TableRow(

                            )
                            
                        )
                    );

                    sectionParts.Add(
                        ParagraphHelper.WhiteSpace()
                    );
                }
            } else {
                sectionParts.Add(
                    ParagraphHelper.Paragraph("No contact information entered", LSSDDocumentStyles.FieldValue)
                );
            }

            sectionParts.Add(ColumnHelper.SetPreviousSectionToColumns(1));
            sectionParts.Add(ParagraphHelper.WhiteSpace());

            return sectionParts;
        }
    }
}