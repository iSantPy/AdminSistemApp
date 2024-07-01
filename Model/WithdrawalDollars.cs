using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class WithdrawalDollars
    {
        public int ID { get; set; }
        public int SellID { get; set; }
        public decimal Amount { get; set; }
    }
}
