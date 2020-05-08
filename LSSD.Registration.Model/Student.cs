using LSSD.Registration.Model.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LegalFirstName { get; set; }
        [Required]
        public string LegalLastName { get; set; }
        public string LegalMiddleName { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [BirthdayValidator(MinimumAge = 3, MaximumAge = 21)]
        public DateTime DateOfBirth { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address MailingAddress { get; set; }
        public string LandDescription { get; set; }
        public string PreviousSchools { get; set; }
        public string LanguageSpokenAtHome { get; set; }
        public string SaskHealthNumber { get; set; }
        public string MedicalNotes { get; set; }


        public Student()
        {
            this.PrimaryAddress = new Address() { AddressType = "Primary" };
            this.MailingAddress = new Address() { AddressType = "Mailing" };
            this.LanguageSpokenAtHome = "English";
        }

    }
}
