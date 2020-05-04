using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class LandDescription
    {
        public int Id { get; set; }
        public string Quarter { get; set; }
        public string Section { get; set; }
        public string Township { get; set; }
        public string Range { get; set; }
        public string Meridian { get; set; }
        public string RiverLot { get; set; }

        public override string ToString()
        {
            if (
                (string.IsNullOrEmpty(Quarter)) &&
                (string.IsNullOrEmpty(Section)) &&
                (string.IsNullOrEmpty(Township)) &&
                (string.IsNullOrEmpty(Range)) &&
                (string.IsNullOrEmpty(Meridian))
                )
            {
                return string.Empty;
            }
            else
            {
                return this.Quarter + "-" + this.Section + "-" + this.Township + "-" + this.Range + "-W" + this.Meridian;
            }
        }
    }
}
