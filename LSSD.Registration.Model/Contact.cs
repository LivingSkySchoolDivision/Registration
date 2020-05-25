using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string RelationshipToStudent { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "Priority must be at least 1.")]
        public int ContactPriority { get; set; }
        public bool LivesWithStudent { get; set; }
        public bool SamePrimaryAddressAsStudent { get; set; }
        public bool SameMailingAddressAsStudent { get; set; }
        public bool ShouldRecieveMailAboutStudent { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address MailingAddress { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string AlternateContactInfo { get; set; }
        public string Employer { get; set; }
        public string EmailAddress { get; set; }

        public Contact()
        {
            this.ContactPriority = 1;
            this.PrimaryAddress = new Address();
            this.MailingAddress = new Address();
        }
    }
}
