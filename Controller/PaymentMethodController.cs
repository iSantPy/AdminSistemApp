using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAguaPotable.Model;
using System.Data;

namespace ControlAguaPotable.Controller
{
    internal class PaymentMethodController
    {
        public void RegisterSellAndSellDetail(DataTable dt, decimal bs, decimal dollars, decimal withdrawalBs, decimal withdrawalDollars, decimal dollarAmount, decimal exchangeRate)
        {
            decimal totalLiters = dt.AsEnumerable().Sum(row => row.Field<decimal>("litrosTotal"));

            var newSell = new Sell();

            if (bs != 0 && dollars == 0) // only bs
            {
                // no withdrawal
                if (withdrawalBs == 0 && withdrawalDollars == 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // bs withdrawal only
                else if (withdrawalBs != 0 && withdrawalDollars == 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.WithdrawalBs = new WithdrawalBs
                    {
                        Amount = withdrawalBs
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // dollars withdrawal only
                else if (withdrawalBs == 0 && withdrawalDollars != 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // bs + dollar withdrawals
                else if (withdrawalBs != 0 && withdrawalDollars != 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.WithdrawalBs = new WithdrawalBs
                    {
                        Amount = withdrawalBs
                    };
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }
            }
            else if (bs == 0 && dollars != 0) // only dollars
            {
                // no withdrawal
                if (withdrawalBs == 0 && withdrawalDollars == 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // bs withdrawal only
                else if (withdrawalBs != 0 && withdrawalDollars == 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.WithdrawalBs = new WithdrawalBs
                    {
                        Amount = withdrawalBs
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // dollars withdrawal only
                else if (withdrawalBs == 0 && withdrawalDollars != 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // bs + dollar withdrawals
                else if (withdrawalBs != 0 && withdrawalDollars != 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.WithdrawalBs = new WithdrawalBs
                    {
                        Amount = withdrawalBs
                    };
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

            }
            else // combination of bs and dollars
            {
                // no withdrawal
                if (withdrawalBs ==0 && withdrawalBs == 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // bs withdrawal only
                else if (withdrawalBs != 0 && withdrawalDollars == 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.WithdrawalBs = new WithdrawalBs
                    {
                        Amount = withdrawalBs
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // dollars withdrawal only
                else if (withdrawalBs == 0 && withdrawalDollars != 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

                // bs + dollar withdrawals
                else if (withdrawalBs != 0 && withdrawalDollars != 0)
                {
                    newSell.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    newSell.TotalLiters = totalLiters;
                    newSell.Amount = dollarAmount;
                    newSell.ExchangeRate = exchangeRate;
                    newSell.IncomeBs = new IncomeBs
                    {
                        Amount = bs
                    };
                    newSell.IncomeDollars = new IncomeDollars
                    {
                        Amount = dollars
                    };
                    newSell.WithdrawalBs = new WithdrawalBs
                    {
                        Amount = withdrawalBs
                    };
                    newSell.WithdrawalDollars = new WithdrawalDollars
                    {
                        Amount = withdrawalDollars
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        int qty = Convert.ToInt32(row["cantidad"]);

                        if (qty != 0)
                        {
                            SellDetail sellDetail = new SellDetail()
                            {
                                Quantity = qty,
                                Presentation = Convert.ToDecimal(row["presentación"]),
                                UnitaryPrice = Convert.ToDecimal(row["precioUnitario"])
                            };
                            newSell.Details.Add(sellDetail);
                        }
                    }
                }

            }
            
            using (var context = new AppDbContext())
            {
                context.Sells.Add(newSell);
                context.SaveChanges();
            }
        }
    }
}
