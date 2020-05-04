using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class EALInfo
    {
        public int Id { get; set; }
        public DateTime EntryDateToCanada { get; set; }
        /// <summary>
        /// Entry datae to Canadian School
        /// </summary>
        public DateTime FirstCanadianSchoolDate { get; set; }
        public bool  IsFirstCanadianSchool { get; set; }
        ResidencyType ResidencyType { get; set; }

        public string BirthCountry { get; set; }

        /// <summary>
        /// Country of Origin
        /// </summary>
        public string LastCountryResidedIn { get; set; }

        public string PreviousProvince { get; set; }
        public string PreviousCountry { get; set; }
    }
}
