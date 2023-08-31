using Microsoft.Reporting.WinForms;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ThirdPartyAppV2.Common.Modules.Reports.Modul_Print_Reports;

namespace ThirdPartyAppV2.Main.Reports
{
    [Log]
    public partial class RptViewerCommon : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        public RptViewerCommon()
        {
            InitializeComponent();
            this.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.BringToFront();
        }

        private void PrintDoc_Btn_Click(object sender, EventArgs e)
        {
            Print_microsoft_report(reportViewer.LocalReport);
        }

        public void LoadLocalReport()
        {
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.ReportEmbeddedResource = "ThirdPartyAppV2.Main.Reports.rptNpsPerformanceSummary.rdlc";
            //ToDo...

            reportViewer.Refresh();
        }
    }
}
