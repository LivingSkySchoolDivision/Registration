using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address()
        {
            this.Country = FormDefaults.Country;
        }
                
        public bool IsValidMailing
        {
            get
            {
                if (
                    !string.IsNullOrEmpty(this.Country) &&
                    !string.IsNullOrEmpty(this.Province) &&
                    !string.IsNullOrEmpty(this.City) &&
                    (!string.IsNullOrEmpty(this.Line1) || !string.IsNullOrEmpty(this.Line2)) &&
                    !string.IsNullOrEmpty(this.PostalCode)
                    )
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsValidCivic
        {
            get
            {
                if (
                    !string.IsNullOrEmpty(this.Country) &&
                    !string.IsNullOrEmpty(this.Province) &&
                    !string.IsNullOrEmpty(this.City) &&
                    (!string.IsNullOrEmpty(this.Line1) || !string.IsNullOrEmpty(this.Line2))
                    )
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (
                    string.IsNullOrEmpty(this.Line1) &&
                    string.IsNullOrEmpty(this.City) &&
                    string.IsNullOrEmpty(this.PostalCode) &&
                    string.IsNullOrEmpty(this.Line2)
                    );
            }
        }

    }
}
