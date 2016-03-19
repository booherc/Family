namespace Family.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<Family.Models.ApplicationDbContext>
    {
        private ApplicationUserManager userManager;

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
              new Models.ApplicationUser { UserName = "maybooher@gmail.com", PhoneNumber = "8018857662"},
              new Models.ApplicationUser { UserName = "booher.cody@gmail.com", PhoneNumber = "4804351882"},
              new Models.ApplicationUser { UserName = "brittbooher@cox.net", PhoneNumber = "4802209995"},
              new Models.ApplicationUser { UserName = "brockbooher@cox.net", PhoneNumber = "480220614"}
            };

            users.ForEach(async u => await userManager.CreateAsync(u, "212Mayday!"));

            context.SaveChanges();

        }
    }
}
