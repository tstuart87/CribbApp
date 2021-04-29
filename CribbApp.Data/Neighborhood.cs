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

        public virtual ICollection<House> Houses { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
