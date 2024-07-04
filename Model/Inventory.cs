using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class Inventory
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal UnitaryPrice { get; set; }
    }
}
