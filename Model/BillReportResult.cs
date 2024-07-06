using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class BillReportResult
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Total { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public decimal UnitaryPrice { get; set; }
    }
}
