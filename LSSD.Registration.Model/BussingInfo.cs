using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class BussingInfo
    {
        public bool WeighsMoreThan18kg { get; set; }
        public LandDescription LandDescription { get; set; }
        public Address BussingAddress { get; set; }

    }
}
