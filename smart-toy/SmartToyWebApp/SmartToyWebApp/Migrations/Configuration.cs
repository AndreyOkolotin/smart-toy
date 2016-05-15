using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartToyWebApp.Models;
using SmartToyWebApp.Models.DatabaseModels;

namespace SmartToyWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartToyWebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartToyWebApp.Models.ApplicationDbContext context)
        {
            var manager = Startup.UserManagerFactory();
            IdentityUser user = new IdentityUser
            {
                UserName = "admin"
            };

            manager.Create(user, "123456");

            var dbContext = new ApplicationDbContext();

            var appUser = dbContext.Users.First();

            dbContext.Toys.Add(new Toy()
            {
                Battery = 100,
                FriendlyName = "Franky",
                Owner = appUser,
                SoftwareVersion = "2.4.5",
                Temperature = 20,
                Type = 0
            });

            dbContext.Toys.Add(new Toy()
            {
                Battery = 90,
                FriendlyName = "Sonya",
                Owner = appUser,
                SoftwareVersion = "2.2.0",
                Temperature = 18,
                Type = 1
            });

            dbContext.Games.Add(new Game()
            {
                Cost = 60,
                Description =
                    "Very and very interesting game Very and very interesting game Very and very interesting game Very and very interesting game",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "Funny numbers"
            });


            dbContext.SaveChanges();
        }
    }
}
