using CribbApp.Data;
using CribbApp.Models.PetModels;
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
    public class PetController : ApiController
    {
        public IHttpActionResult Get()
        {
            PetService petService = CreatePetService();
            var pets = petService.GetYourPets();
            return Ok(pets);
        }

        public IHttpActionResult Get(int petId)
        {
            PetService petService = CreatePetService();
            var pets = petService.GetPetById(petId);
            return Ok(pets);
        }

        public IHttpActionResult Post(PetCreate pet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var petService = CreatePetService();

            if (!petService.CreatePet(pet))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PetEdit pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var petService = CreatePetService();

            if (!petService.UpdatePet(pet))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int petId)
        {
            var petService = CreatePetService();

            if (!petService.DeletePet(petId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public PetService CreatePetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var petService = new PetService(userId);
            return petService;
        }
    }
}
