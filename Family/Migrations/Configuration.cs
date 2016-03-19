namespace Family.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<Family.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Family.Models.ApplicationDbContext";
        }

        protected override void Seed(Family.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            
            var appContext = new Models.ApplicationDbContext();
            List<Models.ApplicationUser> users = new List<Models.ApplicationUser>
            {
                
            };

            users.ForEach(u => context.Users.AddOrUpdate(u));
            context.SaveChanges();

        }
    }
}
