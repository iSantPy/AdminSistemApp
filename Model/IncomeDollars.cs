using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class IncomeDollars
    {
        public int ID { get; set; }
        public int SellID { get; set; }
        public decimal Amount { get; set; }
        public Sell Sell { get; set; }
    }
}
