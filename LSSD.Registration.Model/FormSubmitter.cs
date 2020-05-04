using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class FormSubmitter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string EmailAddress { get; set; }
    }
}
