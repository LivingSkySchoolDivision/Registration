using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class EALInfo
    {
        public bool IsEAL { get; set; }
        public bool IsFirstCanadianSchool { get; set; }
        public DateTime? EntryDateToCanada { get; set; }
        public DateTime? EntryDateToCanadianSchool { get; set; }
    }
}
