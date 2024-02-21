using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB.Models
{
    public class USCityModel
    {
        public string city { get; set; }
        public double cindex { get; set; }
        public double rent { get; set; }
        public double groceries { get; set; }
        public double restaurant { get; set; }
        public double pp { get; set; }
    }
}
