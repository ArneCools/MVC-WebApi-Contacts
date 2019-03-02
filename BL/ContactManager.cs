using System;
using System.Collections.Generic;
using Contacts.BL.Models;
using Contacts.DAL;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Contacts.BL
{
    public class ContactManager : IContactManager
    {
        private readonly IRepository contactRepository;

        public ContactManager()
        {
            contactRepository = new EFRepository();
        }


        public IEnumerable<Category> GetAllCategories()
        {
            return contactRepository.ReadAllCategories();
        }

        public IEnumerable<Contact> GetAllContacts(OrderByFieldName sortBy = OrderByFieldName.Id)
        {
            
            return SortContactBy(contactRepository.ReadAllContacts(),sortBy);
        }
        
        public IEnumerable<Contact> GetAllContactsForACategory(int categoryId)
        {
            return SortContactBy(contactRepository.ReadAllContacts(categoryId));
        }

        public Contact GetContact(int id)
        {
            return contactRepository.ReadContact(id);
        }

        public void AddContact(string name, string streetAndNumber, short zipCode, string city, Gender gender, DateTime birthDay,
            string phone, string mobile)
        {
            Contact contact = new Contact()
            {
                Name = name,
                Adress = new Address()
                {
                    City = city,
                    Zipcode = zipCode,
                    StreetAndNumber = streetAndNumber
                },
                Birthday = birthDay,
                Gender = gender,
                Phone = phone,
                Mobile = mobile,
            };
            ValidateContact(contact);
            contactRepository.CreateContact(contact);
        }

        public void ChangeContact(Contact contactToChange)
        {
            ValidateContact(contactToChange);
            contactRepository.UpdateContact(contactToChange);
        }

        public void RemoveContact(int id)
        {
            contactRepository.DeleteContact(id);
        }
        
        
        private IEnumerable<Contact> SortContactBy(IEnumerable<Contact> contacts, OrderByFieldName sortBy = OrderByFieldName.Id)
        {
            List<Contact> contactsList = contacts.ToList();

            if (sortBy == OrderByFieldName.Id)
            {
                contactsList.Sort(delegate(Contact contact1, Contact contact2)
                    {
                        return contact1.PersonId.CompareTo(contact2.PersonId);
                    });
            }
            else
            {
                contactsList.Sort(delegate(Contact contact1, Contact contact2)
                {
                    return contact1.Name.CompareTo(contact2.Name);
                });
            }

            return contactsList;

        }


        private void ValidateContact(Contact contact)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(contact, new ValidationContext(contact), errors, true);
            string errorString = "";
            foreach (ValidationResult error in errors)
            {
                errorString += error.ErrorMessage+"\n";
            }

            if (errors.Count > 0)
            {
                errorString.Substring(0, errorString.Length - 2);
                throw new ValidationException(errorString);
            }
        } 
    }
}