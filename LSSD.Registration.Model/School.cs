using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrincipalName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string DAN { get; set; }
        public bool OffersPreK { get; set; }
        public bool OffersKindergarten { get; set; }
        public bool OffersKTo9 { get; set; }
        public bool OffersHighSchool { get; set; }
    }
}
