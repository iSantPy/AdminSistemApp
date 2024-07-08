using ControlAguaPotable.Controller;
using ControlAguaPotable.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAguaPotable
{
    public partial class SellingItemWindow : Form
    {
        public decimal EXCHANGERATE = DynamicConfig.GetFloat("ExchangeRate");
        private decimal withdrawalBs;
        private decimal withdrawalDollars;

        private SellingItemController sellingItemsController;

        private DataTable inventoryDataTable;
        private DataTable buyItemsDataTable;
        private DataTable substractedDataTable = null;

        public SellingItemWindow()
        {
            InitializeComponent();

            sellingItemsController = new SellingItemController();

            inventoryDataTable = sellingItemsController.ReadInventoryTableFromDb();

            stockDataGridView.DataSource = inventoryDataTable;
            stockDataGridView.Columns["description"].HeaderText = "descripción";
            stockDataGridView.Columns["stock"].HeaderText = "stock";
            stockDataGridView.Columns["unitaryPrice"].HeaderText = "precioUnitario";

            buyItemsDataTable = sellingItemsController.CreateBuyDataTable();

            sellDataGridView.DataSource = buyItemsDataTable;

            bsNumericUpDown.ValueChanged += bsNumeric_ValueChanged;
            dollarsNumericUpDown.ValueChanged += bsNumeric_ValueChanged;
            bankNumericUpDown.ValueChanged += bsNumeric_ValueChanged;

            wBsNumericUpDown.ValueChanged += bsWithdrawalNumeric_ValueChanged;
            wDollarsNumericUpDown.ValueChanged += bsWithdrawalNumeric_ValueChanged;
            wBankNumericUpDown.ValueChanged += bsWithdrawalNumeric_ValueChanged;
        }

        public void UpdateExchangeRate(object sender, ConstantsUpdateEventArgs e)
        {
            EXCHANGERATE = e.ExchangeRate;
        }

        private void bsNumeric_ValueChanged(object sender, EventArgs e)
        {
            string[] moneyArray = totalNumberLabel.Text.Split("/");

            decimal bsTotal;
            bool success = decimal.TryParse(moneyArray[0], out bsTotal);

            if (success)
            {
                decimal incomeBs = bsNumericUpDown.Value;
                decimal incomeBsBank = bankNumericUpDown.Value;

                decimal incomeDollars = dollarsNumericUpDown.Value;
                decimal dollarsIntoBs = incomeDollars * EXCHANGERATE;

                decimal resultBs = bsTotal - incomeBs - incomeBsBank - dollarsIntoBs;
                withdrawalBs = resultBs;

                decimal resultDollars = resultBs / EXCHANGERATE;
                withdrawalDollars = resultDollars;

                withdrawalTotalNumberLabel.Text = Math.Round(resultBs, 3).ToString() + "/" + Math.Round(resultDollars, 3).ToString();
            }
        }

        private void bsWithdrawalNumeric_ValueChanged(object sender, EventArgs e)
        {
            decimal bs = wBsNumericUpDown.Value;
            decimal dollars = wDollarsNumericUpDown.Value;
            decimal bankBs = wBankNumericUpDown.Value;

            decimal totalWithdrawal = bs + bankBs + (dollars * EXCHANGERATE);

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

            withdrawalTotalNumberLabel.Text = Math.Round(resultWBs, 3).ToString() + "/" + Math.Round(resultWDollars, 3).ToString();
        }

        private void CleanItemData()
        {
            descriptionTextBox.Clear();
            qtyNumericUpDown.Value = 0;
            priceNumericUpDown.Value = 0;
            idNumericUpDown.Value = 0;
        }

        private void CleanAll()
        {
            descriptionTextBox.Clear();
            qtyNumericUpDown.Value = 0;
            priceNumericUpDown.Value = 0;
            idNumericUpDown.Value = 0;

            bsNumericUpDown.Value = 0;
            bankNumericUpDown.Value = 0;
            dollarsNumericUpDown.Value = 0;

            wBsNumericUpDown.Value = 0;
            wBankNumericUpDown.Value = 0;
            wDollarsNumericUpDown.Value = 0;

            searchTextBox.Clear();

            totalNumberLabel.Text = "0.000/0.000";
            withdrawalTotalNumberLabel.Text = "0.000/0.000";

            buyItemsDataTable.Clear();
            sellDataGridView.DataSource = buyItemsDataTable;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CleanAll();

            stockDataGridView.DataSource = inventoryDataTable;
            substractedDataTable = null;
        }

        private void stockDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (stockDataGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = stockDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = stockDataGridView.Rows[selectedRowIndex];

                qtyNumericUpDown.Maximum = Convert.ToDecimal(selectedRow.Cells["stock"].Value);

                idNumericUpDown.Value = Convert.ToDecimal(selectedRow.Cells["id"].Value);
                descriptionTextBox.Text = Convert.ToString(selectedRow.Cells["description"].Value);
                qtyNumericUpDown.Value = Convert.ToDecimal(selectedRow.Cells["stock"].Value);
                priceNumericUpDown.Value = Convert.ToDecimal(selectedRow.Cells["unitaryPrice"].Value);
            }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            int id = (int)idNumericUpDown.Value;
            string description = descriptionTextBox.Text;
            int qty = (int)qtyNumericUpDown.Value;
            decimal unitaryPrice = priceNumericUpDown.Value;

            if (qty > 0)
            {
                try
                {
                    buyItemsDataTable = sellingItemsController.InsertNewRowToDataTable(buyItemsDataTable, id, description, qty, unitaryPrice);

                    sellDataGridView.DataSource = buyItemsDataTable;

                    CleanItemData();

                    qtyNumericUpDown.Maximum = 100000;

                    SubstractingItemsFromInventoryDataTable(id, qty);

                    Dictionary<string, decimal> moneyResults = sellingItemsController.SetMoneyValues(buyItemsDataTable, EXCHANGERATE);

                    totalNumberLabel.Text = moneyResults["moneyBs"].ToString() + "/" + moneyResults["moneyDollars"].ToString();
                }

                catch
                {

                }
            }

        }

        private void SubstractingItemsFromInventoryDataTable(int id, int qty)
        {
            if (substractedDataTable == null)
            {
                substractedDataTable = inventoryDataTable.Copy();
            }

            stockDataGridView.DataSource = sellingItemsController.UpdatingSubstractedTable(substractedDataTable, id, qty);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (substractedDataTable != null && substractedDataTable.Rows.Count != 0)
            {
                string mustBeZero = withdrawalTotalNumberLabel.Text.Split("/")[1];
                decimal dollarAmount = Convert.ToDecimal(totalNumberLabel.Text.Split("/")[1]);

                decimal bs = bsNumericUpDown.Value;
                decimal dollars = dollarsNumericUpDown.Value;
                decimal bankBs = bankNumericUpDown.Value;

                decimal bankBsWithdrawal = wBankNumericUpDown.Value;
                decimal withdrawalBs = wBsNumericUpDown.Value;
                decimal withdrawalDollar = wDollarsNumericUpDown.Value;

                if ((mustBeZero == "0" || mustBeZero == "0.000" || mustBeZero == "0.00" || mustBeZero == "0.0") && (bs != 0 || dollars != 0 || bankBs != 0))
                {
                    SellItems newSell = sellingItemsController.CreateSellAndDetails(buyItemsDataTable, bs, bankBs, dollars, bankBsWithdrawal, withdrawalBs, withdrawalDollar, dollarAmount, EXCHANGERATE);
                    sellingItemsController.RegisterNewSell(newSell);

                    sellingItemsController.UpdateStockFromDb(substractedDataTable);

                    CleanAll();

                    inventoryDataTable.Clear();

                    inventoryDataTable = sellingItemsController.ReadInventoryTableFromDb();

                    stockDataGridView.DataSource = inventoryDataTable;
                    stockDataGridView.Columns["description"].HeaderText = "descripción";
                    stockDataGridView.Columns["stock"].HeaderText = "stock";
                    stockDataGridView.Columns["unitaryPrice"].HeaderText = "precioUnitario";
                }
            }

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string wordToSearch = searchTextBox.Text;

            DataRow[] filteredRows = inventoryDataTable.Select($"description LIKE '%{Regex.Escape(wordToSearch)}%'");

            DataTable filteredTable = inventoryDataTable.Clone();

            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }

            stockDataGridView.DataSource = filteredTable;
        }
    }
}
