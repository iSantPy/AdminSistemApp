using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    public class ItemQueryReportResult
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Product { get; set; }
        public int QuantitySold { get; set; }
        public decimal UnitaryPrice { get; set; }
        public decimal IncomeBsSellsItems { get; set; }
        public decimal IncomeDollarsSellsItems { get; set; }
        public decimal IncomeBankBsSellsItems { get; set; }
        public decimal WithdrawalBsSellsItems { get; set; }
        public decimal WithdrawalDollarsSellsItems { get; set; }
        public decimal WithdrawalBankBsSellsItems { get; set; }
    }

}
