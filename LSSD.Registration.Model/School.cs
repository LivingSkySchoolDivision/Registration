using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class School
    {
        public string Name { get; set; }
        public string PrincipalName { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public bool OffersPreK { get; set; }
        public bool OffersKindergarten { get; set; }
        public bool OffersKTo9 { get; set; }
        public bool OffersHighSchool { get; set; }
    }
}
