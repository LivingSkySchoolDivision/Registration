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


        public static readonly List<string> AvailableTreatyStatus = new List<string>()
        {
            "Registered/Treaty/Status Indian",
            "Non-status Indian",
            "Métis",
            "Inuit/Inuk"
        };

        public static readonly List<string> AvailableGenders = new List<string>()
        {
            "Unspecified",
            "Male",
            "Female"
        };

        public static readonly List<string> AvailableResidencyTypes = new List<string>()
        {
            "Canadian Citizen",
            "Immigrant",
            "Temporary Resident",
            "Refugee",
            "Permanent Resident"
        };

        public static readonly List<string> AvailableGrades = new List<string>()
        {
            Language_Grade_PK,
            Language_Grade_K,
            Language_Grade_1,
            Language_Grade_2,
            Language_Grade_3,
            Language_Grade_4,
            Language_Grade_5,
            Language_Grade_6,
            Language_Grade_7,
            Language_Grade_8,
            Language_Grade_9,
            Language_Grade_10,
            Language_Grade_11,
            Language_Grade_12
        };

        public const string Language_Grade_PK = "Pre-Kindergarten";
        public const string Language_Grade_K = "Kindergarten";
        public const string Language_Grade_1 = "Grade 1";
        public const string Language_Grade_2 = "Grade 2";
        public const string Language_Grade_3 = "Grade 3";
        public const string Language_Grade_4 = "Grade 4";
        public const string Language_Grade_5 = "Grade 5";
        public const string Language_Grade_6 = "Grade 6";
        public const string Language_Grade_7 = "Grade 7";
        public const string Language_Grade_8 = "Grade 8";
        public const string Language_Grade_9 = "Grade 9";
        public const string Language_Grade_10 = "Grade 10";
        public const string Language_Grade_11 = "Grade 11";
        public const string Language_Grade_12 = "Grade 12";
    }
}
