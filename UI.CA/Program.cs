using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Contacts.BL;
using Contacts.BL.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contacts.UI.CA
{
    class Program
    {
        private readonly IContactManager ContactManager = new ContactManager();
        private Service srv = new Service();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            keuzeMenu();
            
        }

        private void keuzeMenu()
        {
            int keuze;
            bool validInput;
            bool exit = false;
            do
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("=== CONTACTEN ADMINISTRATIE SYSTEEM ===");
                Console.WriteLine("=======================================");
                Console.WriteLine("1) Toon alle contacten");
                Console.WriteLine("2) Zoek contacten op categorie");
                Console.WriteLine("3) Wijzig naam van een bestaand contact");
                Console.WriteLine("4) Verwijder contact");
                Console.WriteLine("5) Maak contact aan");
                Console.WriteLine("0) Verlaat systeem");
                Console.Write("Maak uw keuze: ");
                validInput = Int32.TryParse(Console.ReadLine(), out keuze);
                if (!validInput || keuze <  0 || keuze > 5)
                {
                    Console.WriteLine("Foute invoer, probeer opnieuw");
                }

                if (validInput)
                {
                    switch (keuze)
                    {
                        case 1:
                            ShowAllContacts();
                            break;
                        case 2:
                            SearchOnCategory();
                            break;
                        case 3:
                            ChangeContactName();
                            break;
                        case 4:
                            DeleteContact();
                            break;
                        case 5:
                            CreateContact();
                            break;
                        case 0:
                            exit = true;
                            break;
                    }
                }
            
                
            } while (!exit);
            
          
        }

        private void CreateContact()
        {
            try
            {
                string naam;
                DateTime geboortedatum;
                string straat;
                short postcode;
                string stad;
                Gender geslacht;
                string gsm;
                string telefoon;
                Console.WriteLine("-> Geef de volgende gegevens in voor het nieuwe contact:");
                Console.Write("Naam: ");
                naam = Console.ReadLine();
                Console.Write("Geboortedatum (dd-mm-yy): ");
                string[] geboortedatumArr =  Console.ReadLine().Split('-');
                geboortedatum = new DateTime(Int32.Parse(geboortedatumArr[2]),Int32.Parse(geboortedatumArr[1]),Int32.Parse(geboortedatumArr[0]));
                Console.Write("Straat en huisnummer: ");
                straat = Console.ReadLine();
                Console.Write("postcode: ");
                postcode = short.Parse(Console.ReadLine());
                Console.Write("Stad/Gemeente: ");
                stad = Console.ReadLine();
                Console.Write("Geslacht: ");
                string geslachtStr = Console.ReadLine();
                geslacht = geslachtStr.ToLower().Equals("m") ? Gender.Male : Gender.Female;
                Console.Write("GSM: ");
                gsm = Console.ReadLine();
                Console.Write("Telefoon: ");
                telefoon = Console.ReadLine();

               ContactManager.AddContact(naam,straat,postcode,stad,geslacht,geboortedatum,telefoon,gsm);
                Console.WriteLine("Contact '" + naam + "', geboren op " + geboortedatum + " is toegevoegd");


                //ContactManager.AddContact("Arne", "De Busseltjes 2", 2275, "Poederlee", Gender.Male,
                //  new DateTime(1996, 09, 29), "", "");
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void DeleteContact()
        {
            
            foreach (Contact contact in ContactManager.GetAllContacts(OrderByFieldName.Id))
            {
                Console.WriteLine(contact.printLonginfo());
            }

            Console.Write("Welk contact (id) wenst u te verwijderen?");
            int keuze;
            Console.Write("Maak uw keuze: ");
            bool valid = Int32.TryParse(Console.ReadLine(), out keuze);
            if (!valid)
            {
                Console.WriteLine("Ongeldige waarde");
                return;
            }

            try
            {
                //ContactManager.RemoveContact(keuze);
                srv.DeleteContact(keuze);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Contact met id {0} niet gevonden",keuze);
            }
            
            
        }

        private void ChangeContactName()
        {
            int keuze;
            
            Console.WriteLine("=> Kies eerste één van onderstaande contacten:");
            foreach (Contact contact in ContactManager.GetAllContacts(OrderByFieldName.Id))
            {
                Console.WriteLine("{0} - {1}",contact.PersonId,contact.Name);
            }
            Console.Write("Van welk contact (id) wenst u de naam te wijzigen?");
            Int32.TryParse(Console.ReadLine(), out keuze);
            Contact contactToChange = ContactManager.GetContact(keuze);
            if (contactToChange == null)
            {
                Console.WriteLine("Contact bestaat niet");
                return;
            }

            Console.Write("Geef de nieuwe naam in: ");
            string naam = Console.ReadLine();
            contactToChange.Name = naam;
            ContactManager.ChangeContact(contactToChange);
        }

        private void SearchOnCategory()
        {
            int keuze;
            bool validInput;
            do
            {
                Console.WriteLine("=> Kies eerste één van onderstaande categorieën:");
                foreach (Category category in ContactManager.GetAllCategories())
                {
                    Console.WriteLine(category.PrintCategory());
                    
                }
                Console.WriteLine("Van welke categorie (id) wenst u de contacten te zien?");
                validInput = Int32.TryParse(Console.ReadLine(), out keuze);
                if (!validInput || keuze < 1 || keuze > ContactManager.GetAllCategories().Count())
                {
                    validInput = false;
                    Console.WriteLine("Foute invoer, probeer opnieuw");
                }
            } while (!validInput);


            foreach (Contact contact in ContactManager.GetAllContactsForACategory(keuze))
            {
                Console.WriteLine(contact.PrintShortInfo());
            }
            
        }

        private void ShowAllContacts()
        {
            Console.WriteLine();
            //IEnumerable<Contact> contacts = ContactManager.GetAllContacts(OrderByFieldName.Name)
            IEnumerable<Contact> contacts = srv.GetAllContacts();
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.PrintSummary());
            }
        }


        
    }
}