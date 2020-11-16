using CribbApp.Models.HouseModels;
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
    [RoutePrefix("api/House")]
    public class HouseController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            HouseService houseService = CreateHouseService();
            var houses = houseService.GetHouses();
            return Ok(houses);
        }

        public IHttpActionResult Get(int houseId)
        {
            HouseService houseService = CreateHouseService();
            var house = houseService.GetHouseById(houseId);
            return Ok(house);
        }

        public IHttpActionResult Post(HouseCreate house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateHouseService();

            if (!service.CreateHouse(house))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Put(HouseEdit house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var houseService = CreateHouseService();

            if (!houseService.UpdateHouse(house))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int houseId)
        {
            var houseService = CreateHouseService();

            if (!houseService.DeleteHouse(houseId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private HouseService CreateHouseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var houseService = new HouseService(userId);
            return houseService;
        }
    }
}
