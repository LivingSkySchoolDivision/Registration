using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace LSSD.Registration.Model
{
    public enum ResidencyType
    {
        [Description("Canadian Citizen")]
        CanadianCitizen,
        Immigrant,
        [Description("Temporary Resident")]
        TemporaryResident,
        Refugee,
        [Description("Permanent Resident")]
        PermanentResident
    }
}
