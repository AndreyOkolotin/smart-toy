using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
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
            var dbContext = new ApplicationDbContext();

            return dbContext.Games.Select(g => new GameViewModel()
            {
                Cost = g.Cost,
                Description = g.Description,
                Id = g.Id,
                ImageUrl = g.ImageUrl,
                Name = g.Name
            }).ToList();
        } 
    }
}
