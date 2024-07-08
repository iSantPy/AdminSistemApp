using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ControlAguaPotable.Model;
using System.Configuration;
using System.Data.SQLite;

namespace ControlAguaPotable.Controller
{
    internal class MainWindowController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        Bill bill = new Bill();

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

        public Bill CreateBill(string type, string supplier, bool bsChecked) 
        {
            bill.Date = DateTime.Now;
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
                        // billId must be setted when inserting a newbill into the db
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
                        // billId must be set when inserting a newbill into the db
                        Description = row["descripción"].ToString(),
                        Quantity = Convert.ToInt32(row["cantidad"]),
                        Amount = Math.Round(Convert.ToDecimal(row["precioUnitario"]), 2)
                    };
                    bill.Details.Add(billDetail);
                }
            }
            
            return bill;
        }

        public void InsertBillToDb(Bill newBill)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO Bills (date, type, amount, supplier, exchangeRate) VALUES (strftime('%s', @date), @type, @amount, @supplier, @exchangeRate)";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@date", newBill.Date);
                            cmd.Parameters.AddWithValue("@type", newBill.Type);
                            cmd.Parameters.AddWithValue("@amount", newBill.Amount);
                            cmd.Parameters.AddWithValue("@supplier", newBill.Supplier);
                            cmd.Parameters.AddWithValue("@exchangeRate", newBill.ExchangeRate);
                            cmd.ExecuteNonQuery();
                            newBill.ID = (int)conn.LastInsertRowId;
                        }

                        foreach (var detail in newBill.Details)
                        {
                            detail.BillID = newBill.ID; 
                            string detailQuery = "INSERT INTO BillsDetails (billID, description, quantity, amount) VALUES (@billID, @description, @quantity, @amount)";
                            using (SQLiteCommand detailCmd = new SQLiteCommand(detailQuery, conn))
                            {
                                detailCmd.Parameters.AddWithValue("@billID", detail.BillID);
                                detailCmd.Parameters.AddWithValue("@description", detail.Description); 
                                detailCmd.Parameters.AddWithValue("@quantity", detail.Quantity); 
                                detailCmd.Parameters.AddWithValue("@amount", detail.Amount);
                                detailCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }

                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Dictionary<string, string> UpdatingIncomeAndWithdrawalCurrentDay()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            decimal totalIncomeBs = 0;
            decimal totalIncomeDollars = 0;
            decimal totalIncomeBankBs = 0;
            decimal totalWithdrawalBs = 0;
            decimal totalWithdrawalDollars = 0;
            decimal totalWithdrawalBankBs = 0;

            DateTime today = DateTime.Today.Date;
            List<int> sellIds = new List<int>();
            List<decimal> amountsIncomeBs = new List<decimal>();
            List<decimal> amountsIncomeDollars = new List<decimal>();
            List<decimal> amountsIncomeBankBs = new List<decimal>();
            List<decimal> amountsWithdrawalBs = new List<decimal>();
            List<decimal> amountsWithdrawalDollars = new List<decimal>();
            List<decimal> amountsWithdrawalBankBs = new List<decimal>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string querySellIds = "SELECT id, datetime(date, 'unixepoch') FROM Sells WHERE date(date, 'unixepoch') = date(@today);";
                using (SQLiteCommand cmd = new SQLiteCommand(querySellIds, conn))
                {
                    cmd.Parameters.AddWithValue("@today", today);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sellIds.Add(reader.GetInt32(0));
                        }
                    }
                }

                if (sellIds.Count > 0)
                {
                    string sellIdsString = string.Join(",", sellIds);

                    string queryIncomeBs = $"SELECT amount FROM IncomeBs WHERE sellID IN ({sellIdsString})";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryIncomeBs, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                amountsIncomeBs.Add(reader.GetDecimal(0));
                            }
                        }
                    }

                    string queryIncomeDollars = $"SELECT amount FROM IncomeDollars WHERE sellID IN ({sellIdsString})";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryIncomeDollars, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                amountsIncomeDollars.Add(reader.GetDecimal(0));
                            }
                        }
                    }

                    string queryIncomeBankBs = $"SELECT amount FROM IncomeBankBs WHERE sellID IN ({sellIdsString})";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryIncomeBankBs, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                amountsIncomeBankBs.Add(reader.GetDecimal(0));
                            }
                        }
                    }

                    string queryWithdrawalBs = $"SELECT amount FROM WithdrawalBs WHERE sellID IN ({sellIdsString})";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryWithdrawalBs, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                amountsWithdrawalBs.Add(reader.GetDecimal(0));
                            }
                        }
                    }

                    string queryWithdrawalDollars = $"SELECT amount FROM WithdrawalDollars WHERE sellID IN ({sellIdsString})";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryWithdrawalDollars, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                amountsWithdrawalDollars.Add(reader.GetDecimal(0));
                            }
                        }
                    }

                    string queryWithdrawalBankBs = $"SELECT amount FROM WithdrawalBankBs WHERE sellID IN ({sellIdsString})";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryWithdrawalBankBs, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                amountsWithdrawalBankBs.Add(reader.GetDecimal(0));
                            }
                        }
                    }
                }
            }

            totalIncomeBs = amountsIncomeBs.Sum();
            totalIncomeDollars = amountsIncomeDollars.Sum();
            totalIncomeBankBs = amountsIncomeBankBs.Sum();
            totalWithdrawalBs = amountsWithdrawalBs.Sum();
            totalWithdrawalDollars = amountsWithdrawalDollars.Sum();
            totalWithdrawalBankBs = amountsWithdrawalBankBs.Sum();

            string incomeBs = (totalIncomeBs + totalIncomeBankBs).ToString();
            string incomeDollars = totalIncomeDollars.ToString();
            string withdrawalBs = (totalWithdrawalBs + totalWithdrawalBankBs).ToString();
            string withdrawalDollars = totalWithdrawalDollars.ToString();

            dict["incomeBs"] = incomeBs;
            dict["incomeDollars"] = incomeDollars;
            dict["withdrawalBs"] = withdrawalBs;
            dict["withdrawalDollars"] = withdrawalDollars;

            return dict;
        }

        public Dictionary<string, DataTable> PlottingCharts(DateTime from, DateTime to)
        {
            Dictionary<string, DataTable> dictWithDataTables = new Dictionary<string, DataTable>();

            DataTable queryLitersDataTable = new DataTable();
            queryLitersDataTable.Columns.Add("Fecha", typeof(DateTime));
            queryLitersDataTable.Columns.Add("Litros", typeof(double));

            DataTable queryMoneyDataTable = new DataTable();
            queryMoneyDataTable.Columns.Add("Fecha", typeof(DateTime));
            queryMoneyDataTable.Columns.Add("Dólares", typeof(double));

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string queryLiters = @"
                    SELECT datetime(date, 'unixepoch') as date, SUM(totalLiters) AS TotalLiters
                    FROM Sells
                    WHERE date(date, 'unixepoch') >= date(@from) AND date(date, 'unixepoch') <= date(@to)
                    GROUP BY date(date, 'unixepoch')";

                using (SQLiteCommand cmdLiters = new SQLiteCommand(queryLiters, conn))
                {
                    cmdLiters.Parameters.AddWithValue("@from", from);
                    cmdLiters.Parameters.AddWithValue("@to", to);

                    using (SQLiteDataReader reader = cmdLiters.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = DateTime.Parse(reader["Date"].ToString());
                            double totalLiters = Convert.ToDouble(reader["TotalLiters"]);
                            queryLitersDataTable.Rows.Add(date, totalLiters);
                        }
                    }
                }

                string queryMoney = @"
                    SELECT datetime(date, 'unixepoch') as date, SUM(Amount) AS Amount
                    FROM Sells
                    WHERE date(date, 'unixepoch') >= date(@from) AND date(date, 'unixepoch') <= date(@to)
                    GROUP BY date(date, 'unixepoch')";

                using (SQLiteCommand cmdMoney = new SQLiteCommand(queryMoney, conn))
                {
                    cmdMoney.Parameters.AddWithValue("@from", from);
                    cmdMoney.Parameters.AddWithValue("@to", to);

                    using (SQLiteDataReader reader = cmdMoney.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = DateTime.Parse(reader["Date"].ToString());
                            double amount = Convert.ToDouble(reader["Amount"]);
                            queryMoneyDataTable.Rows.Add(date, amount);
                        }
                    }
                }
            }

            dictWithDataTables["liters"] = queryLitersDataTable;
            dictWithDataTables["money"] = queryMoneyDataTable;

            return dictWithDataTables;
        }

        public void CleanDataTableBill()
        {
            _dataTableBill.Clear();
            bill.ResetAttributes();
            totalBill = 0;
        }
    }
}