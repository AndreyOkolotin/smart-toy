using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using SmartToyWebApp.Models;
using SmartToyWebApp.Models.DatabaseModels;
using SmartToyWebApp.Models.ViewModels;

namespace SmartToyWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("user")]
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("money")]
        public int GetMoney()
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                return context.Users.Single(u => u.Id == currentUserId).Money;
            }
        }

        [HttpGet]
        [Route("toys/count")]
        public int GetCountOfToys()
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                return context.Toys.Count(t => t.Owner.Id == currentUserId);
            }
        }

        [HttpGet]
        [Route("actions")]
        public List<ActionViewModel> GetActions()
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                return context.Actions.Where(a => a.Users.Any(u => u.Id == currentUserId)).ToList().ToViewModel();
            }
        }

        [HttpGet]
        [Route("games")]
        public List<GameViewModel> GetGames()
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                return context.Games.Where(a => a.Users.Any(u => u.Id == currentUserId)).ToList().ToViewModel();
            }
        }

        [HttpGet]
        [Route("storiesAndSongs")]
        public List<StoryOrSongViewModel> GetStoriesAndSongs()
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                return context.Stories.Where(a => a.Users.Any(u => u.Id == currentUserId))
                    .ToList()
                    .ToStoryOrSongViewModel()
                    .Concat(
                        context.Songs.Where(a => a.Users.Any(u => u.Id == currentUserId)).ToList().ToStoryOrSongViewModel()).OrderBy(m => m.Name).ToList();
            }
        }

        [HttpGet]
        [Route("toys")]
        public List<ToyViewModel> GetToys()
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                return context.Toys.Where(t => t.Owner.Id == currentUserId).Select(t => new ToyViewModel()
                {
                    Name = t.FriendlyName,
                    Id = t.Id
                }).ToList();
            }
        }

        [HttpPost]
        [Route("toys")]
        public IHttpActionResult AddNewToy(NewToyBindingModel newToyModel)
        {
            var currentUserId = this.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var uid = Guid.Parse(newToyModel.Uid);

                var newToy = new Toy()
                {
                    FriendlyName = newToyModel.Name,
                    Uid = uid,
                    OwnerId = currentUserId,
                    Battery = 100,
                    SoftwareVersion = "v1.0.0",
                    Temperature = 18.0f,
                };

                context.Toys.Add(newToy);

                context.SaveChanges();
            }

            return this.Ok();
        }
    }
}
