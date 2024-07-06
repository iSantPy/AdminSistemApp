using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        public void ResetAttributes()
        {
            ID = 0;
            Date = default(DateTime);
            Type = string.Empty;
            Amount = 0m;
            ExchangeRate = 0m;
            Supplier = string.Empty;
            Details.Clear();
        }
    } 
}
