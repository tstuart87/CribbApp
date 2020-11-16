using CribbApp.Data;
using CribbApp.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Services
{
    public class HouseService
    {
        private readonly Guid _userId;

        public HouseService(Guid userId)
        {
            _userId = userId;
        }

        public HouseService()
        {
            //empty Constructor
        }

        public bool CreateHouse(HouseCreate model)
        {
            var entity =
                new House()
                {
                    OwnerId = _userId,
                    StreetAddressOne = model.StreetAddressOne,
                    StreetAddressTwo = model.StreetAddressTwo,
                    ApartmentNumber = model.ApartmentNumber,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Country = model.Country
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Houses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HouseListItem> GetHouses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Houses
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new HouseListItem
                                {
                                    HouseId = e.HouseId,
                                    OwnerId = e.OwnerId,
                                    StreetAddressOne = e.StreetAddressOne,
                                    StreetAddressTwo = e.StreetAddressTwo,
                                    ApartmentNumber = e.ApartmentNumber,
                                    City = e.City,
                                    State = e.State,
                                    ZipCode = e.ZipCode,
                                    Country = e.Country
                                }
                        );

                return query.ToArray();
            }
        }

        public HouseDetail GetHouseById(int houseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Houses.Single(h => h.HouseId == houseId && h.OwnerId == _userId);
                return new HouseDetail
                {
                    HouseId = entity.HouseId,
                    StreetAddressOne = entity.StreetAddressOne,
                    StreetAddressTwo = entity.StreetAddressTwo,
                    ApartmentNumber = entity.ApartmentNumber,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode,
                    Country = entity.Country
                };
            }
        }

        public int GetHouseIdByOwnerId(Guid ownerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Houses.Single(h => h.OwnerId == ownerId);

                return entity.HouseId;
            }
        }

        public bool UpdateHouse(HouseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Houses.Single(h => h.HouseId == model.HouseId && h.OwnerId == _userId);

                entity.HouseId = model.HouseId;
                entity.StreetAddressOne = model.StreetAddressOne;
                entity.StreetAddressTwo = model.StreetAddressTwo;
                entity.ApartmentNumber = model.ApartmentNumber;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.Country = model.Country;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHouse(int houseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Houses.Single(h => h.HouseId == houseId && h.OwnerId == _userId);

                ctx.Houses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
