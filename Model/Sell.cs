using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class Sell
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public decimal TotalLiters { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public List<SellDetail> Details { get; set; } = new List<SellDetail>();
        public IncomeBs IncomeBs { get; set; }
        public IncomeDollars IncomeDollars { get; set; }
        public WithdrawalBs WithdrawalBs { get; set; }
        public WithdrawalDollars WithdrawalDollars { get; set; }
        
    }
}
