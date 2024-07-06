using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class QueryReportResult
    {
        public DateTime DateTime { get; set; }
        public decimal TotalLiters { get; set; }
        public decimal IncomeBs { get; set; }
        public decimal IncomeDollars { get; set; }
        public decimal IncomeBankBs { get; set; }
        public decimal WithdrawalBs { get; set; }
        public decimal WithdrawalDollars { get; set; }
        public decimal WithdrawalBankBs { get; set; }
    }
}
