using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RelationshipToChild { get; set; }
        public string Workplace { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public Address PhysicalAddress { get; set; }
        public Address MailingAddress { get; set; }
        public bool ResidesWithChild { get; set; }
    }
}
