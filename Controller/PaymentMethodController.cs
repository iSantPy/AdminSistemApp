using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAguaPotable.Model;
using System.Data;
using System.Configuration;
using System.Data.SQLite;

namespace ControlAguaPotable.Controller
{
    internal class PaymentMethodController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        public Sell CreateSellAndDetails(DataTable dt, decimal bs, decimal bankBs, decimal dollars, decimal bankBsWithdrawal, decimal withdrawalBs, decimal withdrawalDollars, decimal dollarAmount, decimal exchangeRate)
        {
            decimal totalLiters = dt.AsEnumerable().Sum(row => row.Field<decimal>("litrosTotal"));

            Sell newSell = new Sell();
            newSell.Date = DateTime.Now;
            newSell.TotalLiters = totalLiters;
            newSell.Amount = dollarAmount;
            newSell.ExchangeRate = exchangeRate;

            foreach (DataRow row in dt.Rows)
            {
                int qty = Convert.ToInt32(row["cantidad"]);

                if (qty != 0)
                {
                    SellDetail sellDetail = new SellDetail()
                    {
                        // sellId must be set when calling the method to insert the values
                        Quantity = qty,
                        Presentation = Convert.ToDecimal(row["presentación"]),
                        UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                    };
                    newSell.Details.Add(sellDetail);
                }
            }

