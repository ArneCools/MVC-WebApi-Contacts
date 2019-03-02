using System;
using Contacts.BL.Models;

namespace Contacts.UI.CA
{
    public static class ContactExtensions
    {
        public static string PrintSummary(this Contact contact)
        {
            return string.Format("ID: {0,-8}- {1} ({2:d})", String.Format("{0} {1}",contact.PersonId, contact.Blocked ? "(b)" : ""), contact.Name, contact.Birthday);
        }

        public static string PrintShortInfo(this Contact contact)
        {
            return string.Format("Contact {0}, woonachtig te {1}, is een {2}", contact.Name, contact.Adress.City,
                contact.Gender);
        }

        public static string printLonginfo(this Contact contact)
        {
            return string.Format("{0} - {1} ({2}) ({3}) woonachtig te {4}, {5} {6}", contact.PersonId, contact.Name,
                contact.Phone, contact.Mobile, contact.Adress.StreetAndNumber, contact.Adress.Zipcode,
                contact.Adress.City);
        }

        public static string PrintCategory(this Category category)
        {
            return string.Format("{0} ({1}", category.Description, category.CategoryID +")");
        }
        
        
    }
}