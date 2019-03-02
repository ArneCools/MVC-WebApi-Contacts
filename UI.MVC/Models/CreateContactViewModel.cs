using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contacts.BL.Models;

namespace Contacts.UI.MVC.Models
{
    public class CreateContactViewModel
    {
        [Required(ErrorMessage = "Het veld naam moet worden ingevuld")]
        [StringLength(30,ErrorMessage = "Het veld name moet een tekenreeks met een maximumlengte van 30 zijn")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@".+(\d+)")]
        public string StreetAndNumber { get; set; }
        [Range(1000,9999)]
        public short Zipcode { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool Blocked { get; set; }
    }
}