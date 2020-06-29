using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class EnrolmentInfo
    {
        public bool NoPreviousSchooling { get; set; }
        public bool TransferFromAnotherProvince { get; set; }
        public bool ExchangeStudent { get; set; }
        public bool TransferFromAnotherSaskSchool { get; set; }
        public bool TransferFromHomeBased { get; set; }
        public bool TransferFromAnotherCountry { get; set; }

        public string SchoolTransferredFrom { get;set; }
        public string ProvinceTransferredFrom { get;set; }
        public string CountryTransferredFrom { get; set; }
        public string ExchangeStudentFrom { get; set; }
    }
}
