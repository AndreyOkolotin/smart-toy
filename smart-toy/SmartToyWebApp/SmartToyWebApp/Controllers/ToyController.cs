using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using SmartToyWebApp.Models;
using SmartToyWebApp.Models.ViewModels;

namespace SmartToyWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("toy")]
    public class ToyController : ApiController
    {
        [HttpGet]
        [Route("info/{id}")]
        public InfoAboutToyViewModel InfoAboutToy(int id)
        {
            var dbContext = new ApplicationDbContext();

            var toy = dbContext.Toys.Single(t => t.Id == id);

            return new InfoAboutToyViewModel()
            {
                Battery = toy.Battery,
                FriendlyName = toy.FriendlyName,
                Id = toy.Id,
                SoftwareVersion = toy.SoftwareVersion,
                Temperature = toy.Temperature,
                Type = toy.Type,
                Uid = toy.Uid
            };
        }

        [HttpDelete]
        [Route("{toyId}")]
        public IHttpActionResult DeleteToy(int toyId)
        {
            var dbContext = new ApplicationDbContext();
            dbContext.Toys.Remove(dbContext.Toys.Single(t => t.Id == toyId));
            dbContext.SaveChanges();

            return this.Ok("Succesfully removed");
        }
    }
}
