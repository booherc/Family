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
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Family.Models.ApplicationDbContext";
        }

        protected override void Seed(Family.Models.ApplicationDbContext context)
        {

            // to restart and toss out everything you have done do this
            // Update-Database –TargetMigration: $InitialDatabase
            // update-database
            // 
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
                    new Models.ApplicationUser { UserName = "maybooher@gmail.com",
                        Email = "maybooher@gmail.com",
                        PhoneNumber = "8018857662",
                        FirstName = "Maylyn",
                        LastName = "Booher",
                        Address = "371 E 1550 S",
                        City = "Orem",
                        State = "UT",
                    BirthDate = DateTime.Parse("08/24/1992")},

                    new Models.ApplicationUser { UserName = "booher.cody@gmail.com", Email = "booher.cody@gmail.com", PhoneNumber = "4804351882", FirstName = "Cody", LastName = "Booher"},

                    new Models.ApplicationUser { UserName = "brittbooher@cox.net", Email = "brittbooher@cox.net", PhoneNumber = "4802209995", FirstName = "Britt", LastName = "Booher"},

                    new Models.ApplicationUser { UserName = "brockbooher@cox.net", Email = "brockbooher@cox.net", PhoneNumber = "480220614", FirstName = "Brock", LastName = "Booher"}
                };

                users.ForEach(u => userManager.Create(u, "212Mayday!"));
            }

        }
    }
}
