namespace eLibrary1.Migrations
{
    using eLibrary1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eLibrary1.Models.eLibrary1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eLibrary1.Models.eLibrary1Context context)
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

            context.Books.AddOrUpdate(b => b.Id,
           new Book() { Id = 1, Name = "2 States", AuthorName = "Chetan Bhagat", Price = 150 },
           new Book() { Id = 2, Name = "Igniting Minds", AuthorName = "A P J Abdul Kalam", Price = 250 }
       );

            context.People.AddOrUpdate(p => p.PId,
           new Person() { PId = 1, Username = "Nivedita", Password = "abc@123", BookId = 2 },
           new Person() { PId = 2, Username = "Ramya", Password = "pwd123", BookId = 1 }
       );
        }
    }
}
