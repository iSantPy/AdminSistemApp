using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class BillDetail
    {
        public int ID { get; set; }
        public int BillID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
