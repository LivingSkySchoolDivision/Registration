using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string LegalFirstName { get; set; }
        public string LegalLastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address PhysicalAddress { get; set; }
        public Address MailingAddress { get; set; }
        public LandDescription LandLocation { get; set; }
        public string PreviousSchools { get; set; }
        public string LanguageSpokenAtHome { get; set; }
        public string SaskHealthNumber { get; set; }
        public string MedicalNotes { get; set; }
        public string Notes { get; set; }


    }
}
