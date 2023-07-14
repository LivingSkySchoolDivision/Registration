using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class ContactsInfo : IValidatableObject
    {
        private const int _minContacts = 2;

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

            bool foundAtLeastOneParent = false;
            foreach(Contact contact in this.Contacts)
            {
                if (contact.IsParentOrGuardian) {
                    foundAtLeastOneParent = true;
                }

                if (string.IsNullOrEmpty(contact.RelationshipToStudent))
                {
                    errors.Add(new ValidationResult(
                        "Please specify a relationship for all contacts.", new[] { nameof(Contacts) }));
                }

                if (string.IsNullOrEmpty(contact.RelationshipToStudent))
                {
                    errors.Add(new ValidationResult(
                        "Please specify a relationship for all contacts.", new[] { nameof(Contacts) }));
                }
            }

            if (foundAtLeastOneParent == false) {
                errors.Add(new ValidationResult(
                    "Please provide at least one contact who is a parent or legal guardian of the child.", new[] { nameof(Contacts) }));                
            }

            return errors;
        }

    }
}
