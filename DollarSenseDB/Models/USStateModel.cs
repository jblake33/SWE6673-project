using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarSenseDB.Models
{
    public class USStateModel
    {
        public string state {  get; set; }
        public double cindex { get; set; }
        public double grocery {  get; set; }
        public double housing { get; set; }
        public double utilities {  get; set; }
        public double transportation { get; set; }
        public double health {  get; set; }
        public double misc {  get; set; }
    }
}
