using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public enum BussingProgram
    {
        AM,
        PM,
        [Display(Name = "Full Day")]
        FullDay
    }
}
