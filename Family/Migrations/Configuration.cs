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
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userStore = new UserStore<Models.ApplicationUser>(context);
            var userManager = new UserManager<Models.ApplicationUser>(userStore);
            if (!(context.Users.Any(u => u.UserName == "booher.cody@gmail.com")))
            {
                
                List<Models.ApplicationUser> users = new List<Models.ApplicationUser>
                {
                    new Models.ApplicationUser { UserName = "mb@gmail.com",
                        Email = "mb@gmail.com",
                        PhoneNumber = "5555555555",
                        FirstName = "Max",
                        LastName = "Booher",
                        Address = "123 Yo Yo Way",
                        City = "China",
                        State = "WY",
                        BirthDate = DateTime.Parse("02/22/1999"),
                        Zipcode = "12345"},

                    new Models.ApplicationUser { UserName = "booher.cody@gmail.com",
                        Email = "booher.cody@gmail.com",
                        PhoneNumber = "5555555555",
                        FirstName = "Cody",
                        LastName = "Booher",
                        Address = "123 Yo Yo Way",
                        City = "China",
                        State = "WY",
                        BirthDate = DateTime.Parse("02/22/1999"),
                        Zipcode = "12345"},

                    new Models.ApplicationUser { UserName = "nb@cox.net",
                        Email = "nb@cox.net",
                        PhoneNumber = "4802209995",
                        FirstName = "Nimble",
                        LastName = "Booher",
                        Address = "123 Yo Yo Way",
                        City = "China",
                        State = "WY",
                        BirthDate = DateTime.Parse("02/22/1999"),
                        Zipcode = "12345"},

                    new Models.ApplicationUser { UserName = "gb@cox.net",
                        Email = "gb@cox.net",
                        PhoneNumber = "480220614",
                        FirstName = "Goober",
                        LastName = "Booher",
                        Address = "123 Yo Yo Way",
                        City = "China",
                        State = "WY",
                        BirthDate = DateTime.Parse("02/22/1999"),
                        Zipcode = "12345"}
                };

                users.ForEach(u => userManager.Create(u, "123Test!"));
            }

            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            var codyUser = userManager.Users.Where(u => u.UserName == "booher.cody@gmail.com").FirstOrDefault();
            context.Posts.AddOrUpdate(
               p => p.PostId,
               new Models.Post
               {
                   AuthorID = codyUser.Id,
                   Author = codyUser,
                   PostTime = DateTime.Now,
                   Content = "Lorem ipsum dolor sit amet, legere aliquip et pro, eos mundi accommodare ut. Noster bonorum minimum vim ad, vitae alterum facilisi ei has. Falli nostrum et eos. In vix quando graecis nostrum, vim ludus dictas torquatos ut, erat molestiae disputationi ea mel.",
                   Title = "Long Live Lorem Ipsum"
               },
               new Models.Post
               {
                   AuthorID = codyUser.Id,
                   Author = codyUser,
                   PostTime = DateTime.Now,
                   Content = "Lorem ipsum dolor sit amet, legere aliquip et pro, eos mundi accommodare ut. Noster bonorum minimum vim ad, vitae alterum facilisi ei has. Falli nostrum et eos. In vix quando graecis nostrum, vim ludus dictas torquatos ut, erat molestiae disputationi ea mel.",
                   Title = "Long Live Lorem Ipsum"
               },
               new Models.Post
               {
                   AuthorID = codyUser.Id,
                   Author = codyUser,
                   PostTime = DateTime.Now,
                   Content = "Lorem ipsum dolor sit amet, legere aliquip et pro, eos mundi accommodare ut. Noster bonorum minimum vim ad, vitae alterum facilisi ei has. Falli nostrum et eos. In vix quando graecis nostrum, vim ludus dictas torquatos ut, erat molestiae disputationi ea mel.",
                   Title = "Long Live Lorem Ipsum"
               },
               new Models.Post
               {
                   AuthorID = codyUser.Id,
                   Author = codyUser,
                   PostTime = DateTime.Now,
                   Content = "Lorem ipsum dolor sit amet, legere aliquip et pro, eos mundi accommodare ut. Noster bonorum minimum vim ad, vitae alterum facilisi ei has. Falli nostrum et eos. In vix quando graecis nostrum, vim ludus dictas torquatos ut, erat molestiae disputationi ea mel.",
                   Title = "Long Live Lorem Ipsum"
               }
               );

        }
    }
}
