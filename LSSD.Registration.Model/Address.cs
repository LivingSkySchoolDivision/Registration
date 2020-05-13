using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
        public string UnitNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address()
        {
            this.Province = FormDefaults.Province;
            this.Country = FormDefaults.Country;
        }

        public string Line1 { 
            get {
                StringBuilder returnMe = new StringBuilder();

                if (!string.IsNullOrEmpty(UnitNumber))
                {
                    returnMe.Append(UnitNumber + " ");
                }

                if (!string.IsNullOrEmpty(HouseNumber))
                {
                    returnMe.Append(HouseNumber + " ");
                }

                if (!string.IsNullOrEmpty(Street))
                {
                    returnMe.Append(Street);
                }

                return returnMe.ToString().Trim();
            } 
        }

        public string Line2
        {
            get
            {
                StringBuilder returnMe = new StringBuilder();

                if (!string.IsNullOrEmpty(City))
                {
                    returnMe.Append(City + " ");
                }

                if (!string.IsNullOrEmpty(Province))
                {
                    returnMe.Append(Province + " ");
                }

                if (!string.IsNullOrEmpty(PostalCode))
                {
                    returnMe.Append(PostalCode);
                }

                return returnMe.ToString().Trim();
            }
        }

        public bool IsValidMailing { 
            get
            {
                if (
                    !string.IsNullOrEmpty(this.Country) &&
                    !string.IsNullOrEmpty(this.Province) &&
                    !string.IsNullOrEmpty(this.City) &&
                    !string.IsNullOrEmpty(this.Street) &&
                    !string.IsNullOrEmpty(this.PostalCode)
                    ) {
                    return true;
                }
                
                return false;
            } 
        }

    }
}
