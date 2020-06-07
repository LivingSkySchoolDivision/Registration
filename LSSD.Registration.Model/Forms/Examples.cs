using LSSD.Registration.Model;
using LSSD.Registration.Model.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.Forms
{
    public static class Examples
    {
        public static readonly PreKRegistrationFormSubmission PreK = new PreKRegistrationFormSubmission()
        {
            SubmittedBy = new FormSubmitter() {
                FirstName = "Your first name",
                LastName = "Your last name",
                ContactDetails = "Cell: 1234567890, Twitter: @Twitter"
            },
            School = new SelectedSchool() {
                DAN = "Find DAN and ID from /school in this API",
                Name = "Miskatonic High School"
            },
            Student = new Student() {
                FirstName = "Preferred first name",
                MiddleName = string.Empty,
                LastName = "Preferred last name",
                LegalMiddleName = string.Empty,
                LegalFirstName = "Legal first name",
                LegalLastName = "Legal last name",
                HasPreferredName = true,
                LandDescription = "SE-12-20-33-W1",
                Gender = "Unspecified",
                DateOfBirth = DateTime.Today.AddYears(-5).Date,
                PreviousSchools = "John Smith's Elementary School",
                MedicalNotes = "Allergic to bees",
                HealthServicesNumber = string.Empty,
                PrimaryAddress = new Address()
                {
                    Line1 = "123 Fake Street",
                    Line2 = "Apartment 72",
                    City = "Cake Town",
                    Province = "SK",
                    Country = "Canada",
                    PostalCode = "H0H 0H0"
                },
                MailingAddress = new Address()
                {
                    Line1 = "PO Box 123",
                    Line2 = "",
                    City = "Cake Town",
                    Province = "SK",
                    PostalCode = "H0H 0H0",
                    Country = "Canada"
                }
            },
            Siblings = new SiblingInfo() { 
                Siblings = new List<Sibling>() { 
                    new Sibling()
                    {
                        FirstName = "Sibling first name",
                        LastName = "Sibling last name",
                        SchoolAttending = "School name",
                        DateOfBirth = DateTime.Today.AddYears(-5).Date
                    }
                } 
            },
            PreKInfo = new PreKInfo() {
                SocialEmotionalOrBehaviorIssues = string.Empty,
                ReferredByOtherAgency = string.Empty,
                OtherDifficulties = string.Empty,
                TraumaticExperiences = string.Empty,
                HealthcareCrisis = string.Empty,
                OtherConcerns = string.Empty,
                CustodyConcerns = string.Empty,
                MedicalConcerns = string.Empty,
                BehaviorConcerns = string.Empty
            }
        };

        public static readonly GeneralRegistrationFormSubmission General = new GeneralRegistrationFormSubmission()
        {
            SubmittedBy = new FormSubmitter(),
            School = new SelectedSchool()

        };
    }
}
