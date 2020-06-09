using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Address
    {
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Line1 { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Line2 { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string City { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Province { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string PostalCode { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Country { get; set; }

        public Address()
        {
            this.Province = FormDefaults.Province;
            this.Country = FormDefaults.Country;
        }
                
        public bool IsValidMailing()
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

        public bool IsValidCivic()
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

        public bool IsEmpty()
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
