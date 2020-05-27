using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class CitizenshipInfo
    {
        public int Id { get; set; }
        [Required]
        public string CountryOfBirth { get; set; }
        [Required]
        public string Citizenship { get; set; }
        [Required]
        public string LanguageSpokenAtHome { get; set; }
        public string PreviousCountry { get; set; }
        [Required]
        public string ResidencyType { get; set; }
        
    }
}
