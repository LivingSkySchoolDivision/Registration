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

        private static Run phoneNumberBlob(string HomePhone, string WorkPhone, string CellPhone, string AltContactInfo) {
            StringBuilder blob = new StringBuilder();
            
            if (!string.IsNullOrEmpty(HomePhone)) {
                blob.Append($"{HomePhone} (Home)\n");
            }

            if (!string.IsNullOrEmpty(CellPhone)) {
                blob.Append($"{CellPhone} (Cell)\n");
            }

            if (!string.IsNullOrEmpty(WorkPhone)) {
                blob.Append($"{WorkPhone} (Work)\n");
            }

            if (!string.IsNullOrEmpty(AltContactInfo)) {
                blob.Append($"{AltContactInfo}");
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
                        TableHelper.StyledTableBordered(
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Name:"),
                                TableHelper.ValueCell(contact.GetDisplayName(), JustificationValues.Left).WithColspan(5)
                            ),
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Relation:", JustificationValues.Left).WithWidth(15),
                                TableHelper.ValueCell(contact.RelationshipToStudent),                                
                                TableHelper.LabelCell("Email:"),
                                TableHelper.ValueCell(contact.EmailAddress),
                                TableHelper.LabelCell("Lives With:"),
                                TableHelper.ValueCell(contact.LivesWithStudent)
                            ),
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Priority:"),
                                TableHelper.ValueCell(contact.ContactPriority.ToString()),
                                TableHelper.LabelCell("Employer"),
                                TableHelper.ValueCell(contact.Employer),
                                TableHelper.LabelCell("Rcv. Mail:"),
                                TableHelper.ValueCell(contact.ShouldRecieveMailAboutStudent)
                            ),
                            TableHelper.StickyTableRow(
                                TableHelper.LabelCell("Notes:"),
                                TableHelper.ValueCell(contact.Note, JustificationValues.Left).WithColspan(5)
                            ),
                            TableHelper.StickyTableRow(                        
                                TableHelper.LabelCell("Contact", JustificationValues.Left).WithColspan(2).WithWidth(33.3),        
                                TableHelper.LabelCell("Primary Addr", JustificationValues.Left).WithColspan(2).WithWidth(33.3),
                                TableHelper.LabelCell("Mailing Addr", JustificationValues.Left).WithColspan(2).WithWidth(33.3)
                            ),
                            TableHelper.StickyTableRow(    
                                TableHelper.ValueCell(phoneNumberBlob(contact.HomePhone, contact.WorkPhone, contact.CellPhone, contact.AlternateContactInfo)).WithColspan(2),
                                TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(contact.PrimaryAddress.ToFormattedAddress()), JustificationValues.Left).WithColspan(2),
                                TableHelper.ValueCell(ParagraphHelper.ConvertMultiLineString(contact.MailingAddress.ToFormattedAddress()), JustificationValues.Left).WithColspan(2)
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
            sectionParts.Add(ParagraphHelper.WhiteSpace());

            return sectionParts;
        }
    }
}