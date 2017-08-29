namespace OmegaAppZadatak2.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Contacts.AddOrUpdate(new Contact
            {
                Ime = "Ivica",
                Prezime = "Ivic",
                Grad = "Zagreb",
                Opis = "Susjed",
                Slika = "",
                Numbers = new List<PhoneNumber>
                {
                    new PhoneNumber
                    {
                        Type = NumberType.Mobile,
                        Number = "0911111111",
                        Description = "Ne zovi poslje 16"
                    },
                     new PhoneNumber
                    {
                        Type = NumberType.Home,
                        Number = "2",
                        Description = "Zovi poslje 16"
                    },
                    new PhoneNumber
                    {
                        Type = NumberType.Work,
                        Number = "1",
                        Description = "Ne zovi poslje 16"
                    }
                }
            });

            context.Contacts.AddOrUpdate(new Contact
            {
                Ime = "Marko",
                Prezime = "Maric",
                Grad = "Zagreb",
                Opis = "Susjed preko ceste",
                Slika = "",
                Numbers = new List<PhoneNumber>
                {
                    new PhoneNumber
                    {
                        Type = NumberType.Mobile,
                        Number = "12345",
                        Description = "Ne zovi poslje 16"
                    },
                     new PhoneNumber
                    {
                        Type = NumberType.Home,
                        Number = "11111111",
                        Description = "Zovi poslje 16"
                    },
                    new PhoneNumber
                    {
                        Type = NumberType.Work,
                        Number = "333",
                        Description = "Ne zovi poslje 16"
                    }
                }
            });

            context.Contacts.AddOrUpdate(new Contact
            {
                Ime = "Lega",
                Prezime = "Legic",
                Grad = "Zagreb",
                Opis = "Lega s posla",
                Slika = "",
                Numbers = new List<PhoneNumber>
                {
                    new PhoneNumber
                    {
                        Type = NumberType.Mobile,
                        Number = "0911111111",
                        Description = "Ne zovi poslje 16"
                    },
                     new PhoneNumber
                    {
                        Type = NumberType.Home,
                        Number = "0912222222",
                        Description = "Zovi poslje 16"
                    },
                    new PhoneNumber
                    {
                        Type = NumberType.Work,
                        Number = "0913333333",
                        Description = "Ne zovi poslje 16"
                    }
                }
            });
        }
    }
}
