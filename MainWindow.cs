using ControlAguaPotable.Controller;
using System.Data;
using System.Xml.Schema;
using System.Configuration;
using ControlAguaPotable.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace ControlAguaPotable
{
    public partial class MainWindow : Form
    {
        public delegate void MoneyUpdateHandler(object sender, MoneyUpdateEventArgs e);

        public event MoneyUpdateHandler MoneyUpdated;

        public decimal BIGGEST = DynamicConfig.GetFloat("Biggest");
        public decimal MEDIUM = DynamicConfig.GetFloat("Medium");
        public decimal MEDIUMSMALL = DynamicConfig.GetFloat("MediumSmall");
        public decimal SMALLEST = DynamicConfig.GetFloat("Smallest");
        public decimal LITERS = DynamicConfig.GetFloat("Liters");
        public decimal BIGGESTPRICE = DynamicConfig.GetFloat("BiggestPrice");
        public decimal MEDIUMPRICE = DynamicConfig.GetFloat("MediumPrice");
        public decimal MEDIUMSMALLPRICE = DynamicConfig.GetFloat("MediumSmallPrice");
        public decimal SMALLESTPRICE = DynamicConfig.GetFloat("SmallestPrice");

        private MainWindowController mainWindowController;
        private CustomizeWindow customizeWindow;
        private SettingsWindow settingsWindow;
        private PaymentMethodWindow paymentMethodWindow = null;
        private BuyingWindow buyingWindow;

        private DataTable dt;
        private DataTable dtBill;

        private bool isSelectingStartDate = true;
        private DateTime startDate;
        private DateTime endDate;

        public MainWindow()
        {
            InitializeComponent();

            mainWindowController = new MainWindowController();

            dt = mainWindowController.CreateDataTable();
            dataGridView.DataSource = dt;

            dtBill = mainWindowController.CreateDataTableBill();
            dataGridView1.DataSource = dtBill;

            btnBigest.Click += BtnBigest_Click;
            btnMedium.Click += BtnMedium_Click;
            btnMediumSmall.Click += BtnMediumSmall_Click;
            btnSmallest.Click += BtnSmallest_Click;
            clnBtn.Click += ClnBtn_Click;
            btnCustomize.Click += BtnCustomize_Click;
            settingsBtn.Click += SettingsBtn_Click;
            registerBtn.Click += RegisterBtn_Click;
            clnBtnBill.Click += ClnBtnBill_Click;
            addBtn.Click += AddBtn_Click;
            acceptBtn.Click += AcceptBtn_Click;
            monthCalendar.DateSelected += MonthCalendar_DateSelected;
            toTextBox.TextChanged += toTextBox_TextChanged;

            InitializeToolTipsAndLabels();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            string type = typeTextBox.Text;
            string supplier = supplierTextBox.Text;
            bool bsChecked = bsRadioBtn.Checked;

            Bill newBill = mainWindowController.CreateBill(type, supplier, bsChecked);
            mainWindowController.InsertBillToDb(newBill);

            mainWindowController.CleanDataTableBill();

            typeTextBox.Clear();
            supplierTextBox.Clear();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string type = typeTextBox.Text;
            string description = descriptionTextBox.Text;
            int qty = (int)qtyNumericUpDown.Value;
            decimal unitaryPrice = unitaryPriceNumericUpDown.Value;
            string supplier = supplierTextBox.Text;

            mainWindowController.AddRegiterDataTableBill(type, description, qty, unitaryPrice, supplier);

            descriptionTextBox.Clear();
            qtyNumericUpDown.Value = 0;
            unitaryPriceNumericUpDown.Value = 0;
        }

        private void ClnBtnBill_Click(object sender, EventArgs e)
        {
            typeTextBox.Clear();
            descriptionTextBox.Clear();
            qtyNumericUpDown.Value = 0;
            unitaryPriceNumericUpDown.Value = 0;
            supplierTextBox.Clear();
            fromTextBox.Clear();
            toTextBox.Clear();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            paymentMethodWindow = new PaymentMethodWindow();
            paymentMethodWindow.CleanDataTable += PaymentMethodWindow_CleanDataTable;

            string money = totalNumberLabel.Text;
            MoneyUpdateEventArgs args = new MoneyUpdateEventArgs(money, dt);
            this.MoneyUpdated += paymentMethodWindow.UpdateMoney;
            MoneyUpdated?.Invoke(this, args);

            paymentMethodWindow.ShowDialog();
        }

        private void PaymentMethodWindow_CleanDataTable(object sender, CleanDataTableEventArgs e)
        {
            if (e.Flag)
            {
                decimal litersToSubtract = dt.AsEnumerable().Sum(row => row.Field<decimal>("litrosTotal"));

                decimal liters = Convert.ToDecimal(litersNumberLabel.Text);

                decimal totalLeft = liters - litersToSubtract;

                litersNumberLabel.Text = totalLeft.ToString();

                DynamicConfig.SetFloat("Liters", totalLeft);

                mainWindowController.CleanDataTable();
                totalNumberLabel.Text = "0/0";
            }
        }

        private void InitializeToolTipsAndLabels()
        {
            toolTip1.SetToolTip(btnBigest, BIGGEST.ToString() + "L" + "-" + "USD" + BIGGESTPRICE.ToString());
            toolTip1.SetToolTip(btnMedium, MEDIUM.ToString() + "L" + "-" + "USD" + MEDIUMPRICE.ToString());
            toolTip1.SetToolTip(btnMediumSmall, MEDIUMSMALL.ToString() + "L" + "-" + "USD" + MEDIUMSMALLPRICE.ToString());
            toolTip1.SetToolTip(btnSmallest, SMALLEST.ToString() + "L" + "-" + "USD" + SMALLESTPRICE.ToString());

            litersNumberLabel.Text = LITERS.ToString();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            settingsWindow = new SettingsWindow();
            settingsWindow.ConstantsUpdated += SettingsWindow_ConstantsUpdated;
            settingsWindow.ConstantsUpdated += mainWindowController.UpdateConstants;

            if (paymentMethodWindow != null)
            {
                settingsWindow.ConstantsUpdated += paymentMethodWindow.UpdateExchangeRate;
            }

            settingsWindow.ShowDialog();
        }

        private void SettingsWindow_ConstantsUpdated(object sender, ConstantsUpdateEventArgs e)
        {
            BIGGEST = e.Biggest;
            MEDIUM = e.Medium;
            MEDIUMSMALL = e.MediumSmall;
            SMALLEST = e.Smalllest;
            LITERS = e.Liters;
            BIGGESTPRICE = e.PriceBiggest;
            MEDIUMPRICE = e.PriceMedium;
            MEDIUMSMALLPRICE = e.PriceMediumSmall;
            SMALLESTPRICE = e.PriceSmalllest;

            InitializeToolTipsAndLabels();
        }

        private void BtnCustomize_Click(object sender, EventArgs e)
        {
            customizeWindow = new CustomizeWindow();
            customizeWindow.DataTableUpdated += CustomizeWindow_DataTableUpdated;
            customizeWindow.ShowDialog();
        }

        private void CustomizeWindow_DataTableUpdated(object sender, DataTableUpdateEventArgs e)
        {
            int cantidad = e.Cantidad;
            decimal presentacion = e.Prepresentacion;
            decimal litrosTotal = e.LitrosTotal;
            decimal precioUnitario = e.PrecioUnitario;
            decimal precioTotal = e.PrecioTotal;

            Dictionary<string, decimal> results = mainWindowController.AddRegister(cantidad, presentacion, litrosTotal, precioUnitario, precioTotal);

            UpdatingSell(results);
        }

        private void ClnBtn_Click(object sender, EventArgs e)
        {
            mainWindowController.CleanDataTable();

            totalNumberLabel.Text = "0/0";
        }

        private void BtnSmallest_Click(object sender, EventArgs e)
        {
            int cantidad = 1;
            decimal presentacion = SMALLEST;
            decimal litrosTotal = cantidad * presentacion;
            decimal precioUnitario = SMALLESTPRICE;
            decimal precioTotal = cantidad * precioUnitario;

            Dictionary<string, decimal> results = mainWindowController.AddRegister(cantidad, presentacion, litrosTotal, precioUnitario, precioTotal);

            UpdatingSell(results);
        }

        private void BtnMediumSmall_Click(object sender, EventArgs e)
        {
            int cantidad = 1;
            decimal presentacion = MEDIUMSMALL;
            decimal litrosTotal = cantidad * presentacion;
            decimal precioUnitario = MEDIUMSMALLPRICE;
            decimal precioTotal = cantidad * precioUnitario;

            Dictionary<string, decimal> results = mainWindowController.AddRegister(cantidad, presentacion, litrosTotal, precioUnitario, precioTotal);

            UpdatingSell(results);
        }

        private void BtnMedium_Click(object sender, EventArgs e)
        {
            int cantidad = 1;
            decimal presentacion = MEDIUM;
            decimal litrosTotal = cantidad * presentacion;
            decimal precioUnitario = MEDIUMPRICE;
            decimal precioTotal = cantidad * precioUnitario;

            Dictionary<string, decimal> results = mainWindowController.AddRegister(cantidad, presentacion, litrosTotal, precioUnitario, precioTotal);

            UpdatingSell(results);
        }

        private void BtnBigest_Click(object sender, EventArgs e)
        {
            int cantidad = 1;
            decimal presentacion = BIGGEST;
            decimal litrosTotal = cantidad * presentacion;
            decimal precioUnitario = BIGGESTPRICE;
            decimal precioTotal = cantidad * precioUnitario;

            Dictionary<string, decimal> results = mainWindowController.AddRegister(cantidad, presentacion, litrosTotal, precioUnitario, precioTotal);

            UpdatingSell(results);
        }

        public void UpdatingSell(Dictionary<string, decimal> results)
        {
            totalNumberLabel.Text = "0/0";

            string[] strings = totalNumberLabel.Text.Split("/");

            decimal ventaBs = decimal.Parse(strings[0]);
            decimal ventaTotalBs = ventaBs + results["precioBs"];
            decimal roundedVentaBs = Math.Round(ventaTotalBs, 2);

            decimal ventaUSD = decimal.Parse(strings[1]);
            decimal ventaTotalUSD = ventaUSD + results["precioUSD"];
            decimal roundedVentaUSD = Math.Round(ventaTotalUSD, 2);

            string bs = roundedVentaBs.ToString();
            string usd = roundedVentaUSD.ToString();

            totalNumberLabel.Text = bs + "/" + usd;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                Dictionary<string, string> dict = mainWindowController.UpdatingIncomeAndWithdrawalCurrentDay();

                incomeDollars.Text = dict["incomeDollars"];
                incomeBs.Text = dict["incomeBs"];
                withdrawalDollars.Text = dict["withdrawalDollars"];
                withdrawalBs.Text = dict["withdrawalBs"];
            }
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (isSelectingStartDate)
            {
                startDate = e.Start;
                fromTextBox.Text = startDate.ToShortDateString();

                isSelectingStartDate = false;
            }
            else
            {
                endDate = e.End;
                toTextBox.Text = endDate.ToShortDateString();

                isSelectingStartDate = true;
            }
        }

        private void toTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                string date1 = textBox.Text;

                string date2 = fromTextBox.Text;

                DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime from = DateTime.ParseExact(d2.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);

                DateTime d1 = DateTime.ParseExact(date1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime to = DateTime.ParseExact(d1.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);

                if (date1 != "")
                {
                    Dictionary<string, DataTable> dictWithDataTables = mainWindowController.PlottingCharts(from, to);

                    DataTable liters = dictWithDataTables["liters"];
                    DataTable money = dictWithDataTables["money"];

                    SetupChart1(liters);
                    SetupChart2(money);
                }
            }

            catch
            {

            }

        }

        private void SetupChart1(DataTable dataTable)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            var series = new Series("Litros")
            {
                XValueMember = "Fecha",
                YValueMembers = "Litros",
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            chart1.Series.Add(series);

            var chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "Fecha";
            chartArea.AxisY.Title = "Litros";
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.LabelStyle.Format = "dd/MM";

            chart1.DataSource = dataTable;
            chart1.DataBind();
        }

        private void SetupChart2(DataTable dataTable)
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Titles.Clear();

            var series = new Series("Dólares")
            {
                XValueMember = "Fecha",
                YValueMembers = "Dólares",
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            chart2.Series.Add(series);

            var chartArea = new ChartArea();
            chart2.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "Fecha";
            chartArea.AxisY.Title = "Dólares";
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.LabelStyle.Format = "dd/MM";

            chart2.DataSource = dataTable;
            chart2.DataBind();
        }

        private void buy_Click(object sender, EventArgs e)
        {
            buyingWindow = new BuyingWindow();
            buyingWindow.ShowDialog();
        }
    }

    public class MoneyUpdateEventArgs : EventArgs
    {
        private string money;
        private DataTable dt;

        public MoneyUpdateEventArgs(string money, DataTable dt)
        {
            this.money = money;
            this.dt = dt;
        }

        public string Money { get { return money; } }
        public DataTable DataTable { get { return dt; } }
    }
}       