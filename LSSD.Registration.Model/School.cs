using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Community { get; set; }
        public string WebsiteURL { get; set; }
        public  string EmailAddress { get; set; }
        public Address MailingAddress { get; set; }
        public Address PhysicalAddress { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string DAN { get; set; }
        public string GradesOffered { get; set; }
        public bool OffersPreK { get; set; }
        public bool OffersKTo9 { get; set; }
        public bool OffersHighSchool { get; set; }
    }
}
