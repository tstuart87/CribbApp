using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Data
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public Guid OwnerId { get; set; }
        public int HouseId { get; set; }
        public string Name { get; set; }
        public PetAge? PetAge { get; set; }
        public PersonalityType? Personality { get; set; }
    }

    public class Dog : Pet
    {

    }

    public class Cat : Pet
    {

    }

    public enum PersonalityType
    {
        Friendly,
        Rude,
        Cuddly,
        Hungry
    }

    public enum PetAge
    {
        Baby,
        Young,
        Adult,
        Old
    }
}
