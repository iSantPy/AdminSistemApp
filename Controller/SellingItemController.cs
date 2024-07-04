using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ControlAguaPotable.Model;

namespace ControlAguaPotable.Controller
{
    internal class SellingItemController
    {
        private DataTable _dtInventory = new DataTable();
        private DataTable _dtBuyItems = new DataTable();

        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public DataTable ReadInventoryTableFromDb()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Inventory";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.Fill(_dtInventory);
                }
            }

            return _dtInventory;
        }

        public DataTable CreateBuyDataTable()
        {
            _dtBuyItems.Columns.Add("id", typeof(int));
            _dtBuyItems.Columns.Add("descripción", typeof(string));
            _dtBuyItems.Columns.Add("cantidad", typeof(int));
            _dtBuyItems.Columns.Add("precioUnitario", typeof(decimal));

            return _dtBuyItems;
        }

        public DataTable InsertNewRowToDataTable(DataTable buyItemsDataTable, int id, string description, int qty, decimal unitaryPrice)
        {
            DataRow newRow = buyItemsDataTable.NewRow();

            newRow["id"] = id;
            newRow["descripción"] = description;
            newRow["cantidad"] = qty;
            newRow["precioUnitario"] = unitaryPrice;

            buyItemsDataTable.Rows.Add(newRow);

            return buyItemsDataTable;
        }

        public DataTable UpdatingSubstractedTable(DataTable substractedTable, int id, int qty)
        {
            DataRow[] rows = substractedTable.Select($"id = {id}");

            DataRow row = rows[0];

            int currentStock = Convert.ToInt32(row["stock"]);

            int newStock = currentStock - qty;

            row["stock"] = newStock;

            return substractedTable;
        }

        public void UpdateStockFromDb(DataTable substractedDataTable)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                foreach (DataRow row in substractedDataTable.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    int stock = Convert.ToInt32(row["stock"]);

                    Inventory newStock = new Inventory()
                    {
                        ID = id,
                        Stock = stock
                    };

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            if (newStock.Stock != 0)
                            {
                                string query = "UPDATE Inventory SET stock = @stock WHERE id = @id";
                                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", newStock.ID);
                                    cmd.Parameters.AddWithValue("@stock", stock);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }

                            else
                            {
                                string query = "DELETE FROM Inventory WHERE id = @id";
                                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", newStock.ID);
                                    cmd.Parameters.AddWithValue("@stock", stock);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                        }

                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
                
        }

        public Dictionary<string, decimal> SetMoneyValues(DataTable buyItemsDataTable, decimal EXCHANGERATE)
        {
            Dictionary<string, decimal> dictResultsMoney = new Dictionary<string, decimal>();

            decimal moneyBs = 0;
            decimal moneyDollars = 0;

            foreach (DataRow row in buyItemsDataTable.Rows)
            {
                moneyDollars += Math.Round(Convert.ToDecimal(row["cantidad"]) * Convert.ToDecimal(row["precioUnitario"]), 2);
            }

            moneyBs = Math.Round(moneyDollars * EXCHANGERATE, 2);

            dictResultsMoney["moneyBs"] = moneyBs;
            dictResultsMoney["moneyDollars"] = moneyDollars;

            return dictResultsMoney;
        }

        public SellItems CreateSellAndDetails(DataTable dt, decimal bs, decimal bankBs, decimal dollars, decimal bankBsWithdrawal, decimal withdrawalBs, decimal withdrawalDollars, decimal dollarAmount, decimal exchangeRate)
        { 
            SellItems newSell = new SellItems();
            newSell.Date = DateTime.Now;
            newSell.Amount = dollarAmount;
            newSell.ExchangeRate = exchangeRate;

            foreach (DataRow row in dt.Rows)
            {
                int qty = Convert.ToInt32(row["cantidad"]);

                if (qty != 0)
                {
                    SellItemsDetails sellDetail = new SellItemsDetails()
                    {
                        // sellId must be set when calling the method to insert the values
                        ItemID = Convert.ToInt32(row["id"]),
                        Quantity = qty,
                    };
                    newSell.Details.Add(sellDetail);
                }
            }

            if ((bs != 0 || bankBs != 0) && dollars == 0) // ONLY BS PAY (OR CASH OR TRANFER)
            {
                if (bs != 0 && bankBs == 0) // bs cash only
                {
                    newSell.IncomeBs = new ItemsIncomeBs
                    {
                        Amount = bs
                    };
                }
                else if (bs == 0 && bankBs != 0) // transfer only
                {
                    newSell.IncomeBankBs = new ItemsIncomeBankBs
                    {
                        Amount = bankBs
                    };
                }
                else // bs cash + transfer
                {
                    newSell.IncomeBs = new ItemsIncomeBs
                    {
                        Amount = bs
                    };
                    newSell.IncomeBankBs = new ItemsIncomeBankBs
                    {
                        Amount = bankBs
                    };
                }

                // bs withdrawal only (cash or transfer)
                if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars == 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0) // bs cash only withdrawal
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }

                // dollars withdrawal only
                else if ((withdrawalBs == 0 && bankBsWithdrawal == 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new ItemsWithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }

                // bs + dollar withdrawals
                else if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new ItemsWithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }
            }

            else if ((bs == 0 && bankBs == 0) && dollars != 0) // ONLY DOLLARS PAY
            {
                newSell.IncomeDollars = new ItemsIncomeDollars
                {
                    Amount = dollars
                };

                // bs withdrawal only
                if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars == 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }

                // dollars withdrawal only
                else if ((withdrawalBs == 0 && bankBsWithdrawal == 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new ItemsWithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }

                // bs + dollar withdrawals
                else if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new ItemsWithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }
            }

            else // BS + DOLLARS PAY
            {
                if (bs != 0 && bankBs == 0)
                {
                    newSell.IncomeDollars = new ItemsIncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.IncomeBs = new ItemsIncomeBs // cash bs
                    {
                        Amount = bs
                    };
                }
                else if (bs == 0 && bankBs != 0)
                {
                    newSell.IncomeBankBs = new ItemsIncomeBankBs
                    {
                        Amount = bankBs
                    };
                    newSell.IncomeDollars = new ItemsIncomeDollars
                    {
                        Amount = dollars
                    };
                }
                else
                {
                    newSell.IncomeDollars = new ItemsIncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.IncomeBankBs = new ItemsIncomeBankBs
                    {
                        Amount = bankBs
                    };
                    newSell.IncomeBs = new ItemsIncomeBs // cash bs
                    {
                        Amount = bs
                    };
                }

                // bs withdrawal only
                if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars == 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }

                // dollars withdrawal only
                else if ((withdrawalBs == 0 && bankBsWithdrawal == 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new ItemsWithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }

                // bs + dollar withdrawals
                else if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars != 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new ItemsWithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new ItemsWithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }

                    newSell.WithdrawalDollars = new ItemsWithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }
            }

            return newSell;
        }

        public void RegisterNewSell(SellItems newSell)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO SellsItems (date, Amount, exchangeRate) VALUES (strftime('%s', @date), @Amount, @exchangeRate)";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@date", newSell.Date);
                            cmd.Parameters.AddWithValue("@Amount", newSell.Amount);
                            cmd.Parameters.AddWithValue("@exchangeRate", newSell.ExchangeRate);
                            cmd.ExecuteNonQuery();
                            newSell.ID = (int)conn.LastInsertRowId;
                        }

                        foreach (var detail in newSell.Details)
                        {
                            detail.SellID = newSell.ID; // setting sellId for details
                            string detailQuery = "INSERT INTO SellItemsDetails (idSell, idItem, quantity) VALUES (@idSell, @idItem, @quantity)";
                            using (SQLiteCommand detailCmd = new SQLiteCommand(detailQuery, conn))
                            {
                                detailCmd.Parameters.AddWithValue("@idSell", detail.SellID);
                                detailCmd.Parameters.AddWithValue("@idItem", detail.ItemID);
                                detailCmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                detailCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.IncomeBs != null)
                        {
                            newSell.IncomeBs.SellID = newSell.ID; // setting sellId for details
                            string incomeBsQuery = "INSERT INTO IncomeBsSellsItems (idSell, amount) VALUES (@idSell, @amount)";
                            using (SQLiteCommand incomeBsCmd = new SQLiteCommand(incomeBsQuery, conn))
                            {
                                incomeBsCmd.Parameters.AddWithValue("@idSell", newSell.IncomeBs.SellID);
                                incomeBsCmd.Parameters.AddWithValue("@amount", newSell.IncomeBs.Amount);
                                incomeBsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.IncomeDollars != null)
                        {
                            newSell.IncomeDollars.SellID = newSell.ID; // setting sellId for details
                            string incomeDollarsQuery = "INSERT INTO IncomeDollarsSellsItems (idSell, amount) VALUES (@idSell, @amount)";
                            using (SQLiteCommand incomeDollarsCmd = new SQLiteCommand(incomeDollarsQuery, conn))
                            {
                                incomeDollarsCmd.Parameters.AddWithValue("@idSell", newSell.IncomeDollars.SellID);
                                incomeDollarsCmd.Parameters.AddWithValue("@amount", newSell.IncomeDollars.Amount);
                                incomeDollarsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.WithdrawalBs != null)
                        {
                            newSell.WithdrawalBs.SellID = newSell.ID;
                            string withdrawalBsQuery = "INSERT INTO WithdrawalBsSellsItems (idSell, amount) VALUES (@idSell, @amount)";
                            using (SQLiteCommand withdrawalBsCmd = new SQLiteCommand(withdrawalBsQuery, conn))
                            {
                                withdrawalBsCmd.Parameters.AddWithValue("@idSell", newSell.WithdrawalBs.SellID);
                                withdrawalBsCmd.Parameters.AddWithValue("@amount", newSell.WithdrawalBs.Amount);
                                withdrawalBsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.WithdrawalDollars != null)
                        {
                            newSell.WithdrawalDollars.SellID = newSell.ID; // setting sellId for details
                            string withdrawalDollarsQuery = "INSERT INTO WithdrawalDollarsSellsItems (idSell, amount) VALUES (@idSell, @amount)";
                            using (SQLiteCommand withdrawalDollarsCmd = new SQLiteCommand(withdrawalDollarsQuery, conn))
                            {
                                withdrawalDollarsCmd.Parameters.AddWithValue("@idSell", newSell.WithdrawalDollars.SellID);
                                withdrawalDollarsCmd.Parameters.AddWithValue("@amount", newSell.WithdrawalDollars.Amount);
                                withdrawalDollarsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.IncomeBankBs != null)
                        {
                            newSell.IncomeBankBs.SellID = newSell.ID;
                            string incomeBankBsQuery = "INSERT INTO IncomeBankBsSellsItems (idSell, amount) VALUES (@idSell, @amount)";
                            using (SQLiteCommand incomeBankBsCmd = new SQLiteCommand(incomeBankBsQuery, conn))
                            {
                                incomeBankBsCmd.Parameters.AddWithValue("@idSell", newSell.IncomeBankBs.SellID);
                                incomeBankBsCmd.Parameters.AddWithValue("@amount", newSell.IncomeBankBs.Amount);
                                incomeBankBsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.WithdrawalBankBs != null)
                        {
                            newSell.WithdrawalBankBs.SellID = newSell.ID;
                            string withdrawalBankBsQuery = "INSERT INTO WithdrawalBankBsSellsItems (idSell, amount) VALUES (@idSell, @amount)";
                            using (SQLiteCommand withdrawalBankBsCmd = new SQLiteCommand(withdrawalBankBsQuery, conn))
                            {
                                withdrawalBankBsCmd.Parameters.AddWithValue("@idSell", newSell.WithdrawalBankBs.SellID);
                                withdrawalBankBsCmd.Parameters.AddWithValue("@amount", newSell.WithdrawalBankBs.Amount);
                                withdrawalBankBsCmd.ExecuteNonQuery();
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
    }
}
