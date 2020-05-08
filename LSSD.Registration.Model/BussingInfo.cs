using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class BussingInfo
    {
        [Required]
        public bool RequiresBussing { get; set; }
        
        [Required]
        public bool WeighsMoreThan18kg { get; set; }

        public string LandDescription { get; set; }
        public Address BussingAddress { get; set; }

    }
}
