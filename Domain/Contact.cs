using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;

namespace Contacts.BL.Models
{
    public class Contact : IValidatableObject
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Het veld naam moet worden ingevuld")]
        [StringLength(30,ErrorMessage = "Het veld name moet een tekenreeks met een maximumlengte van 30 zijn")]
        public string Name { get; set; }
        public virtual Address Adress { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool Blocked { get; set; }
        public virtual List<ContactCategory> Categories { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Phone) && String.IsNullOrEmpty(Mobile))
            {
                string errorMessage = "Phone of/en mobile moet ingevuld zijn";
                validationResults.Add(new ValidationResult(errorMessage,new string[] {"Phone","Mobile"}));
            }

            Validator.TryValidateObject(Adress, new ValidationContext(Adress), validationResults,true);
            

            return validationResults;

        }
    }
}