using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public enum TreatyStatus
    {
        Treaty,
        Metis,
        [Display(Name = "Non-Status Indian")]
        NonStatusIndian,
        Inuk
    }
}
