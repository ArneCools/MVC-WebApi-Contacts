using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Contacts.BL.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [RegularExpression(@".+(\d+)")]
        public string StreetAndNumber { get; set; }
        [Range(1000,9999)]
        public short Zipcode { get; set; }
        public string City { get; set; }
    }
}