using ControlAguaPotable.Model;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace ControlAguaPotable.Controller
{
    internal class ReportController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public List<QueryReportResult> GettingReportInfo(string from, string to)
        {
            List<QueryReportResult> queryReportResultsList = new List<QueryReportResult>();

            string fromDate, toDate;

            try
            { 
                fromDate = ConvertDateFormat(from);
                toDate = ConvertDateFormat(to);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return queryReportResultsList;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        s.id, 
                        datetime(s.date, 'unixepoch') AS DateTime, 
                        s.totalLiters,
                        COALESCE(inBs.amount, 0) AS IncomeBs, 
                        COALESCE(inDollars.amount, 0) AS IncomeDollars,
                        COALESCE(inBankBs.amount, 0) AS IncomeBankBs,
                        COALESCE(wdBs.amount, 0) AS WithdrawalBs,
                        COALESCE(wdDollars.amount, 0) AS WithdrawalDollars,
                        COALESCE(wdBankBs.amount, 0) AS WithdrawalBankBs
                    FROM Sells s
                    LEFT JOIN IncomeBs inBs ON s.id = inBs.sellID
                    LEFT JOIN IncomeDollars inDollars ON s.id = inDollars.sellID
                    LEFT JOIN IncomeBankBs inBankBs ON s.id = inBankBs.sellID
                    LEFT JOIN WithdrawalBs wdBs ON s.id = wdBs.sellID
                    LEFT JOIN WithdrawalDollars wdDollars ON s.id = wdDollars.sellID
                    LEFT JOIN WithdrawalBankBs wdBankBs ON s.id = wdBankBs.sellID
                    WHERE date(s.date, 'unixepoch') >= @from AND date(s.date, 'unixepoch') <= @to
                    ORDER BY s.date";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            QueryReportResult result = new QueryReportResult
                            {
                                DateTime = reader.GetDateTime(reader.GetOrdinal("DateTime")),
                                TotalLiters = reader.GetDecimal(reader.GetOrdinal("totalLiters")),
                                IncomeBs = reader.GetDecimal(reader.GetOrdinal("IncomeBs")),
                                IncomeDollars = reader.GetDecimal(reader.GetOrdinal("IncomeDollars")),
                                IncomeBankBs = reader.GetDecimal(reader.GetOrdinal("IncomeBankBs")),
                                WithdrawalBs = reader.GetDecimal(reader.GetOrdinal("WithdrawalBs")),
                                WithdrawalDollars = reader.GetDecimal(reader.GetOrdinal("WithdrawalDollars")),
                                WithdrawalBankBs = reader.GetDecimal(reader.GetOrdinal("WithdrawalBankBs"))
                            };
                            queryReportResultsList.Add(result);
                        }
                    }
                }
            }

            return queryReportResultsList;
        }

        public List<ItemQueryReportResult> GettingReportItemsInfo(string from, string to)
        {
            List<ItemQueryReportResult> queryItemReportResultsList = new List<ItemQueryReportResult>();

            string fromDate, toDate;

            try
            {
                fromDate = ConvertDateFormat(from);
                toDate = ConvertDateFormat(to);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return queryItemReportResultsList;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                    s.id AS Id, 
                    datetime(s.date, 'unixepoch') AS DateTime, 
                    i.description AS Product,
                    i.unitaryPrice AS Unitary_Price,
                    d.quantity AS QuantitySold,
                    COALESCE(inBs.amount, 0) AS IncomeBsSellsItems, 
                    COALESCE(inDollars.amount, 0) AS IncomeDollarsSellsItems,
                    COALESCE(inBankBs.amount, 0) AS IncomeBankBsSellsItems,
                    COALESCE(wdBs.amount, 0) AS WithdrawalBsSellsItems,
                    COALESCE(wdDollars.amount, 0) AS WithdrawalDollarsSellsItems,
                    COALESCE(wdBankBs.amount, 0) AS WithdrawalBankBsSellsItems
                FROM SellsItems s
                LEFT JOIN SellItemsDetails d ON s.id = d.idSell
                LEFT JOIN Inventory i ON d.idItem = i.id
                LEFT JOIN IncomeBsSellsItems inBs ON s.id = inBs.idSell
                LEFT JOIN IncomeDollarsSellsItems inDollars ON s.id = inDollars.idSell
                LEFT JOIN IncomeBankBsSellsItems inBankBs ON s.id = inBankBs.idSell
                LEFT JOIN WithdrawalBsSellsItems wdBs ON s.id = wdBs.idSell
                LEFT JOIN WithdrawalDollarsSellsItems wdDollars ON s.id = wdDollars.idSell
                LEFT JOIN WithdrawalBankBsSellsItems wdBankBs ON s.id = wdBankBs.idSell
                WHERE date(s.date, 'unixepoch') >= @from AND date(s.date, 'unixepoch') <= @to
                ORDER BY s.date";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemQueryReportResult result = new ItemQueryReportResult
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("Id")),
                                DateTime = reader.GetDateTime(reader.GetOrdinal("DateTime")),
                                Product = reader.GetString(reader.GetOrdinal("Product")),
                                UnitaryPrice = reader.GetInt32(reader.GetOrdinal("Unitary_Price")),
                                QuantitySold = reader.GetInt32(reader.GetOrdinal("QuantitySold")),
                                IncomeBsSellsItems = reader.GetDecimal(reader.GetOrdinal("IncomeBsSellsItems")),
                                IncomeDollarsSellsItems = reader.GetDecimal(reader.GetOrdinal("IncomeDollarsSellsItems")),
                                IncomeBankBsSellsItems = reader.GetDecimal(reader.GetOrdinal("IncomeBankBsSellsItems")),
                                WithdrawalBsSellsItems = reader.GetDecimal(reader.GetOrdinal("WithdrawalBsSellsItems")),
                                WithdrawalDollarsSellsItems = reader.GetDecimal(reader.GetOrdinal("WithdrawalDollarsSellsItems")),
                                WithdrawalBankBsSellsItems = reader.GetDecimal(reader.GetOrdinal("WithdrawalBankBsSellsItems"))
                            };
                            queryItemReportResultsList.Add(result);
                        }
                    }
                }
            }

            return queryItemReportResultsList;
        }

        public List<BillReportResult> GettingReportBillInfo(string from, string to)
        {
            List<BillReportResult> queryBillReportResultsList = new List<BillReportResult>();

            string fromDate, toDate;

            try
            {
                fromDate = ConvertDateFormat(from);
                toDate = ConvertDateFormat(to);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return queryBillReportResultsList;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                        SELECT 
                        b.id AS Id, 
                        datetime(b.date, 'unixepoch') AS DateTime, 
	                    b.amount AS Total,
                        d.description AS Product,
	                    d.quantity AS Qty,
	                    d.amount AS Unitary_Price
                    FROM Bills b
                    LEFT JOIN BillsDetails d ON b.id = d.billID
                    WHERE date(b.date, 'unixepoch') >= @from AND date(b.date, 'unixepoch') <= @to
                    ORDER BY b.date";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BillReportResult result = new BillReportResult
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("Id")),
                                DateTime = reader.GetDateTime(reader.GetOrdinal("DateTime")),
                                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                Product = reader.GetString(reader.GetOrdinal("Product")),
                                Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                                UnitaryPrice = reader.GetInt32(reader.GetOrdinal("Unitary_Price")),

                            };
                            queryBillReportResultsList.Add(result);
                        }
                    }
                }
            }

            return queryBillReportResultsList;
        }

        public void GeneratePdfReport(List<QueryReportResult> reportResults, List<ItemQueryReportResult> itemReportResults, List<BillReportResult> billReportResults)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Reporte de Ventas";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 10);
            XFont headerFont = new XFont("Verdana", 10);

            int yPoint = 40;
            double pageWidth = page.Width - 40;
            double[] columnWidths = { 120, 70, 70, 70, 70, 70, 70 };
            double tableWidth = columnWidths.Sum();

            string reportTitle = $"Reporte de Ventas {DateTime.Today:dd/MM/yyyy}";
            gfx.DrawString(reportTitle, new XFont("Verdana", 12), XBrushes.Black, new XPoint(40, yPoint));
            yPoint += 30;

            // Draw first table header
            gfx.DrawString("Fecha", headerFont, XBrushes.Black, new XPoint(40, yPoint));
            gfx.DrawString("Litros", headerFont, XBrushes.Black, new XPoint(160, yPoint));
            gfx.DrawString("Bs", headerFont, XBrushes.Black, new XPoint(220, yPoint));
            gfx.DrawString("USD", headerFont, XBrushes.Black, new XPoint(300, yPoint));
            gfx.DrawString("Tr. Bs", headerFont, XBrushes.Black, new XPoint(380, yPoint));
            gfx.DrawString("V. Bs", headerFont, XBrushes.Black, new XPoint(460, yPoint));
            gfx.DrawString("V. USD", headerFont, XBrushes.Black, new XPoint(540, yPoint));
            gfx.DrawString("V. Tr.", headerFont, XBrushes.Black, new XPoint(620, yPoint));
            yPoint += 20;

            decimal totalLiters = 0;
            decimal totalIncomeBs = 0;
            decimal totalIncomeDollars = 0;
            decimal totalIncomeBankBs = 0;
            decimal totalWithdrawalBs = 0;
            decimal totalWithdrawalDollars = 0;
            decimal totalWithdrawalBankBs = 0;

            foreach (var result in reportResults)
            {
                if (yPoint > page.Height - 40)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = 40;

                    gfx.DrawString("Fecha", headerFont, XBrushes.Black, new XPoint(40, yPoint));
                    gfx.DrawString("Litros", headerFont, XBrushes.Black, new XPoint(160, yPoint));
                    gfx.DrawString("Bs", headerFont, XBrushes.Black, new XPoint(220, yPoint));
                    gfx.DrawString("USD", headerFont, XBrushes.Black, new XPoint(300, yPoint));
                    gfx.DrawString("Tr. Bs", headerFont, XBrushes.Black, new XPoint(380, yPoint));
                    gfx.DrawString("V. Bs", headerFont, XBrushes.Black, new XPoint(460, yPoint));
                    gfx.DrawString("V. USD", headerFont, XBrushes.Black, new XPoint(540, yPoint));
                    gfx.DrawString("V. Tr.", headerFont, XBrushes.Black, new XPoint(620, yPoint));
                    yPoint += 20;
                }

                gfx.DrawString(result.DateTime.ToString("yyyy-MM-dd HH:mm"), font, XBrushes.Black, new XPoint(40, yPoint));
                gfx.DrawString(result.TotalLiters.ToString(), font, XBrushes.Black, new XPoint(160, yPoint));
                gfx.DrawString(result.IncomeBs.ToString(), font, XBrushes.Black, new XPoint(220, yPoint));
                gfx.DrawString(result.IncomeDollars.ToString(), font, XBrushes.Black, new XPoint(300, yPoint));
                gfx.DrawString(result.IncomeBankBs.ToString(), font, XBrushes.Black, new XPoint(380, yPoint));
                gfx.DrawString(result.WithdrawalBs.ToString(), font, XBrushes.Black, new XPoint(460, yPoint));
                gfx.DrawString(result.WithdrawalDollars.ToString(), font, XBrushes.Black, new XPoint(540, yPoint));
                gfx.DrawString(result.WithdrawalBankBs.ToString(), font, XBrushes.Black, new XPoint(620, yPoint));

                totalLiters += result.TotalLiters;
                totalIncomeBs += result.IncomeBs;
                totalIncomeDollars += result.IncomeDollars;
                totalIncomeBankBs += result.IncomeBankBs;
                totalWithdrawalBs += result.WithdrawalBs;
                totalWithdrawalDollars += result.WithdrawalDollars;
                totalWithdrawalBankBs += result.WithdrawalBankBs;

                yPoint += 20;
            }

            gfx.DrawLine(XPens.Black, 40, yPoint, 580, yPoint);
            yPoint += 10;

            gfx.DrawString("Total", headerFont, XBrushes.Black, new XPoint(40, yPoint));
            gfx.DrawString(totalLiters.ToString(), font, XBrushes.Black, new XPoint(160, yPoint));
            gfx.DrawString(totalIncomeBs.ToString(), font, XBrushes.Black, new XPoint(220, yPoint));
            gfx.DrawString(totalIncomeDollars.ToString(), font, XBrushes.Black, new XPoint(300, yPoint));
            gfx.DrawString(totalIncomeBankBs.ToString(), font, XBrushes.Black, new XPoint(380, yPoint));
            gfx.DrawString(totalWithdrawalBs.ToString(), font, XBrushes.Black, new XPoint(460, yPoint));
            gfx.DrawString(totalWithdrawalDollars.ToString(), font, XBrushes.Black, new XPoint(540, yPoint));
            gfx.DrawString(totalWithdrawalBankBs.ToString(), font, XBrushes.Black, new XPoint(620, yPoint));

            // Leave space before the next table
            yPoint += 40;

            // Draw second table header
            gfx.DrawString("Fecha", headerFont, XBrushes.Black, new XPoint(40, yPoint));
            gfx.DrawString("Producto", headerFont, XBrushes.Black, new XPoint(160, yPoint));
            gfx.DrawString("Cantidad Vendida", headerFont, XBrushes.Black, new XPoint(320, yPoint));
            gfx.DrawString("Precio Unitario", headerFont, XBrushes.Black, new XPoint(480, yPoint));
            yPoint += 20;

            // Agrupar por ID y calcular totalizaciones
            var groupedResults = itemReportResults
                .GroupBy(i => i.ID)
                .Select(g => new
                {
                    ID = g.Key,
                    DateTime = g.First().DateTime,
                    Product = g.First().Product,
                    UnitaryPrice = g.First().UnitaryPrice,
                    QuantitySold = g.Sum(x => x.QuantitySold),
                    IncomeBsSellsItems = g.First().IncomeBsSellsItems,
                    IncomeDollarsSellsItems = g.First().IncomeDollarsSellsItems,
                    IncomeBankBsSellsItems = g.First().IncomeBankBsSellsItems,
                    WithdrawalBsSellsItems = g.First().WithdrawalBsSellsItems,
                    WithdrawalDollarsSellsItems = g.First().WithdrawalDollarsSellsItems,
                    WithdrawalBankBsSellsItems = g.First().WithdrawalBankBsSellsItems
                }).ToList();

            decimal totalIncomeBsSellsItems = 0;
            decimal totalIncomeDollarsSellsItems = 0;
            decimal totalIncomeBankBsSellsItems = 0;
            decimal totalWithdrawalBsSellsItems = 0;
            decimal totalWithdrawalDollarsSellsItems = 0;
            decimal totalWithdrawalBankBsSellsItems = 0;

            foreach (var item in groupedResults)
            {
                if (yPoint > page.Height - 40)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = 40;

                    gfx.DrawString("Fecha", headerFont, XBrushes.Black, new XPoint(40, yPoint));
                    gfx.DrawString("Producto", headerFont, XBrushes.Black, new XPoint(160, yPoint));
                    gfx.DrawString("Cantidad Vendida", headerFont, XBrushes.Black, new XPoint(320, yPoint));
                    gfx.DrawString("Precio Unitario", headerFont, XBrushes.Black, new XPoint(480, yPoint));
                    yPoint += 20;
                }

                gfx.DrawString(item.DateTime.ToString("yyyy-MM-dd HH:mm"), font, XBrushes.Black, new XPoint(40, yPoint));
                gfx.DrawString(item.Product, font, XBrushes.Black, new XPoint(160, yPoint));
                gfx.DrawString(item.QuantitySold.ToString(), font, XBrushes.Black, new XPoint(320, yPoint));
                gfx.DrawString(item.UnitaryPrice.ToString(), font, XBrushes.Black, new XPoint(480, yPoint));

                totalIncomeBsSellsItems += item.IncomeBsSellsItems;
                totalIncomeDollarsSellsItems += item.IncomeDollarsSellsItems;
                totalIncomeBankBsSellsItems += item.IncomeBankBsSellsItems;
                totalWithdrawalBsSellsItems += item.WithdrawalBsSellsItems;
                totalWithdrawalDollarsSellsItems += item.WithdrawalDollarsSellsItems;
                totalWithdrawalBankBsSellsItems += item.WithdrawalBankBsSellsItems;

                yPoint += 20;
            }

            // Add totalization information
            yPoint += 20;
            gfx.DrawString($"Bs: {totalIncomeBsSellsItems}", font, XBrushes.Black, new XPoint(40, yPoint));
            yPoint += 20;
            gfx.DrawString($"USD: {totalIncomeDollarsSellsItems}", font, XBrushes.Black, new XPoint(40, yPoint));
            yPoint += 20;
            gfx.DrawString($"Tr. Bs: {totalIncomeBankBsSellsItems}", font, XBrushes.Black, new XPoint(40, yPoint));
            yPoint += 20;
            gfx.DrawString($"V. Bs: {totalWithdrawalBsSellsItems}", font, XBrushes.Black, new XPoint(40, yPoint));
            yPoint += 20;
            gfx.DrawString($"V. USD: {totalWithdrawalDollarsSellsItems}", font, XBrushes.Black, new XPoint(40, yPoint));
            yPoint += 20;
            gfx.DrawString($"V. Tr.: {totalWithdrawalBankBsSellsItems}", font, XBrushes.Black, new XPoint(40, yPoint));

            // Leave space before the next table
            yPoint += 40;

            // Draw third table header for Bills
            gfx.DrawString("Fecha", headerFont, XBrushes.Black, new XPoint(40, yPoint));
            gfx.DrawString("Producto", headerFont, XBrushes.Black, new XPoint(160, yPoint));
            gfx.DrawString("Cantidad", headerFont, XBrushes.Black, new XPoint(320, yPoint));
            gfx.DrawString("Precio Unitario", headerFont, XBrushes.Black, new XPoint(480, yPoint));
            yPoint += 20;

            decimal totalBillAmount = 0;

            foreach (var bill in billReportResults)
            {
                if (yPoint > page.Height - 40)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPoint = 40;

                    gfx.DrawString("Fecha", headerFont, XBrushes.Black, new XPoint(40, yPoint));
                    gfx.DrawString("Producto", headerFont, XBrushes.Black, new XPoint(160, yPoint));
                    gfx.DrawString("Cantidad", headerFont, XBrushes.Black, new XPoint(320, yPoint));
                    gfx.DrawString("Precio Unitario", headerFont, XBrushes.Black, new XPoint(480, yPoint));
                    yPoint += 20;
                }

                gfx.DrawString(bill.DateTime.ToString("yyyy-MM-dd HH:mm"), font, XBrushes.Black, new XPoint(40, yPoint));
                gfx.DrawString(bill.Product, font, XBrushes.Black, new XPoint(160, yPoint));
                gfx.DrawString(bill.Qty.ToString(), font, XBrushes.Black, new XPoint(320, yPoint));
                gfx.DrawString(bill.UnitaryPrice.ToString(), font, XBrushes.Black, new XPoint(480, yPoint));

                totalBillAmount += bill.Qty * bill.UnitaryPrice;

                yPoint += 20;
            }

            // Draw line before totalization
            gfx.DrawLine(XPens.Black, 40, yPoint, 580, yPoint);
            yPoint += 10;

            // Draw totalization for Bills
            gfx.DrawString("Total", headerFont, XBrushes.Black, new XPoint(40, yPoint));
            gfx.DrawString(totalBillAmount.ToString(), font, XBrushes.Black, new XPoint(160, yPoint));

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Reportes");
            Directory.CreateDirectory(directoryPath);

            string filename = Path.Combine(directoryPath, $"ReporteVentas-{today}.pdf");
            document.Save(filename);

            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo(filename)
                {
                    UseShellExecute = true
                };
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el archivo PDF: " + ex.Message);
            }
        }

        public string ConvertDateFormat(string date)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                throw new FormatException($"La fecha '{date}' no tiene el formato correcto.");
            }
        }
    }
}
