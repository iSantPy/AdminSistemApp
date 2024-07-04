using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class SellItems
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public List<SellItemsDetails> Details { get; set; } = new List<SellItemsDetails>();
        public ItemsIncomeBs IncomeBs { get; set; }
        public ItemsIncomeDollars IncomeDollars { get; set; }
        public ItemsWithdrawalBs WithdrawalBs { get; set; }
        public ItemsWithdrawalDollars WithdrawalDollars { get; set; }
        public ItemsIncomeBankBs IncomeBankBs { get; set; }
        public ItemsWithdrawalBankBs WithdrawalBankBs { get; set; }
    }
}
