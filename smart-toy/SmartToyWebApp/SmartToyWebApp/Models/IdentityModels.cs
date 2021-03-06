﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartToyWebApp.Models.DatabaseModels;

namespace SmartToyWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Action> Actions { get; set; }
        public List<Game> Games { get; set; }
        public List<Story> Stories { get; set; }
        public List<Song> Songs { get; set; }

        public int Money { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync
                                    (UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this,
                                    DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Toy> Toys { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Song> Songs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
