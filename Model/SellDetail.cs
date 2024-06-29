using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class SellDetail
    {
        public int ID { get; set; }
        public int SellID { get; set; }
        public Sell Sell { get; set; }
        public int Quantity { get; set; }
        public decimal Presentation { get; set; }
        public decimal UnitaryPrice { get; set; }
    }
}
