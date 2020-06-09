using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class Contact
    {
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string RelationshipToStudent { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "Priority must be at least 1.")]
        public int ContactPriority { get; set; }
        public bool LivesWithStudent { get; set; }
        public bool SamePrimaryAddressAsStudent { get; set; }
        public bool SameMailingAddressAsStudent { get; set; }
        public bool ShouldRecieveMailAboutStudent { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address MailingAddress { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string HomePhone { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string WorkPhone { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string CellPhone { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string AlternateContactInfo { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Employer { get; set; }
        [MaxLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string EmailAddress { get; set; }
        [MaxLength(1000, ErrorMessage = "{0} cannot exceed {1} characters")]
        public string Note { get; set; }

        public Contact()
        {
            this.ContactPriority = 1;
            this.PrimaryAddress = new Address();
            this.MailingAddress = new Address();
        }

        public bool IsEmpty()
        {
            if (
                string.IsNullOrEmpty(this.FirstName) &&
                string.IsNullOrEmpty(this.LastName) &&
                string.IsNullOrEmpty(this.RelationshipToStudent) &&
                string.IsNullOrEmpty(this.HomePhone) &&
                string.IsNullOrEmpty(this.WorkPhone) &&
                string.IsNullOrEmpty(this.CellPhone) &&
                string.IsNullOrEmpty(this.AlternateContactInfo) &&
                string.IsNullOrEmpty(this.Employer) &&
                string.IsNullOrEmpty(this.EmailAddress) &&
                this.PrimaryAddress.IsEmpty() &&
                this.MailingAddress.IsEmpty()
                )
            {
                return true;
            }

            return false;
        }
    }
}
