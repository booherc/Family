namespace Family.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Family.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Family.Models.ApplicationDbContext";
        }

        protected override void Seed(Family.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            if (!(context.Users.Any(u => u.UserName == "booher.cody@gmail.com")))
            {
                var userStore = new UserStore<Models.ApplicationUser>(context);
                var userManager = new UserManager<Models.ApplicationUser>(userStore);
                List<Models.ApplicationUser> users = new List<Models.ApplicationUser>
                {
                  new Models.ApplicationUser { UserName = "maybooher@gmail.com", Email = "maybooher@gmail.com", PhoneNumber = "8018857662"},
                  new Models.ApplicationUser { UserName = "booher.cody@gmail.com", Email = "booher.cody@gmail.com", PhoneNumber = "4804351882"},
                  new Models.ApplicationUser { UserName = "brittbooher@cox.net", Email = "brittbooher@cox.net", PhoneNumber = "4802209995"},
                  new Models.ApplicationUser { UserName = "brockbooher@cox.net", Email = "brockbooher@cox.net", PhoneNumber = "480220614"}
                };

                users.ForEach(u => userManager.Create(u, "212Mayday!"));

                //var user = new Models.ApplicationUser { UserName = "maybooher@gmail.com", Email = "maybooher@gmail.com", PhoneNumber = "8018857662" };
                //userManager.Create(user, "212Mayday!");
            }

        }
    }
}
