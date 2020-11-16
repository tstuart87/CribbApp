using CribbApp.Models.NeighborhoodModels;
using CribbApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CribbApp.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Neighbordhood")]
    public class NeighborhoodController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            NeighborhoodService neighService = CreateNeighborhoodService();
            var neighs = neighService.GetNeighborhoods();
            return Ok(neighs);
        }

        public IHttpActionResult Get(int neighborhoodId)
        {
            NeighborhoodService neighService = CreateNeighborhoodService();
            var neighs = neighService.GetNeighborhoodById(neighborhoodId);
            return Ok(neighs);
        }

        public IHttpActionResult Post(NeighborhoodCreate neigh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateNeighborhoodService();

            if (!service.CreateNeighborhood(neigh))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Put(NeighborhoodEdit neigh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var houseService = CreateNeighborhoodService();

            if (!houseService.UpdateNeighborhood(neigh))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int neighborhoodId)
        {
            var houseService = CreateNeighborhoodService();

            if (!houseService.DeleteNeighborhood(neighborhoodId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private NeighborhoodService CreateNeighborhoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var neighborhoodService = new NeighborhoodService(userId);
            return neighborhoodService;
        }
    }
}
