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
            SchoolPreferences = new SchoolPreferenceList() {
                FirstChoice = new SelectedSchool()
                {
                    DAN = "123456",
                    Name = "Miskatonic High School"
                },
                SecondChoice = new SelectedSchool()
                {
                    DAN = "234567",
                    Name = "Springfield Elementary School"
                },
                ThirdChoice = new SelectedSchool()
                {
                    DAN = "654321",
                    Name = "Wayside School"
                }
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
            Contacts = new ContactsInfo()
            {
                Contacts = new List<Contact>()
                {
                    new Contact()
                    {
                        FirstName = "Parent's First Name",
                        LastName = "Parent's Last Name",
                        RelationshipToStudent = "Parent",
                        ContactPriority = 1,
                        LivesWithStudent = true,
                        SamePrimaryAddressAsStudent = true,
                        SameMailingAddressAsStudent = true,
                        ShouldRecieveMailAboutStudent = true,
                        HomePhone = "1234567890",
                        WorkPhone = "0987654321",
                        CellPhone = "3216540987",
                        AlternateContactInfo = "Facebook: MyFacebookName",
                        Employer = "Spacely Space Sprockets Inc",
                        EmailAddress = "email@domain.com",
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
                    new Contact()
                    {
                        FirstName = "Parent 2's First Name",
                        LastName = "Parent 2's Last Name",
                        RelationshipToStudent = "Parent",
                        ContactPriority = 2,
                        LivesWithStudent = true,
                        SamePrimaryAddressAsStudent = true,
                        SameMailingAddressAsStudent = true,
                        ShouldRecieveMailAboutStudent = true,
                        HomePhone = "1234567890",
                        WorkPhone = "0987654321",
                        CellPhone = "3216540987",
                        AlternateContactInfo = "Facebook: MyFacebookName",
                        Employer = "Spacely Space Sprockets Inc",
                        EmailAddress = "email@domain.com",
                        Note = "Not reachable during work day",
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
                    new Contact()
                    {
                        FirstName = "Emergency Contact First Name",
                        LastName = "Emergency Contact Last Name",
                        RelationshipToStudent = "Emergency Contact",
                        ContactPriority = 3,
                        LivesWithStudent = false,
                        SamePrimaryAddressAsStudent = false,
                        SameMailingAddressAsStudent = false,
                        ShouldRecieveMailAboutStudent = false,
                        HomePhone = string.Empty,
                        WorkPhone = "0987654321",
                        CellPhone = "3216540987",
                        AlternateContactInfo = string.Empty,
                        Employer = "Cogswell's Cogs",
                        EmailAddress = "email@domain.com",
                        Note = "Has no home phone",
                        PrimaryAddress = new Address()
                        {
                            Line1 = "321 Fake Street",
                            Line2 = string.Empty,
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
                    }
                }
            },
            PreKInfo = new PreKInfo() {
                SocialEmotionalOrBehaviourIssues = string.Empty,
                ReferredByOtherAgency = string.Empty,
                OtherDifficulties = string.Empty,
                TraumaticExperiences = string.Empty,
                HealthcareCrisis = "Worldwide viral pandemic",
                OtherConcerns = string.Empty,
                CustodyConcerns = string.Empty,
                MedicalConcerns = string.Empty,
                AssistanceFromKidsFirst = true,
                AssistanceFromOccupationOrPhysicalTherapist = true,
                LowIncomeFamily = true,
                SpeechDifficulties = true
            },
            Consent = new StudentConsentInfo() {
                ShareWithMedia = false,
                ShareWithSchoolDivision = true,
                UnderstandsCanBeRevoked = true,
                UnderstandsGivenAnswers = true,
                GaveConsentVoluntarily = true,
                UnderstandsLimitedBySchool = true
            }
        };

        public static readonly GeneralRegistrationFormSubmission General = new GeneralRegistrationFormSubmission()
        {
            SubmittedBy = new FormSubmitter()
            {
                FirstName = "Your first name",
                LastName = "Your last name",
                ContactDetails = "Cell: 1234567890, Twitter: @Twitter"
            },
            School = new SelectedSchool()
            {
                DAN = "Find DAN and ID from /school in this API",
                Name = "Miskatonic High School"
            },
            Student = new Student()
            {
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
            Siblings = new SiblingInfo()
            {
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
            Grade = new GradeInfo()
            {
                Grade = "PK"
            },
            Contacts = new ContactsInfo()
            {
                Contacts = new List<Contact>()
                {
                    new Contact()
                    {
                        FirstName = "Parent's First Name",
                        LastName = "Parent's Last Name",
                        RelationshipToStudent = "Parent",
                        ContactPriority = 1,
                        LivesWithStudent = true,
                        SamePrimaryAddressAsStudent = true,
                        SameMailingAddressAsStudent = true,
                        ShouldRecieveMailAboutStudent = true,
                        HomePhone = "1234567890",
                        WorkPhone = "0987654321",
                        CellPhone = "3216540987",
                        AlternateContactInfo = "Facebook: MyFacebookName",
                        Employer = "Spacely Space Sprockets Inc",
                        EmailAddress = "email@domain.com",
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
                    new Contact()
                    {
                        FirstName = "Parent 2's First Name",
                        LastName = "Parent 2's Last Name",
                        RelationshipToStudent = "Parent",
                        ContactPriority = 2,
                        LivesWithStudent = true,
                        SamePrimaryAddressAsStudent = true,
                        SameMailingAddressAsStudent = true,
                        ShouldRecieveMailAboutStudent = true,
                        HomePhone = "1234567890",
                        WorkPhone = "0987654321",
                        CellPhone = "3216540987",
                        AlternateContactInfo = "Facebook: MyFacebookName",
                        Employer = "Spacely Space Sprockets Inc",
                        EmailAddress = "email@domain.com",
                        Note = "Not reachable during work day",
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
                    new Contact()
                    {
                        FirstName = "Emergency Contact First Name",
                        LastName = "Emergency Contact Last Name",
                        RelationshipToStudent = "Emergency Contact",
                        ContactPriority = 3,
                        LivesWithStudent = false,
                        SamePrimaryAddressAsStudent = false,
                        SameMailingAddressAsStudent = false,
                        ShouldRecieveMailAboutStudent = false,
                        HomePhone = string.Empty,
                        WorkPhone = "0987654321",
                        CellPhone = "3216540987",
                        AlternateContactInfo = string.Empty,
                        Employer = "Cogswell's Cogs",
                        EmailAddress = "email@domain.com",
                        Note = "Has no home phone",
                        PrimaryAddress = new Address()
                        {
                            Line1 = "321 Fake Street",
                            Line2 = string.Empty,
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
                    }
                }
            },
            BussingInfo = new BussingInfo()
            {
                RequiresBussing = true,
                LandDescription = "SE-12-20-33-W1",
                UseLandDescription = true,
                BussingAddress = new Address()
                {
                    Line1 = "PO Box 123",
                    Line2 = "",
                    City = "Cake Town",
                    Province = "SK",
                    PostalCode = "H0H 0H0",
                    Country = "Canada"
                }
            },
            FirstNationsInfo = new FirstNationsInfo()
            {
                IsDeclaringFirstNationsInfo = true,
                ResidesOnReserve = true,
                AboriginalStatus = "Registered/Treaty/Status Indian",
                BandName = "Band name here",
                ReserveName = "Reserve name residing on",
                ReserveHouse = "House number on reserve"
            },
            EALInfo = new EALInfo()
            {
                IsEAL = true,
                IsFirstCanadianSchool = true,
                EntryDateToCanada = DateTime.Now.AddYears(-2),
                EntryDateToCanadianSchool = DateTime.Now.AddYears(-1)
            },
            EnrollmentDetails = new EnrolmentInfo()
            {
                NoPreviousSchooling = false,
                TransferFromAnotherCountry = false,
                TransferFromAnotherProvince = false,
                ExchangeStudent = false,
                TransferFromHomeBased = false,
                TransferFromAnotherSaskSchool = false
            },
            Citizenship = new CitizenshipInfo()
            {
                CountryOfBirth = "Canada",
                Citizenship = "Canadian",
                LanguageSpokenAtHome = "English",
                PreviousCountry = string.Empty,
                ResidencyType = "Canadian Citizen"
            },
            Consent = new StudentConsentInfo() {
                ShareWithMedia = false,
                ShareWithSchoolDivision = true,
                UnderstandsCanBeRevoked = true,
                UnderstandsGivenAnswers = true,
                GaveConsentVoluntarily = true,
                UnderstandsLimitedBySchool = true
            }

        };
    }
}
