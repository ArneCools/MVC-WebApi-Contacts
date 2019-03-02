using System;
using System.Collections.Generic;
using System.Linq;
using Contacts.BL.Models;
using Contacts.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DAL
{
    public class EFRepository : IRepository
    {
        private ContactsDbContext ctx;

        public EFRepository()
        {
            ctx = new ContactsDbContext(false);
        }

        public IEnumerable<Category> ReadAllCategories()
        {
            return ctx.Categories.AsEnumerable();
        }

        public IEnumerable<Contact> ReadAllContacts(int? categoryId = null)
        {
            IEnumerable<Contact> contacts; 
            if (categoryId != null)
            {
                contacts = ctx.ContactCategories.Where(cc => cc.Category.CategoryID==categoryId)
                    .Select(cc => cc.Contact).Include(c => c.Adress);

            }
            else
            {
                contacts = ctx.Contacts.Include(c => c.Categories).ThenInclude(c => c.Category);
            }
            

            return contacts;
        }

        public Contact ReadContact(int id)
        {
            return ctx.Contacts.Find(id);
        }

        public void CreateContact(Contact contactToInstert)
        {
            ctx.Contacts.Add(contactToInstert);
            ctx.SaveChanges();
        }

        public void UpdateContact(Contact contactToUpdate)
        {
            Console.WriteLine("saving");
            ctx.Contacts.Update(contactToUpdate);
            ctx.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            ctx.Contacts.Remove(ReadContact(id));
            ctx.SaveChanges();
        }
    }
}