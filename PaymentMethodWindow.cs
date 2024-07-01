using ControlAguaPotable.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlAguaPotable.Model;

namespace ControlAguaPotable
{
    public partial class PaymentMethodWindow : Form
    {
        public decimal EXCHANGERATE = DynamicConfig.GetFloat("ExchangeRate");
        private decimal withdrawalBs;
        private decimal withdrawalDollars;

        private PaymentMethodController paymentMethodController;

        private DataTable dt;
        private string moneyString;

        public delegate void CleanDataTableHandler(object sender, CleanDataTableEventArgs e);

        public event CleanDataTableHandler CleanDataTable;
        
        public PaymentMethodWindow()
        {
            InitializeComponent();

            paymentMethodController = new PaymentMethodController();

            clnBtn.Click += ClnBtn_Click;
            dollarsNumeric.ValueChanged += bsNumeric_ValueChanged;
            dollarsWithdrawalNumeric.ValueChanged += bsWithdrawalNumeric_ValueChanged;
            acceptBtn.Click += AcceptBtn_Click;
        }

        public void UpdateExchangeRate(object sender, ConstantsUpdateEventArgs e)
        {
            EXCHANGERATE = e.ExchangeRate;
        }

        private void AcceptBtn_Click(object? sender, EventArgs e)
        {
            string mustBeZero = withdrawalMoney.Text.Split("/")[1];
            decimal dollarAmount = Convert.ToDecimal(moneyString.Split("/")[1]);

            decimal bs = bsNumeric.Value;
            decimal dollars = dollarsNumeric.Value;

            decimal withdrawalBs = bsWithdrawalNumeric.Value;
            decimal withdrawalDollar = dollarsWithdrawalNumeric.Value;

            if ((mustBeZero == "0" || mustBeZero == "0.00" || mustBeZero == "0.0") && (bs != 0 || dollars != 0))
            {
                Sell newSell = paymentMethodController.CreateSellAndDetails(dt, bs, dollars, withdrawalBs, withdrawalDollar, dollarAmount, EXCHANGERATE);
                paymentMethodController.RegisterNewSell(newSell);

                CleanDataTableEventArgs args = new CleanDataTableEventArgs(true);

                CleanDataTable?.Invoke(this, args);

                this.Close();
            }
        }

        private void ClnBtn_Click(object? sender, EventArgs e)
        {
            bsNumeric.Value = 0;
            dollarsNumeric.Value = 0;

            bsWithdrawalNumeric.Value = 0;
            dollarsWithdrawalNumeric.Value = 0;

            withdrawalMoney.Text = "0/0";
        }

        public void UpdateMoney(object sender, MoneyUpdateEventArgs e)
        {
            moneyString = e.Money;
            money.Text = moneyString;
            dt = e.DataTable;
        }

        private void bsNumeric_ValueChanged(object sender, EventArgs e)
        {
            string[] moneyArray = money.Text.Split("/");

            decimal bsTotal;
            bool success = decimal.TryParse(moneyArray[0], out bsTotal);

            if (success)
            {
                decimal incomeBs = bsNumeric.Value;

                decimal incomeDollars = dollarsNumeric.Value;
                decimal dollarsIntoBs = incomeDollars * EXCHANGERATE;

                decimal resultBs = bsTotal - incomeBs - dollarsIntoBs;
                withdrawalBs = resultBs;

                decimal resultDollars = resultBs / EXCHANGERATE;
                withdrawalDollars = resultDollars;

                withdrawalMoney.Text = Math.Round(resultBs, 2).ToString() + "/" + Math.Round(resultDollars, 2).ToString();
            }
        }

        private void bsWithdrawalNumeric_ValueChanged(object sender, EventArgs e)
        { 
            decimal bs = bsWithdrawalNumeric.Value;
            decimal dollars = dollarsWithdrawalNumeric.Value;

            decimal totalWithdrawal = bs + dollars * EXCHANGERATE;

            decimal resultWBs = 0m;
            decimal resultWDollars = 0m;

            if (withdrawalBs < 0 && withdrawalBs != 0)
            {
                resultWBs = withdrawalBs + totalWithdrawal;
                resultWDollars = resultWBs / EXCHANGERATE;
            }
            else if (withdrawalBs > 0 && withdrawalBs != 0)
            {
                resultWBs = withdrawalBs - totalWithdrawal;
                resultWDollars = resultWBs / EXCHANGERATE;
            }

            withdrawalMoney.Text = Math.Round(resultWBs, 2).ToString() + "/" + Math.Round(resultWDollars, 2).ToString();
        }
    }

    public class CleanDataTableEventArgs : EventArgs 
    {
        private bool flag;

        public CleanDataTableEventArgs(bool flag)
        {
            this.flag = flag;
        }

        public bool Flag { get { return flag; } }
    }
}
