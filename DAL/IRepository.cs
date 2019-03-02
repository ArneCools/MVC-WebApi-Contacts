using System.Collections.Generic;
using Contacts.BL.Models;

namespace Contacts.DAL
{
    public interface IRepository
    {
        IEnumerable<Category> ReadAllCategories();
        IEnumerable<Contact> ReadAllContacts(int? categoryId = null);
        Contact ReadContact(int id);
        void CreateContact(Contact contactToInstert);
        void UpdateContact(Contact contactToUpdate);
        void DeleteContact(int id);
    }
}