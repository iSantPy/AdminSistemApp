﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAguaPotable.Model
{
    internal class WithdrawalBs
    {
        public int ID { get; set; }
        public int SellID { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public Sell Sell { get; set; }
    }
}
