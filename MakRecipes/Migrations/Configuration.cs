namespace MakRecipes.Migrations
{
    using MakRecipes.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MakRecipes.Recipes>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MakRecipes.Recipes context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.People.AddOrUpdate(
              p => new { p.LastName, p.FirstName },
              new Person { LastName = "Corbin", FirstName = "Heather" },
                        new Person { LastName = "Ploss", FirstName = "Katie" },
                        new Person { LastName = "Meyer", FirstName = "Andrea" }
                        );
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }

                        //
        }
    }
}
