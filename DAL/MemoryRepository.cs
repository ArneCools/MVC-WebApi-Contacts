using System;
using System.Collections.Generic;
using Contacts.BL.Models;

namespace Contacts.DAL
{
    public class MemoryRepository : IRepository
    {
        /*
        private List<Contact> Contacts = new List<Contact>();
        private List<Category> Categories = new List<Category>();

        public MemoryRepository()
        {
            SeedCategories();
            SeedContacts();
        }

        private void SeedContacts()
        {
            Contact ct1 = new Contact()
            {
                PersonId = 1,
                Name = "Verstraeten Micheline",
                Adress = new Address()
                {
                    AddressId = 1,
                    City = "Antwerpen",
                    StreetAndNumber = "Antwerpsestraat 5",
                    Zipcode = 2000
                },
                Gender = Gender.Female,
                Blocked = false,
                Birthday = new DateTime(1978,8,30),
                Phone = "495/11.22.33",
                Mobile = "03/123.45.67",
                Categories = new List<Category>()
            };
            ct1.Adress.Contact = ct1;
            ct1.Categories.Add(Categories.Find(c => c.CategoryID == 1));
            Category cat1 = Categories.Find(c => c.CategoryID == 1);
               cat1.Contacts.Add(ct1);
            Contacts.Add(ct1);
            
            
            Contact ct2 = new Contact()
            {
                PersonId = 2,
                Name = "Bogaerts Sven",
                Adress = new Address()
                {
                    AddressId = 2,
                    City = "Brussel",
                    StreetAndNumber = "Brusselsestraat 10",
                    Zipcode = 500
                },
                Phone = "495/11.22.33",
                Mobile = "03/123.45.67",
                Gender = Gender.Male,
                Blocked = false,
                Birthday = new DateTime(1975,4,12),
                Categories = new List<Category>()
            };
            ct2.Adress.Contact = ct2;
            ct2.Categories.Add(Categories.Find(c => c.CategoryID == 1));
            ct2.Categories.Add(Categories.Find(c => c.CategoryID == 4));
            ct2.Categories.Add(Categories.Find(c => c.CategoryID == 3));
            Categories.Find(c => c.CategoryID == 1).Contacts.Add(ct2);
            Categories.Find(c => c.CategoryID == 4).Contacts.Add(ct2);
            Categories.Find(c => c.CategoryID == 3).Contacts.Add(ct2);
            Contacts.Add(ct2);
            
            
            Contact ct3 = new Contact()
            {
                PersonId = 3,
                Name = "Vlaeminckx Dieter",
                Adress = new Address()
                {
                    AddressId = 3,
                    City = "Gent",
                    StreetAndNumber = "Gentsestraat 95",
                    Zipcode = 9000
                },
                Phone = "495/11.22.33",
                Mobile = "03/123.45.67",
                Gender = Gender.Male,
                Blocked = true,
                Birthday = new DateTime(1980,12,8),
                Categories = new List<Category>()
            };
            ct3.Adress.Contact = ct3;
            ct3.Categories.Add(Categories.Find(c => c.CategoryID == 1));
            ct3.Categories.Add(Categories.Find(c => c.CategoryID == 4));
            Categories.Find(c => c.CategoryID == 1).Contacts.Add(ct3);
            Categories.Find(c => c.CategoryID == 4).Contacts.Add(ct3);
            Contacts.Add(ct3);
            
            
        }

        private void SeedCategories()
        {
            Categories.Add(new Category()
            {
                CategoryID = 1,
                Description = "Family",
                Contacts = new List<Contact>()
            });
            Categories.Add(new Category()
            {
                CategoryID = 2,
                Description = "Friends",
                Contacts = new List<Contact>()
            });
            Categories.Add(new Category()
            {
                CategoryID = 3,
                Description = "School",
                Contacts = new List<Contact>()
            });
            Categories.Add(new Category()
            {
                CategoryID = 4,
                Description = "Sports",
                Contacts = new List<Contact>()
            });
        }


        public IEnumerable<Category> ReadAllCategories()
        {
            return Categories;
        }

        public IEnumerable<Contact> ReadAllContacts(int? categoryId = null)
        {
            if (categoryId != null)
            {
                return Categories.Find(c => c.CategoryID == categoryId).Contacts;
            }

            return Contacts;
        }

        public Contact ReadContact(int id)
        {
            return Contacts.Find(c => c.PersonId == id);
        }

        public void CreateContact(Contact contactToInstert)
        {
            int nieuweId = 0;
            if (Contacts.Count == 0)
            {
                nieuweId = 1;
            }
            else
            {
                foreach (Contact contact in Contacts)
                {
                    if (contact.PersonId >= nieuweId)
                    {
                        nieuweId = contact.PersonId + 1;
                    }
                }
            }

            contactToInstert.PersonId = nieuweId;
            Contacts.Add(contactToInstert);
            

        }

        public void UpdateContact(Contact contactToUpdate)
        {
            //nothing to do since classes are a reference type.
        }

        public void DeleteContact(int id)
        {
            Contact contactFound = Contacts.Find(c => c.PersonId == id);
            if (contactFound == null)
            {
                throw new InvalidOperationException(String.Format("Contact met id {0} is  niet gevonden", id));
            }

            Contacts.Remove(contactFound);
            
        }
        */
        public IEnumerable<Category> ReadAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> ReadAllContacts(int? categoryId = null)
        {
            throw new NotImplementedException();
        }

        public Contact ReadContact(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateContact(Contact contactToInstert)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contactToUpdate)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }
    }
    
}