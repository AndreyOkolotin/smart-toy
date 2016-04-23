using System.Web.Http;
using System.Web.Http.Cors;
using SmartToyWebApp.Models.ViewModels;

namespace SmartToyWebApp.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    [RoutePrefix("toy")]
    public class ToyController : ApiController
    {
        [HttpGet]
        [Route("info")]
        public InfoAboutToyViewModel InfoAboutToy()
        {
            return new InfoAboutToyViewModel()
            {
                Battery = 4,
                SoftwareVersion = "1.2.3",
                Temperature = 50
            };
        }
    }
}
