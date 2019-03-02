using Contacts.BL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Contacts.DAL.EF
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactCategory> ContactCategories { get; set; }

        public ContactsDbContext(bool dropCreate = false)
        {
            ContactsDBInitializer.Initialize(this, dropCreate);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\ContactenDB.db");
            optionsBuilder.UseLoggerFactory(new LoggerFactory(
                new[] { new DebugLoggerProvider(
                    (category, level) => category == DbLoggerCategory.Database.Command.Name
                                         && level == LogLevel.Information
                )}
            ));
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasIndex(c => c.Name);
            modelBuilder.Entity<Contact>().HasKey(c => c.PersonId);
            modelBuilder.Entity<Address>().Ignore(a => a.AddressId);
            modelBuilder.Entity<Contact>().OwnsOne(c => c.Adress);
        }
    }
}