using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class ContactsInfo : IValidatableObject
    {
        private const int _minContacts = 1;

        public List<Contact> Contacts { get; set; }


        public ContactsInfo()
        {
            this.Contacts = new List<Contact>();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.Contacts.Count < _minContacts)
            {
                errors.Add(new ValidationResult(
                    "Please provide at least " + _minContacts + " contact(s).", new[] { nameof(Contacts) }));
            }

            return errors;
        }

    }
}
