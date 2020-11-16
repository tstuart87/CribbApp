using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Models.NeighborhoodModels
{
    public class NeighborhoodDetail
    {
        public int NeighborhoodId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public List<int> Houses { get; set; }
    }
}
