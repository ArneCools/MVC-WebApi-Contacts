using System;
using System.Collections.Generic;
using Contacts.BL.Models;

namespace Contacts.BL
{
    public interface IContactManager
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Contact> GetAllContacts(OrderByFieldName sortBy);
        IEnumerable<Contact> GetAllContactsForACategory(int categoryId);
        Contact GetContact(int id);
        void AddContact(string name, string streetAndNumber, short zipCode, string city, Gender gender,
            DateTime birthDay, string phone, string mobile);
        void ChangeContact(Contact contactToChange);
        void RemoveContact(int id);

    }
}