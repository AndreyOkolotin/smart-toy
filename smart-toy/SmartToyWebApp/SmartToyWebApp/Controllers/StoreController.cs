using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using SmartToyWebApp.Models;
using SmartToyWebApp.Models.ViewModels;

namespace SmartToyWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("store")]
    public class StoreController : ApiController
    {
        [HttpGet]
        [Route("games")]
        public List<GameViewModel> GetGames()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var dbContext = new ApplicationDbContext();

            return dbContext.Games.Where(g => g.Users.All(u => u.Id != currentUserId)).ToList().ToViewModel();
        }

        [HttpGet]
        [Route("actions")]
        public List<ActionViewModel> GetActions()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var dbContext = new ApplicationDbContext();

            return dbContext.Actions.Where(a => a.Users.All(u => u.Id != currentUserId)).ToList().ToViewModel();
        }

        [HttpGet]
        [Route("stories")]
        public List<StoryViewModel> GetStories()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var dbContext = new ApplicationDbContext();

            return dbContext.Stories.Where(a => a.Users.All(u => u.Id != currentUserId)).ToList().ToViewModel();
        }

        [HttpGet]
        [Route("songs")]
        public List<SongViewModel> GetSongs()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var dbContext = new ApplicationDbContext();

            return dbContext.Songs.Where(a => a.Users.All(u => u.Id != currentUserId)).ToList().ToViewModel();
        }

        [HttpPost]
        [Route("action/{actionId}")]
        public IHttpActionResult BuyAction(Guid actionId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var action = context.Actions.Single(a => a.Id == actionId);
                if (action.Users != null)
                {
                    action.Users.Add(context.Users.Single(u => u.Id == currentUserId));
                    action.Users = action.Users.Distinct().ToList();
                }
                else
                {
                    action.Users = new List<ApplicationUser> { context.Users.Single(u => u.Id == currentUserId) };
                }
                TakeMoney(action.Cost, currentUserId, context);
                context.SaveChanges();
            }

            return this.Ok();
        }

        [HttpPost]
        [Route("game/{gameId}")]
        public IHttpActionResult BuyGame(Guid gameId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var game = context.Games.Single(a => a.Id == gameId);
                if (game.Users != null)
                {
                    game.Users.Add(context.Users.Single(u => u.Id == currentUserId));
                    game.Users = game.Users.Distinct().ToList();
                }
                else
                {
                    game.Users = new List<ApplicationUser> { context.Users.Single(u => u.Id == currentUserId) };
                }
                TakeMoney(game.Cost, currentUserId, context);
                context.SaveChanges();
            }

            return this.Ok();
        }

        [HttpPost]
        [Route("story/{storyId}")]
        public IHttpActionResult BuyStory(Guid storyId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var story = context.Stories.Single(a => a.Id == storyId);
                if (story.Users != null)
                {
                    story.Users.Add(context.Users.Single(u => u.Id == currentUserId));
                    story.Users = story.Users.Distinct().ToList();
                }
                else
                {
                    story.Users = new List<ApplicationUser> { context.Users.Single(u => u.Id == currentUserId) };
                }
                TakeMoney(story.Cost, currentUserId, context);
                context.SaveChanges();
            }

            return this.Ok();
        }

        [HttpPost]
        [Route("song/{songId}")]
        public IHttpActionResult BuySong(Guid songId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var song = context.Songs.Single(a => a.Id == songId);
                if (song.Users != null)
                {
                    song.Users.Add(context.Users.Single(u => u.Id == currentUserId));
                    song.Users = song.Users.Distinct().ToList();
                }
                else
                {
                    song.Users = new List<ApplicationUser> { context.Users.Single(u => u.Id == currentUserId) };
                }
                TakeMoney(song.Cost, currentUserId, context);
                context.SaveChanges();
            }

            return this.Ok();
        }

        private void TakeMoney(int money, string userId, ApplicationDbContext dbContext)
        {
            var user = dbContext.Users.Single(u => u.Id == userId);
            if (user.Money >= money)
            {
                user.Money -= money;
                return;
            }

            throw new InvalidOperationException("Недостаточно средств");

        }
    }
}
