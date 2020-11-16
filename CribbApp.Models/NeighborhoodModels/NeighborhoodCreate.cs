using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Models.NeighborhoodModels
{
    public class NeighborhoodCreate
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
    }
}
