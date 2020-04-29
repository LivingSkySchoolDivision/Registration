using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LegalFirstName { get; set; }
        public string LegalLastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address PhysicalAddress { get; set; }
        public Address MailingAddress { get; set; }
        public LandLocation LandLocation { get; set; }

        public List<Contact> ParentsOrGuardians { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Sibling> Siblings { get; set; }


        public string HomeLanguages { get; set; }

        public Student()
        {
            this.Contacts = new List<Contact>();
            this.ParentsOrGuardians = new List<Contact>();
            this.Siblings = new List<Sibling>();
        }
    }
}
