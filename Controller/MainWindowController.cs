using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ControlAguaPotable.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ControlAguaPotable.Controller
{
    internal class MainWindowController
    {
        public decimal BIGGEST = DynamicConfig.GetFloat("Biggest");
        public decimal MEDIUM = DynamicConfig.GetFloat("Medium");
        public decimal MEDIUMSMALL = DynamicConfig.GetFloat("MediumSmall");
        public decimal SMALLEST = DynamicConfig.GetFloat("Smallest");
        public decimal EXCHANGERATE = DynamicConfig.GetFloat("ExchangeRate");

        private DataTable _dataTable = new DataTable();
        private DataTable _dataTableBill = new DataTable();

        decimal totalBill = 0;

        public void UpdateConstants(object sender, ConstantsUpdateEventArgs e)
        {
            BIGGEST = e.Biggest;
            MEDIUM = e.Medium;
            MEDIUMSMALL = e.MediumSmall;
            SMALLEST = e.Smalllest;
            EXCHANGERATE = e.ExchangeRate;
        }

        public DataTable CreateDataTable()
        {
            _dataTable.Columns.Add("cantidad", typeof(int));
            _dataTable.Columns.Add("presentación", typeof(decimal));
            _dataTable.Columns.Add("litrosTotal", typeof(decimal));
            _dataTable.Columns.Add("precioUnitario", typeof(decimal));
            _dataTable.Columns.Add("precioTotal", typeof(decimal));

            InsertRowsToNewDataTable();

            return _dataTable;
        }

        private void InsertRowsToNewDataTable()
        {
            for (int i = 0; i < 5; i++)
            {
                DataRow row = _dataTable.NewRow();

                row["cantidad"] = 0;
                row["presentación"] = 0m;
                row["litrosTotal"] = 0m;
                row["precioUnitario"] = 0m;
                row["precioTotal"] = 0m;

                _dataTable.Rows.Add(row);
            }
        }

        public Dictionary<string, decimal> AddRegister(int cantidad, decimal presentacion, decimal litrosTotal, decimal precioUnitario, decimal precioTotal)
        {
            int indexRow;
            decimal precioBs;
            decimal precioUSD;
            decimal litros;

            if (presentacion == BIGGEST)
            {
                indexRow = 0;
            }
            else if (presentacion == MEDIUM)
            {
                indexRow = 1;
            }
            else if (presentacion == MEDIUMSMALL)
            {
                indexRow = 2;
            }
            else if (presentacion == SMALLEST)
            {
                indexRow = 3;
            }
            else
            {
                indexRow = 4;
            }

            DataRow row = _dataTable.Rows[indexRow];

            row["cantidad"] = (int)row["cantidad"] + cantidad;
            row["presentación"] = presentacion;
            row["litrosTotal"] = (decimal)row["litrosTotal"] + litrosTotal;
            row["precioUnitario"] = precioUnitario;
            row["precioTotal"] = (decimal)row["precioTotal"] + precioTotal;

            precioUSD = _dataTable.AsEnumerable().Sum(row => row.Field<decimal>("precioTotal"));
            precioBs = precioUSD * EXCHANGERATE;
            litros = _dataTable.AsEnumerable().Sum(row => row.Field<decimal>("litrosTotal"));

            Dictionary<string, decimal> results = new Dictionary<string, decimal>
                {
                    { "precioBs", precioBs },
                    { "precioUSD", precioUSD },
                    { "litros", litros }
                };

            return results;
        }

        public void CleanDataTable()
        {
            _dataTable.Clear();
            InsertRowsToNewDataTable();
        }

        public DataTable CreateDataTableBill()
        {
            _dataTableBill.Columns.Add("tipo", typeof(string));
            _dataTableBill.Columns.Add("descripción", typeof(string));
            _dataTableBill.Columns.Add("cantidad", typeof(int));
            _dataTableBill.Columns.Add("precioUnitario", typeof(decimal));
            _dataTableBill.Columns.Add("proveedor", typeof(string));

            return _dataTableBill;
        }

        public void AddRegiterDataTableBill(string type, string description, int qty, decimal unitaryPrice, string supplier)
        {
            DataRow row = _dataTableBill.NewRow();
            row["tipo"] = type;
            row["descripción"] = description;
            row["cantidad"] = qty;
            row["precioUnitario"] = unitaryPrice;
            row["proveedor"] = supplier;

            _dataTableBill.Rows.Add(row);
        }

        public void InsertBillToDb(string type, string supplier, bool bsChecked)
        {
            Bill bill = new Bill();

            bill.Date = DateTime.Now.ToString("dd/MM/yyyy");
            bill.Type = type;

            if (bsChecked)
            {
                foreach (DataRow row in _dataTableBill.Rows)
                {
                    decimal totalPerItem = Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["precioUnitario"]);
                    totalBill += Math.Round(totalPerItem / EXCHANGERATE, 2);
                }
            }
            else
            {
                foreach (DataRow row in _dataTableBill.Rows)
                {
                    decimal totalPerItem = Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["precioUnitario"]);
                    totalBill += Math.Round(totalPerItem, 2);
                }
            }

            bill.Amount = totalBill;
            bill.ExchangeRate = EXCHANGERATE;
            bill.Supplier = supplier;

            if (bsChecked)
            {
                foreach (DataRow row in _dataTableBill.Rows)
                {
                    BillDetail billDetail = new BillDetail()
                    {
                        Description = row["descripción"].ToString(),
                        Quantity = Convert.ToInt32(row["cantidad"]),
                        Amount = Math.Round(Convert.ToDecimal(row["precioUnitario"]) / EXCHANGERATE, 2)
                    };
                    bill.Details.Add(billDetail);
                }
            }
            else
            {
                foreach (DataRow row in _dataTableBill.Rows)
                {
                    BillDetail billDetail = new BillDetail()
                    {
                        Description = row["descripción"].ToString(),
                        Quantity = Convert.ToInt32(row["cantidad"]),
                        Amount = Math.Round(Convert.ToDecimal(row["precioUnitario"]), 2)
                    };
                    bill.Details.Add(billDetail);
                }
            }

            using (var context = new AppDbContext())
            {
                context.Bills.Add(bill);
                context.SaveChanges();
            }
        }

        public Dictionary<string, string> UpdatingIncomeAndWithdrawalCurrentDay()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            decimal totalIncomeBs = 0;
            decimal totalIncomeDollars = 0;
            decimal totalWithdrawalBs = 0;
            decimal totalWithdrawalDollars = 0;

            using (var context = new AppDbContext())
            {
                string today = DateTime.Now.ToString("dd/MM/yyyy"); 

                var sellIds = context.Sells
                    .Where(sell => sell.Date == today)
                    .Select(sell => sell.ID)
                    .ToList();

                var amountsIncomeBs = context.IncomeBs
                    .Where(income => sellIds.Contains(income.SellID))
                    .Select(income => income.Amount)
                    .ToList();

                totalIncomeBs = amountsIncomeBs.Sum();

                var amountsIncomeDollars = context.IncomeDollars
                    .Where(income => sellIds.Contains(income.SellID))
                    .Select(income => income.Amount)
                    .ToList();

                totalIncomeDollars = amountsIncomeDollars.Sum();

                var amountsWithdrawalBs = context.WithdrawalBs
                    .Where(withdrawal => sellIds.Contains(withdrawal.SellID))
                    .Select(withdrawal => withdrawal.Amount)
                    .ToList();

                totalWithdrawalBs = amountsWithdrawalBs.Sum();

                var amountsWithdrawalDollars = context.WithdrawalDollars
                    .Where(withdrawal => sellIds.Contains(withdrawal.SellID))
                    .Select(withdrawal => withdrawal.Amount)
                    .ToList();

                totalWithdrawalDollars = amountsWithdrawalDollars.Sum();
            }

            string incomeBs = totalIncomeBs.ToString();
            string incomeDollars = totalIncomeDollars.ToString();
            string withdrawalBs = totalWithdrawalBs.ToString();
            string withdrawalDollars = totalWithdrawalDollars.ToString();

            dict["incomeBs"] = incomeBs;
            dict["incomeDollars"] = incomeDollars;
            dict["withdrawalBs"] = withdrawalBs;
            dict["withdrawalDollars"] = withdrawalDollars;

            return dict;
        }

        public Dictionary<string, DataTable> PlottingCharts(string from, string to)
        {
            Dictionary<string, DataTable> dictWithDataTables = new Dictionary<string, DataTable>();

            DataTable queryLitersDataTable = new DataTable();

            using (var context = new AppDbContext())
            {
                var query = context.Sells
                    .Where(value => string.Compare(value.Date, from) >= 0 && string.Compare(value.Date, to) <= 0)
                    .GroupBy(x => x.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalLiters = g.Sum(x => (double)x.TotalLiters)
                    })
                    .ToList();

                queryLitersDataTable.Columns.Add("Fecha", typeof(DateTime));
                queryLitersDataTable.Columns.Add("Litros", typeof(double));

                foreach (var item in query)
                {
                    DateTime date = DateTime.Parse(item.Date);
                    queryLitersDataTable.Rows.Add(date, item.TotalLiters);
                }
            }

            DataTable queryMoneyDataTable = new DataTable();

            using (var context = new AppDbContext())
            {
                var query = context.Sells
                    .Where(value => string.Compare(value.Date, from) >= 0 && string.Compare(value.Date, to) <= 0)
                    .GroupBy(x => x.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        Amount = g.Sum(x => (double)x.Amount)
                    })
                    .ToList();

                queryMoneyDataTable.Columns.Add("Fecha", typeof(DateTime));
                queryMoneyDataTable.Columns.Add("Dólares", typeof(double));

                foreach (var item in query)
                {
                    DateTime date = DateTime.Parse(item.Date);
                    queryMoneyDataTable.Rows.Add(date, item.Amount);
                }
            }

            dictWithDataTables["liters"] = queryLitersDataTable;
            dictWithDataTables["money"] = queryMoneyDataTable;

            return dictWithDataTables;
        }

        public void CleanDataTableBill()
        {
            _dataTableBill.Clear();
        }
    }
}