using ControlAguaPotable.Controller;
using ControlAguaPotable.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAguaPotable
{
    public partial class GeneratingReportWindow : Form
    {
        ReportController reportController;

        string from;
        string to;

        private bool isSelectingStartDate = true;
        private DateTime startDate;
        private DateTime endDate;

        public GeneratingReportWindow()
        {
            InitializeComponent();

            reportController = new ReportController();
        }

        private void clnBtn_Click(object sender, EventArgs e)
        {
            fromTextBox.Clear();
            toTextBox.Clear();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            from = fromTextBox.Text;
            to = toTextBox.Text;

            if (from != "" && to != "")
            {
                List<QueryReportResult> resultsToPrintInReport = reportController.GettingReportInfo(from, to);
                List<ItemQueryReportResult> itemResultsToPrintInReport = reportController.GettingReportItemsInfo(from, to);
                List<BillReportResult> billResultsToPrintInReport = reportController.GettingReportBillInfo(from, to);

                reportController.GeneratePdfReport(resultsToPrintInReport, itemResultsToPrintInReport, billResultsToPrintInReport);

                this.Close();
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
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
    }
}
