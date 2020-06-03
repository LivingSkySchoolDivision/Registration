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
                Communities = new List<string>() { "Cando" }, 
                WebsiteURL = "https://cando.lskysd.ca",
                EmailAddress = "cando@lskysd.ca",
                MailingAddress = new Address()
                {
                    Line1 = "Box 250",
                    PostalCode = "S0K 0V0",
                    City = "Cando",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    Line1 = "201 7th Street",
                    PostalCode = "S0K 0V0",
                    City = "Cando",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "5010213",
                HasGradeK = true,
                HasGrade1 = true,
                HasGrade2 = true,
                HasGrade3 = true,
                HasGrade4 = true,
                HasGrade5 = true,
                HasGrade6 = true,
                HasGrade7 = true,
                HasGrade8 = true,
                HasGrade9 = true,
                HasGrade10 = true,
                HasGrade11 = true,
                HasGrade12 = true
            },

            new School() {
                Name = "Hartley Clark School",
                PhoneNumber = "3068832183",
                Communities = new List<string>() { "Spiritwood" },
                WebsiteURL = "https://hces.lskysd.ca/",
                EmailAddress = "hclark@lskysd.ca",
                MailingAddress = new Address()
                {
                    PostalCode = "",
                    City = "Spiritwood",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    Line1 = "221 2nd Street West",
                    PostalCode = "S0J 2M0",
                    City = "Spiritwood",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "6410721",
                HasGradePK = true,
                HasGradeK = true,
                HasGrade1 = true,
                HasGrade2 = true,
                HasGrade3 = true,
                HasGrade4 = true,
                HasGrade5 = true,
                HasGrade6 = true,
                HasGrade7 = true
            },

            new School() {
                Name = "Spiritwood High School",
                PhoneNumber = "3068832282",
                Communities = new List<string>() { "Spiritwood" },
                WebsiteURL = "https://shs.lskysd.ca/",
                EmailAddress = "shs@lskysd.ca",
                MailingAddress = new Address()
                {
                    Line1 = "",
                    PostalCode = "",
                    City = "",
                    Province = "SK",
                    Country = "Canada"
                },
                PhysicalAddress = new Address()
                {
                    Line1 = "216 4th Street West",
                    PostalCode = "S0J 2M0",
                    City = "Spiritwood",
                    Province = "SK",
                    Country = "Canada"
                },
                DAN = "6410713",
                HasGrade7 = true,
                HasGrade8 = true,
                HasGrade9 = true,
                HasGrade10 = true,
                HasGrade11 = true,
                HasGrade12 = true
            },
            
        };
        #endregion

        public async Task<IEnumerable<School>> GetAll()
        {
            return _allSchools.ToList();
        }

        public async Task<IEnumerable<string>> GetAllCommunities()
        {
            List<string> returnMe = new List<string>();
            foreach(School s in _allSchools)
            {
                foreach(string c in s.Communities)
                {
                    if (!returnMe.Contains(c))
                    {
                        returnMe.Add(c);
                    }
                }
            }

            return returnMe.OrderBy(c => c);
        }

        public async Task<IEnumerable<School>> GetForCommunity(string Community)
        {
            return _allSchools.Where(s => s.Communities.Contains(Community)).ToList();
        }


    }
}
