using System;
using System.Collections.Generic;
using Contacts.BL.Models;

namespace Contacts.UI.MVC.Models.dto
{
    public class ContactDto
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Address Adress { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool Blocked { get; set; }
    }
}