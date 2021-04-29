using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Data
{
    public class Rule
    {
        public int RuleId { get; set; }
        public string RuleDescription { get; set; }
        public int Sorter { get; set; }

        public virtual ICollection<House> Houses { get; set; }
    }
}
