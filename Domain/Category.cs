using System.Collections.Generic;

namespace Contacts.BL.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public virtual List<ContactCategory> Contacts { get; set; }
    }
}