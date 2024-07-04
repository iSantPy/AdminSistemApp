using ControlAguaPotable.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAguaPotable
{
    public partial class InventoryWindow : Form
    {
        private InventoryController inventoryController;

        private DataTable inventoryDataTable;
        public InventoryWindow()
        {
            InitializeComponent();

            inventoryController = new InventoryController();

            inventoryDataTable = inventoryController.ReadInventoryTableFromDb();

            dataGridView.DataSource = inventoryDataTable;
            dataGridView.Columns["description"].HeaderText = "descripción";
            dataGridView.Columns["stock"].HeaderText = "stock";
            dataGridView.Columns["unitaryPrice"].HeaderText = "precioUnitario";
        }

        private void UpdateDataTableAndDataGridView()
        {
            CleanAll();

            inventoryDataTable = inventoryController.ReadInventoryTableFromDb();

            dataGridView.DataSource = inventoryDataTable;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            decimal id = idNumericUpDown.Value;
            string description = descriptionTextBox.Text.Trim();
            int stock = (int)stockNumericUpDown.Value;
            decimal unitaryPrice = priceNumericUpDown.Value;

            if (id == 0 && description != "" && stock != 0 && unitaryPrice != 0)
            { 
                inventoryController.InsertNewItemToDb(description, stock, unitaryPrice);

                UpdateDataTableAndDataGridView();
            }
        }

        private void CleanAll()
        {
            descriptionTextBox.Clear();
            stockNumericUpDown.Value = 0;
            priceNumericUpDown.Value = 0;
            idNumericUpDown.Value = 0;

            searchTextBox.Clear();

            inventoryDataTable.Clear();
        }

        private void clnBtn_Click(object sender, EventArgs e)
        {
            UpdateDataTableAndDataGridView();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int id = (int)idNumericUpDown.Value;

            if (id != 0)
            {
                string description = descriptionTextBox.Text.Trim();
                int stock = (int)stockNumericUpDown.Value;
                decimal unitaryPrice = priceNumericUpDown.Value;
                
                inventoryController.UpdateItemFromDb(id, description, stock, unitaryPrice);

                UpdateDataTableAndDataGridView();
            }
            
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];

                idNumericUpDown.Value = Convert.ToDecimal(selectedRow.Cells["id"].Value);
                descriptionTextBox.Text = Convert.ToString(selectedRow.Cells["description"].Value);
                stockNumericUpDown.Value = Convert.ToDecimal(selectedRow.Cells["stock"].Value);
                priceNumericUpDown.Value = Convert.ToDecimal(selectedRow.Cells["unitaryPrice"].Value);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = (int)idNumericUpDown.Value;

            if (id != 0)
            {
                inventoryController.DeleteItemFromDb(id);

                UpdateDataTableAndDataGridView();
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

            dataGridView.DataSource = filteredTable;
        }
    }
}
