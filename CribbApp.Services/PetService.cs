using CribbApp.Data;
using CribbApp.Models.PetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Services
{
    public class PetService
    {
        private readonly Guid _userId;
        private readonly int _houseId;

        public PetService(Guid userId)
        {
            _userId = userId;
            //_houseId = 
        }

        public bool CreatePet(PetCreate model)
        {
            var entity =
                new Pet()
                {
                    OwnerId = _userId,
                    HouseId = _houseId,
                    Name = model.Name,
                    PetAge = model.PetAge,
                    Personality = model.Personality
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PetListItem> GetYourPets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pets
                        .Where(p => p.OwnerId == _userId)
                        .Select(
                            p =>
                                new PetListItem
                                {
                                    // *****
                                }

                        );
                return query.ToArray();
            }
        }

        public PetDetail GetPetById(int petId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Pets.Single(p => p.OwnerId == _userId && p.PetId == petId);
                return new PetDetail
                {
                    // *****
                };
            }
        }

        public bool UpdatePet(PetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Pets.Single(p => p.OwnerId == _userId && p.PetId == model.PetId);

                // *****

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePet(int petId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Pets.Single(p => p.OwnerId == _userId && p.PetId == petId);

                ctx.Pets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
