using CribbApp.Data;
using CribbApp.Models.NeighborhoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Services
{
    public class NeighborhoodService
    {
        private readonly Guid _userId;

        public NeighborhoodService(Guid userId)
        {
            _userId = userId;
        }

        public NeighborhoodService()
        {
            //empty Constructor
        }

        public bool CreateNeighborhood(NeighborhoodCreate model)
        {
            var entity =
                new Neighborhood()
                {
                    OwnerId = _userId,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Neighborhoods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NeighborhoodListItem> GetNeighborhoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Neighborhoods
                        .Where(n => n.OwnerId == _userId)
                        .Select(
                            n =>
                                new NeighborhoodListItem
                                {
                                    NeighborhoodId = n.NeighborhoodId,
                                    OwnerId = n.OwnerId,
                                    Name = n.Name,
                                }
                        );

                return query.ToArray();
            }
        }

        public NeighborhoodDetail GetNeighborhoodById(int neighborhoodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Neighborhoods.Single(n => n.NeighborhoodId == neighborhoodId && n.OwnerId == _userId);
                return new NeighborhoodDetail
                {
                    NeighborhoodId = entity.NeighborhoodId,
                    OwnerId = entity.OwnerId,
                    Name = entity.Name,
                    Houses = entity.Houses
                };
            }
        }

        public bool UpdateNeighborhood(NeighborhoodEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Neighborhoods.Single(n => n.NeighborhoodId == model.NeighborhoodId && n.OwnerId == _userId);

                entity.NeighborhoodId = model.NeighborhoodId;
                entity.Name = model.Name;
                entity.Houses = (ICollection<House>)model.Houses;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNeighborhood(int neighborhoodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Neighborhoods.Single(n => n.NeighborhoodId == neighborhoodId && n.OwnerId == _userId);

                ctx.Neighborhoods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
