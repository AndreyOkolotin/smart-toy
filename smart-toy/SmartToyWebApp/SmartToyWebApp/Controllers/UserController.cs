﻿using System;
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
                    OwnerId = currentUserId
                };

                context.Toys.Add(newToy);

                context.SaveChanges();
            }

            return this.Ok();
        }
    }
}