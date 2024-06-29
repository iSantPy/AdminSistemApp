using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.VisualBasic.Logging;

namespace ControlAguaPotable
{ 
    public partial class SettingsWindow : Form
    {
        public delegate void ConstantsUpdateHandler(object sender, ConstantsUpdateEventArgs e);

        public event ConstantsUpdateHandler ConstantsUpdated;

        public decimal BIGGEST = DynamicConfig.GetFloat("Biggest");
        public decimal MEDIUM = DynamicConfig.GetFloat("Medium");
        public decimal MEDIUMSMALL = DynamicConfig.GetFloat("MediumSmall");
        public decimal SMALLEST = DynamicConfig.GetFloat("Smallest");
        public decimal LITERS = DynamicConfig.GetFloat("Liters");
        public decimal BIGGESTPRICE = DynamicConfig.GetFloat("BiggestPrice");
        public decimal MEDIUMPRICE = DynamicConfig.GetFloat("MediumPrice");
        public decimal MEDIUMSMALLPRICE = DynamicConfig.GetFloat("MediumSmallPrice");
        public decimal SMALLESTPRICE = DynamicConfig.GetFloat("SmallestPrice");
        public decimal EXCHANGERATE = DynamicConfig.GetFloat("ExchangeRate");

        public SettingsWindow()
        {
            InitializeComponent();

            biggest.Value = BIGGEST;
            medium.Value = MEDIUM;
            mediumSmall.Value = MEDIUMSMALL;
            smallest.Value = SMALLEST;
            priceBiggest.Value = BIGGESTPRICE;
            priceMedium.Value = MEDIUMPRICE;
            priceMediumSmall.Value = MEDIUMSMALLPRICE;
            priceSmallest.Value = SMALLESTPRICE;
            liters.Value = LITERS;
            exchangeRate.Value = EXCHANGERATE;

            clnBtn.Click += ClnBtn_Click;
            okBtn.Click += OkBtn_Click;
        }

        private void OkBtn_Click(object? sender, EventArgs e)
        {
            decimal oBiggest = biggest.Value;
            decimal oMedium = medium.Value;
            decimal oMediumSmall = mediumSmall.Value;
            decimal oSmallest = smallest.Value;
            decimal oPriceBiggest = priceBiggest.Value;
            decimal oPriceMedium = priceMedium.Value;
            decimal oPriceMediumSmall = priceMediumSmall.Value;
            decimal oPriceSmallest = priceSmallest.Value;
            decimal oLiters = liters.Value;
            decimal oExchangeRate = exchangeRate.Value;

            DynamicConfig.SetFloat("Biggest", oBiggest);
            DynamicConfig.SetFloat("Medium", oMedium);
            DynamicConfig.SetFloat("MediumSmall", oMediumSmall);
            DynamicConfig.SetFloat("Smallest", oSmallest);
            DynamicConfig.SetFloat("BiggestPrice", oPriceBiggest);
            DynamicConfig.SetFloat("MediumPrice", oPriceMedium);
            DynamicConfig.SetFloat("MediumSmallPrice", oPriceMediumSmall);
            DynamicConfig.SetFloat("SmallestPrice", oPriceSmallest);
            DynamicConfig.SetFloat("Liters", oLiters);
            DynamicConfig.SetFloat("ExchangeRate", oExchangeRate);

            ConstantsUpdateEventArgs args = new ConstantsUpdateEventArgs(oBiggest, oMedium, oMediumSmall, oSmallest, oPriceBiggest, oPriceMedium, oPriceMediumSmall, oPriceSmallest, oLiters, oExchangeRate);

            ConstantsUpdated?.Invoke(this, args);
            this.Close();
        }

        private void ClnBtn_Click(object? sender, EventArgs e)
        {
            biggest.Value = (decimal)BIGGEST;
            medium.Value = (decimal)MEDIUM;
            mediumSmall.Value = (decimal)MEDIUMSMALL;
            smallest.Value = (decimal)SMALLEST;
            priceBiggest.Value = (decimal)BIGGESTPRICE;
            priceMedium.Value = (decimal)MEDIUMPRICE;
            priceMediumSmall.Value = (decimal)MEDIUMSMALLPRICE;
            priceSmallest.Value = (decimal)SMALLESTPRICE;
            liters.Value = (decimal)LITERS;
            exchangeRate.Value = (decimal)EXCHANGERATE;
        }
    }

    public class ConstantsUpdateEventArgs : System.EventArgs
    {
        private decimal oBiggest;
        private decimal oMedium;
        private decimal oMediumSmall;
        private decimal oSmallest;
        private decimal oPriceBiggest;
        private decimal oPriceMedium;
        private decimal oPriceMediumSmall;
        private decimal oPriceSmallest;
        private decimal oLiters;
        private decimal oExchangeRate;

        public ConstantsUpdateEventArgs(decimal oBiggest, decimal oMedium, decimal oMediumSmall, decimal oSmallest, decimal oPriceBiggest, decimal oPriceMedium, decimal oPriceMediumSmall, decimal oPriceSmallest, decimal oLiters, decimal oExchangeRate)
        {
            this.oBiggest = oBiggest;
            this.oMedium = oMedium;
            this.oMediumSmall = oMediumSmall;
            this.oSmallest = oSmallest;
            this.oPriceBiggest = oPriceBiggest;
            this.oPriceMedium = oPriceMedium;
            this.oPriceMediumSmall = oPriceMediumSmall;
            this.oPriceSmallest = oPriceSmallest;
            this.oLiters = oLiters;
            this.oExchangeRate = oExchangeRate;
        }

        public decimal Biggest { get { return oBiggest; } }
        public decimal Medium { get { return oMedium; } }
        public decimal MediumSmall { get { return oMediumSmall; } }
        public decimal Smalllest { get { return oSmallest; } }
        public decimal PriceBiggest { get { return oPriceBiggest; } }
        public decimal PriceMedium { get { return oPriceMedium; } }
        public decimal PriceMediumSmall { get { return oPriceMediumSmall; } }
        public decimal PriceSmalllest { get { return oPriceSmallest; } }
        public decimal Liters { get { return oLiters; } }
        public decimal ExchangeRate { get { return oExchangeRate; } }
        

    }
}
