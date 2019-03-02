using System.ComponentModel.DataAnnotations;

namespace Contacts.BL.Models
{
    public class ContactCategory
    {
        public int Id { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }
        [Required]
        public virtual Category Category { get; set; }
    }
}