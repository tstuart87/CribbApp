using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Data
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodId { get; set; }
        public Guid OwnerId { get; set; } // Neighborhood Administrator/Creator
        public string Name { get; set; }
        public List<int> Houses { get; set; } // List of HouseId's
    }
}
