using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSD.Registration.PublicAPI
{
    public static class InputValidators
    {
        public static bool IsValidGUID(string input)
        {
            return Guid.TryParse(input, out Guid x);
        }
    }
}
