using Microsoft.Reporting.WinForms;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Modules.NPSPerformance;
using static ThirdPartyAppV2.Common.Modules.Reports.Modul_Print_Reports;

namespace ThirdPartyAppV2.Main.Reports
{
    [Log]
    public partial class RptViewerCommon : Form
    {
        private readonly ReportViewer reportViewer = new();
        private readonly NPSCounter counter = new();
        public RptViewerCommon()
        {
            InitializeComponent();
            this.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.BringToFront();
            LoadLocalNPSReport();
        }

        private void PrintDoc_Btn_Click(object sender, EventArgs e)
        {
            Print_microsoft_report(reportViewer.LocalReport);
        }

        public void LoadLocalNPSReport()
        {
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.ReportEmbeddedResource = "ThirdPartyAppV2.Main.Reports.rptNpsPerformanceSummary.rdlc";
            //ToDo...
            var hospInfo = counter.LoadHospinfo();
            var dischProc = counter.LoadDischargeProc();
            var erToAdmission = counter.LoadErToAdmission();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("HospitalInfo", hospInfo.Tables["HospitalInfo"]));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DischargeProc", dischProc.Tables["DischargeProcess"]));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ErToAdmission", erToAdmission.Tables["ErToAdmission"]));

            reportViewer.LocalReport.SetParameters(new List<ReportParameter>() 
            {
                new ReportParameter("DPMedDischarge", dischProc.Tables["DischargeProcess"].Rows[0]["TotalMedDischargeAvg"].ToString()),
                new ReportParameter("DPIntegrityCheck", dischProc.Tables["DischargeProcess"].Rows[0]["TotalIntegrityCheckAvg"].ToString()),
                new ReportParameter("DPBillGen", dischProc.Tables["DischargeProcess"].Rows[0]["TotalBillGenAvg"].ToString()),
                new ReportParameter("DPBillPrint", dischProc.Tables["DischargeProcess"].Rows[0]["TotalBillPrintAvg"].ToString()),
                new ReportParameter("DPBillPay", dischProc.Tables["DischargeProcess"].Rows[0]["TotalBillPayAvg"].ToString()),
                new ReportParameter("DPDocumentation", dischProc.Tables["DischargeProcess"].Rows[0]["TotalDocumentationAvg"].ToString()),
                new ReportParameter("DPPatExit", dischProc.Tables["DischargeProcess"].Rows[0]["TotalPatExitAvg"].ToString()),
            });

            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }
    }
}
