using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class Bill
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Supplier { get; set; }
        public List<BillDetail> Details { get; set; } = new List<BillDetail>();
    }
}
