using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class FirstNationsInfo
    {
        public bool IsDeclaringFirstNationsInfo { get; set; }
        public bool ResidesOnReserve { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string AboriginalStatus { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string BandName { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string ReserveName { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string ReserveHouse { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string StatusNumber { get; set; }
    }
}
