using System;
using System.Collections.Generic;
using Contacts.BL.Models;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace Contacts.DAL.EF
{
    public class ContactsDBInitializer
    {
        private static bool hasRun = false;
        public static void Initialize(ContactsDbContext ctx, bool dropCreate)
        {
            if (!hasRun)
            {
                if (dropCreate)
                {
                    ctx.Database.EnsureDeleted();
                }

                if (ctx.Database.EnsureCreated())
                {
                    Seed(ctx);
                }
            }
        }

        private static void Seed(ContactsDbContext ctx)
        {
            Category cat1 = new Category()
            {
                Description = "Family",
            };
            Category cat2 = new Category()
            {
                Description = "Friends",
            };
            Category cat3 = new Category()
            {
                Description = "School",
            };
            Category cat4 = new Category()
            {
                Description = "Sports",
            };
            ctx.Categories.Add(cat1);
            ctx.Categories.Add(cat2);
            ctx.Categories.Add(cat3);
            ctx.Categories.Add(cat4);
            
            Contact ct1 = new Contact()
            {
                Name = "Verstraeten Micheline",
                Adress = new Address()
                {
                    City = "Antwerpen",
                    StreetAndNumber = "Antwerpsestraat 5",
                    Zipcode = 2000
                },
                Gender = Gender.Female,
                Blocked = false,
                Birthday = new DateTime(1978,8,30),
                Phone = "495/11.22.33",
                Mobile = "03/123.45.67",
            };
            ctx.Contacts.Add(ct1);
            
            
            Contact ct2 = new Contact()
            {
                Name = "Bogaerts Sven",
                Adress = new Address()
                {
                    City = "Brussel",
                    StreetAndNumber = "Brusselsestraat 10",
                    Zipcode = 500
                },
                Phone = "495/11.22.33",
                Mobile = "03/123.45.67",
                Gender = Gender.Male,
                Blocked = false,
                Birthday = new DateTime(1975,4,12),
            };
            ctx.Contacts.Add(ct2);
            
            
            Contact ct3 = new Contact()
            {
                Name = "Vlaeminckx Dieter",
                Adress = new Address()
                {
                    City = "Gent",
                    StreetAndNumber = "Gentsestraat 95",
                    Zipcode = 9000
                },
                Mobile = "03/123.45.67",
                Gender = Gender.Male,
                Blocked = true,
                Birthday = new DateTime(1980,12,8),
            };
            ctx.Contacts.Add(ct3);
            
            Contact ct4 = new Contact()
            {
                Name = "Vlaeminckx Jef",
                Adress = new Address()
                {
                    City = "Gent",
                    StreetAndNumber = "Gentsestraat 95",
                    Zipcode = 9000
                },
                Phone = "09/99.88.77",
                Gender = Gender.Male,
                Blocked = true,
                Birthday = new DateTime(1952,10,21),
            };


            ctx.ContactCategories.Add(new ContactCategory() {Category = cat1, Contact = ct1});
            ctx.ContactCategories.Add(new ContactCategory() {Category = cat1, Contact = ct2});
            ctx.ContactCategories.Add(new ContactCategory() {Category = cat3, Contact = ct2});
            ctx.ContactCategories.Add(new ContactCategory() {Category = cat4, Contact = ct2});
            ctx.ContactCategories.Add(new ContactCategory() {Category = cat1, Contact = ct3});
            ctx.ContactCategories.Add(new ContactCategory() {Category = cat4, Contact = ct3});
            ctx.ContactCategories.Add(new ContactCategory() {Category = cat1, Contact = ct4});
            

            ctx.SaveChanges();

        }
    }
}