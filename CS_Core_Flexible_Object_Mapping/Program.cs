using System;
using CS_Core_Flexible_Object_Mapping.Models;
using Microsoft.EntityFrameworkCore;

namespace CS_Core_Flexible_Object_Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManageDatabase();
                var person = new Person
                {
                    FisrtName = "Sujit",
                    MiddleName = "Dhanraj",
                    LastName = "Mhetre",
                    Address = "Pimple Saudagar"
                };
                person.SetEmail("sujitmhetre007@gmail.com");
                person.SetContactNo("9970278044");

                var db = new PersonalInfoDBContext();
                db.Persons.Add(person);
                db.SaveChanges();

                var persons = db.Persons.ToListAsync().Result;
                foreach(var item in persons)
                {
                    Console.WriteLine($" Person Details {item.FisrtName} {item.MiddleName} " +
                        $"{item.LastName} {item.Address} {item.GetEmail()} {item.GetContact()}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void ManageDatabase() {
            using(var ctx = new PersonalInfoDBContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}
