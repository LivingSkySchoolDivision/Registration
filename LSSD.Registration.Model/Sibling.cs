using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Sibling
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SaskLearningNumber { get; set; }
        public string StudentNumber { get; set; }
        public string SchoolAttending { get; set; }
        public int Age { get; set; }
        public string Relationship { get; set; }
    }
}
