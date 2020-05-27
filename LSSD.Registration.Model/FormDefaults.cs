using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.Model
{
    public static class FormDefaults
    {
        public const string Province = "SK";
        public const string ProvinceFull = "Saskatchewan";
        public const string Country = "Canada";
        public const string Language = "English";
        public const string Citizenship = "Canadian";


        public static List<string> AvailableTreatyStatus = new List<string>()
        {
            "Registered/Treaty/Status Indian",
            "Non-status Indian",
            "Métis",
            "Inuit/Inuk"
        };

        public static List<string> AvailableGenders = new List<string>()
        {
            "Unspecified",
            "Male",
            "Female"
        };
    }
}
