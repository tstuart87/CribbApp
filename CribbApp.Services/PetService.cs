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

            HouseService houseService = new HouseService();
            _houseId = houseService.GetHouseIdByOwnerId(_userId);
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
                                    PetId = p.PetId,
                                    OwnerId = p.OwnerId,
                                    HouseId = p.HouseId,
                                    Name = p.Name,
                                    PetAge = p.PetAge,
                                    Personality = p.Personality
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
                    PetId = entity.PetId,
                    OwnerId = entity.OwnerId,
                    HouseId = entity.HouseId,
                    Name = entity.Name,
                    PetAge = entity.PetAge,
                    Personality = entity.Personality
                };
            }
        }

        public bool UpdatePet(PetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Pets.Single(p => p.OwnerId == _userId && p.PetId == model.PetId);

                entity.PetId = model.PetId;
                entity.OwnerId = model.OwnerId;
                entity.HouseId = model.HouseId;
                entity.Name = model.Name;
                entity.PetAge = model.PetAge;
                entity.Personality = model.Personality;

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
