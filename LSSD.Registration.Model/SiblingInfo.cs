using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class SiblingInfo
    {
        public List<Sibling> Siblings { get; set; }

        public SiblingInfo()
        {
            this.Siblings = new List<Sibling>();
        }
    }
}
