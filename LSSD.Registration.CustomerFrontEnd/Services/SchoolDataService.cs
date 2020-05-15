using LSSD.Registration.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.CustomerFrontEnd.Services
{
    public class SchoolDataService
    {
        // Replace this with an API call in the future
        #region Set up a static list of schools for testing
        List<School> _allSchools = new List<School>()
        {
            new School() {
                Name = "Cando Community School",
                PhoneNumber = "3069373934",
                Community = "Cando",
                WebsiteURL = "https://cando.lskysd.ca",
                EmailAddress = "cando@lskysd.ca",
                MailingAddress = new Address()
                {
                    UnitNumber = "",
                    HouseNumber = "",
                    Street = "Box 250",
                    PostalCode = "S0K 0V0",
                    City = "Cando",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    UnitNumber = "",
                    HouseNumber = "201",
                    Street = "7th Street",
                    PostalCode = "S0K 0V0",
                    City = "Cando",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "",
                GradesOffered = "K-12",
                OffersPreK = false,
                OffersKTo9 = true,
                OffersHighSchool = true
            },

            new School() {
                Name = "Hartley Clark School",
                PhoneNumber = "3068832183",
                Community = "Spiritwood",
                WebsiteURL = "https://hces.lskysd.ca/",
                EmailAddress = "hclark@lskysd.ca",
                MailingAddress = new Address()
                {
                    UnitNumber = "",
                    HouseNumber = "",
                    Street = "",
                    PostalCode = "",
                    City = "Spiritwood",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    UnitNumber = "",
                    HouseNumber = "221 ",
                    Street = "2nd Street West",
                    PostalCode = "S0J 2M0",
                    City = "Spiritwood",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "",
                GradesOffered = "PK-6",
                OffersPreK = true,
                OffersKTo9 = true,
                OffersHighSchool = false
            },

            new School() {
                Name = "Spiritwood High School",
                PhoneNumber = "3068832282",
                Community = "Spiritwood",
                WebsiteURL = "https://shs.lskysd.ca/",
                EmailAddress = "shs@lskysd.ca",
                MailingAddress = new Address()
                {
                    UnitNumber = "",
                    HouseNumber = "",
                    Street = "",
                    PostalCode = "",
                    City = "",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    UnitNumber = "",
                    HouseNumber = "216",
                    Street = "4th Street West",
                    PostalCode = "S0J 2M0",
                    City = "Spiritwood",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "",
                GradesOffered = "7-12",
                OffersPreK = false,
                OffersKTo9 = false,
                OffersHighSchool = true
            },
            /*
            new School() {
                Name = "",
                PhoneNumber = "",
                Community = "",
                WebsiteURL = "",
                EmailAddress = "",
                MailingAddress = new Address()
                {
                    AddressType = "Mailing",
                    UnitNumber = "",
                    HouseNumber = "",
                    Street = "",
                    PostalCode = "",
                    City = "",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    AddressType = "Physical",
                    UnitNumber = "",
                    HouseNumber = "",
                    Street = "Box 250",
                    PostalCode = "S0K 0V0",
                    City = "Cando",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "",
                OffersPreK = false,
                OffersKTo9 = false,
                OffersHighSchool = false
            },*/
        };
        #endregion

        public async Task<IEnumerable<School>> GetAll()
        {
            return _allSchools.ToList();
        }

        public async Task<IEnumerable<string>> GetAllCommunities()
        {
            return _allSchools.Select(s => s.Community).Distinct();
        }

        public async Task<IEnumerable<School>> GetForCommunity(string Community)
        {
            return _allSchools.Where(s => s.Community == Community).ToList();
        }


    }
}
