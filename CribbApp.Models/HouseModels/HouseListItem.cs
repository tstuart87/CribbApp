using CribbApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Models.HouseModels
{
    public class HouseListItem
    {
        [Key]
        public int HouseId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        public string StreetAddressOne { get; set; }
        public string StreetAddressTwo { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
