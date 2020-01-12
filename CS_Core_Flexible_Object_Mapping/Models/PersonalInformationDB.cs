using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CS_Core_Flexible_Object_Mapping.Models
{
    public class PersonalInfoDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.;Database=PersonInfoDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property<string>("Email").HasField("_Email");            
            modelBuilder.Entity<Person>().Property<string>("ContactNo").HasField("_ContactNo");
        }
    }
}