            if ((bs != 0 || bankBs != 0) && dollars == 0) // ONLY BS PAY (OR CASH OR TRANFER)
            {
                if (bs != 0 && bankBs == 0) // bs cash only
                {
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                }
                else if (bs == 0 && bankBs != 0) // transfer only
                {
                    newSell.IncomeBankBs = new IncomeBankBs
                    {
                        Amount = bankBs
                    };
                }
                else // bs cash + transfer
                {
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.IncomeBankBs = new IncomeBankBs
                    {
                        Amount = bankBs
                    };
                }

                // bs withdrawal only (cash or transfer)
                if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars == 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0) // bs cash only withdrawal
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }   
                }

                // dollars withdrawal only
                else if ((withdrawalBs == 0 && bankBsWithdrawal == 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }

                // bs + dollar withdrawals
                else if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }
            }

            else if ((bs == 0 && bankBs == 0) && dollars != 0) // ONLY DOLLARS PAY
            {
                newSell.IncomeDollars = new IncomeDollars
                {
                    Amount = dollars
                };

                // bs withdrawal only
                if ((withdrawalBs != 0 || bankBsWithdrawal !=0) && withdrawalDollars == 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount= bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }

                // dollars withdrawal only
                else if ((withdrawalBs == 0 && bankBsWithdrawal == 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }
                   
                // bs + dollar withdrawals
                else if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    if (withdrawalBs !=0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
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
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.IncomeBs = new IncomeBs // cash bs
                    {
                        Amount = bs
                    };
                }
                else if (bs == 0 && bankBs != 0)
                {
                    newSell.IncomeBankBs = new IncomeBankBs
                    {
                        Amount = bankBs
                    };
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                }
                else
                {
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.IncomeBankBs = new IncomeBankBs
                    {
                        Amount = bankBs
                    };
                    newSell.IncomeBs = new IncomeBs // cash bs
                    {
                        Amount = bs
                    };
                }
                
                // bs withdrawal only
                if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars == 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                }

                // dollars withdrawal only
                else if ((withdrawalBs == 0 && bankBsWithdrawal == 0) && withdrawalDollars != 0)
                {
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }

                // bs + dollar withdrawals
                else if ((withdrawalBs != 0 || bankBsWithdrawal != 0) && withdrawalDollars != 0)
                {
                    if (withdrawalBs != 0 && bankBsWithdrawal == 0)
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                    }
                    else if (withdrawalBs == 0 && bankBsWithdrawal != 0)
                    {
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    else
                    {
                        newSell.WithdrawalBs = new WithdrawalBs
                        {
                            Amount = withdrawalBs
                        };
                        newSell.WithdrawalBankBs = new WithdrawalBankBs
                        {
                            Amount = bankBsWithdrawal
                        };
                    }
                    
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };
                }
            }

            return newSell;
        }

        public void RegisterNewSell(Sell newSell)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO Sells (date, totalLiters, Amount, exchangeRate) VALUES (strftime('%s', @date), @totalLiters, @Amount, @exchangeRate)";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@date", newSell.Date);
                            cmd.Parameters.AddWithValue("@totalLiters", newSell.TotalLiters);
                            cmd.Parameters.AddWithValue("@Amount", newSell.Amount);
                            cmd.Parameters.AddWithValue("@exchangeRate", newSell.ExchangeRate);
                            cmd.ExecuteNonQuery();
                            newSell.ID = (int)conn.LastInsertRowId;
                        }

                        foreach (var detail in newSell.Details)
                        {
                            detail.SellID = newSell.ID; // setting sellId for details
                            string detailQuery = "INSERT INTO SellsDetails (sellID, quantity, presentation, unitaryPrice) VALUES (@sellID, @quantity, @presentation, @unitaryPrice)";
                            using (SQLiteCommand detailCmd = new SQLiteCommand(detailQuery, conn))
                            {
                                detailCmd.Parameters.AddWithValue("@sellID", detail.SellID);
                                detailCmd.Parameters.AddWithValue("@quantity", detail.Quantity);
                                detailCmd.Parameters.AddWithValue("@presentation", detail.Presentation);
                                detailCmd.Parameters.AddWithValue("@unitaryPrice", detail.UnitaryPrice);
                                detailCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.IncomeBs != null) 
                        {
                            newSell.IncomeBs.SellID = newSell.ID; // setting sellId for details
                            string incomeBsQuery = "INSERT INTO IncomeBs (sellID, amount) VALUES (@sellID, @amount)";
                            using (SQLiteCommand incomeBsCmd = new SQLiteCommand(incomeBsQuery, conn))
                            {
                                incomeBsCmd.Parameters.AddWithValue("@sellID", newSell.IncomeBs.SellID);
                                incomeBsCmd.Parameters.AddWithValue("@amount", newSell.IncomeBs.Amount);
                                incomeBsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.IncomeDollars != null)
                        {
                            newSell.IncomeDollars.SellID = newSell.ID; // setting sellId for details
                            string incomeDollarsQuery = "INSERT INTO IncomeDollars (sellID, amount) VALUES (@sellID, @amount)";
                            using (SQLiteCommand incomeDollarsCmd = new SQLiteCommand(incomeDollarsQuery, conn))
                            {
                                incomeDollarsCmd.Parameters.AddWithValue("@sellID", newSell.IncomeDollars.SellID);
                                incomeDollarsCmd.Parameters.AddWithValue("@amount", newSell.IncomeDollars.Amount);
                                incomeDollarsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.WithdrawalBs != null) 
                        {
                            newSell.WithdrawalBs.SellID = newSell.ID;
                            string withdrawalBsQuery = "INSERT INTO WithdrawalBs (sellID, amount) VALUES (@sellID, @amount)";
                            using (SQLiteCommand withdrawalBsCmd = new SQLiteCommand(withdrawalBsQuery, conn))
                            {
                                withdrawalBsCmd.Parameters.AddWithValue("@sellID", newSell.WithdrawalBs.SellID);
                                withdrawalBsCmd.Parameters.AddWithValue("@amount", newSell.WithdrawalBs.Amount);
                                withdrawalBsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.WithdrawalDollars != null)
                        {
                            newSell.WithdrawalDollars.SellID = newSell.ID; // setting sellId for details
                            string withdrawalDollarsQuery = "INSERT INTO WithdrawalDollars (sellID, amount) VALUES (@sellID, @amount)";
                            using (SQLiteCommand withdrawalDollarsCmd = new SQLiteCommand(withdrawalDollarsQuery, conn))
                            {
                                withdrawalDollarsCmd.Parameters.AddWithValue("@sellID", newSell.WithdrawalDollars.SellID);
                                withdrawalDollarsCmd.Parameters.AddWithValue("@amount", newSell.WithdrawalDollars.Amount);
                                withdrawalDollarsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.IncomeBankBs != null)
                        {
                            newSell.IncomeBankBs.SellID = newSell.ID;
                            string incomeBankBsQuery = "INSERT INTO IncomeBankBs (sellID, amount) VALUES (@sellID, @amount)";
                            using (SQLiteCommand incomeBankBsCmd = new SQLiteCommand(incomeBankBsQuery, conn))
                            {
                                incomeBankBsCmd.Parameters.AddWithValue("@sellID", newSell.IncomeBankBs.SellID);
                                incomeBankBsCmd.Parameters.AddWithValue("@amount", newSell.IncomeBankBs.Amount);
                                incomeBankBsCmd.ExecuteNonQuery();
                            }
                        }

                        if (newSell.WithdrawalBankBs != null)
                        {
                            newSell.WithdrawalBankBs.SellID = newSell.ID;
                            string withdrawalBankBsQuery = "INSERT INTO WithdrawalBankBs (sellID, amount) VALUES (@sellID, @amount)";
                            using (SQLiteCommand withdrawalBankBsCmd = new SQLiteCommand(withdrawalBankBsQuery, conn))
                            {
                                withdrawalBankBsCmd.Parameters.AddWithValue("@sellID", newSell.WithdrawalBankBs.SellID);
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
