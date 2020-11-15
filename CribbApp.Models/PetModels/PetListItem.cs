using CribbApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Models.PetModels
{
    public class PetListItem
    {
        public int PetId { get; set; }
        public Guid OwnerId { get; set; }
        public int HouseId { get; set; }
        public string Name { get; set; }
        public PetAge? PetAge { get; set; }
        public PersonalityType? Personality { get; set; }
    }
}
