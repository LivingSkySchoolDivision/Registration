using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class FirstNationsInfo
    {
        public int Id { get; set; }
        public bool ResidesOnReserve { get; set; }
        public TreatyStatus TreatyStatus { get; set; }
        public string BandName { get; set; }
        public string ReserveName { get; set; }
        public string ReserveHouseNumber { get; set; }
        public string BandAffiliationCode { get; set; }
    }
}
