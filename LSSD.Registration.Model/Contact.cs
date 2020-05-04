using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RelationshipToStudent { get; set; }
        public int ContactPriority { get; set; }
        public bool LivesWithStudent { get; set; }
        public bool ShouldRecieveMailAboutStudent { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address MailingAddress { get; set; }
        public bool ResidesWithChild { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string Employer { get; set; }
        public string EmailAddress { get; set; }
    }
}
