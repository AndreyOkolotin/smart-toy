using System.Collections.Generic;
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

            // User creation.
            var manager = Startup.UserManagerFactory();
            IdentityUser user = new IdentityUser
            {
                UserName = "admin"
            };

            manager.Create(user, "123456");

            var dbContext = new ApplicationDbContext();

            var appUser = dbContext.Users.First();

            // Toys creation.
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

            // Games.
            var game1 = new Game()
            {
                Cost = 60,
                Description =
                    "������ ��������� ����� � ����. ������� ������ ������ ������ ��� ����� ����� � ��������������, ���� ������� ���������",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "�����-����",
                Id = Guid.NewGuid()
            };
            var game2 = new Game()
            {
                Cost = 130,
                Description =
                    "������ ��������. ������� ������� ������� ����� � ����, ���� ������� �� ��������, � ����� �������� � ������� �������",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "������ �����",
                Id = Guid.NewGuid()
            };
            var game3 = new Game()
            {
                Cost = 60,
                Description =
                    "������� ���� �� �������. ������� ������ ��� ����� ������� ��������� �������� �������, �������� �������� �� ���, ������ ��� ������� �������.",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "�������, �������",
                Id = Guid.NewGuid()
            };
            dbContext.Games.Add(game1);
            dbContext.Games.Add(game2);
            dbContext.Games.Add(game3);

            // Stories
            var story1 = new Story()
            {
                Cost = 15,
                Description =
                    "�� ������, �� ������, �� �������� ������, �� �� ���� -- �� ����� ��� ������ � ����� ����. � ���������� ��� ����: ������� ����� ��� ������...",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "�����-��������",
                Id = Guid.NewGuid()
            };
            var story2 = new Story()
            {
                Cost = 7,
                Description =
                    "����-���� ������ �� ��������. ��� � ������� ������ �������: � ����-��, �������, �� ������ ��������, �� ������ ������, �� ���������� �� ���� �� �������. ����� ������� ��������, �� ������ ���������, �� ������ ������ � ��������� ���� ������ ���...",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "�������",
                Id = Guid.NewGuid()
            };
            var story3 = new Story()
            {
                Cost = 7,
                Description =
                    "����-���� ��� � �����, � ���� � ��� �����. �������� ���� � ������. ���������-��������� ����� �� � ������� �� ������. ���������� ���� ���� �������, ���� ��, ������, ������ � ������, ��� �� ������ �������, ��������. ��� ��� ����� ���� ����-��, � ������ � ������� �������:",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "����-���",
                Id = Guid.NewGuid()
            };
            dbContext.Stories.Add(story1);
            dbContext.Stories.Add(story2);
            dbContext.Stories.Add(story3);

            // Actions.
            var action1 = new Models.DatabaseModels.Action()
            {
                Cost = 10,
                Description =
                    "�������, ��� ������ ����� ���� �� ��������",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "���� ������!",
                Id = Guid.NewGuid(),
                Type = "primary"
            };
            var action2 = new Models.DatabaseModels.Action()
            {
                Cost = 50,
                Description =
                    "�������, ��� ���� �������� �����",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "���� �����!",
                Id = Guid.NewGuid(),
                Type = "warning"
            };
            var action3 = new Models.DatabaseModels.Action()
            {
                Cost = 50,
                Description =
                    "���������� ��� ������ ����������� ������� � ��������� ������ ��������",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "����� ������� ���!",
                Id = Guid.NewGuid(),
                Type = "info"
            };
            var action4 = new Models.DatabaseModels.Action()
            {
                Cost = 50,
                Description =
                    "�������, ��� � ������� ����� ������, � ������ ����� ������� ��������� ������",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "�������, ����� ������!",
                Id = Guid.NewGuid(),
                Type = "danger"
            };
            dbContext.Actions.AddOrUpdate(action1);
            dbContext.Actions.AddOrUpdate(action2);
            dbContext.Actions.AddOrUpdate(action3);
            dbContext.Actions.AddOrUpdate(action4);

            // Songs.
            var song1 = new Song
            {
                Cost = 50,
                Description =
                    "",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "������� ������",
                Id = Guid.NewGuid()
            };
            var song2 = new Song
            {
                Cost = 50,
                Description =
                    "",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "������",
                Id = Guid.NewGuid()
            };
            var song3 = new Song
            {
                Cost = 50,
                Description =
                    "",
                ImageUrl = "https://www.stihi.ru/pics/2013/09/12/3487.gif",
                Name = "�����-�����",
                Id = Guid.NewGuid()
            };

            context.Songs.Add(song1);
            context.Songs.Add(song2);
            context.Songs.Add(song3);
            
            /*
            appUser.Actions = new List<Models.DatabaseModels.Action> { action1 };
            appUser.Stories = new List<Story> { story1 };
            appUser.Games = new List<Game> { game1 };*/

            appUser.Money = 2500;

            dbContext.SaveChanges();
        }
    }
}
