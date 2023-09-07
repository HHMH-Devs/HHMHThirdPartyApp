using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Modules.NPSPerformance;
using static ThirdPartyAppV2.Common.Modules.Reports.Modul_Print_Reports;

namespace ThirdPartyAppV2.Main.Reports
{
    public partial class RptViewerCommon : Form
    {
        private readonly ReportViewer reportViewer = new();
        private readonly NPSCounter counter = new();
        public RptViewerCommon()
        {
            InitializeComponent();
        }

        private void PrintDoc_Btn_Click(object sender, EventArgs e)
        {
            Print_microsoft_report(reportViewer.LocalReport);
        }

        public void LoadLocalNPSReport(string rptMode = "Monthly", string dateNow = "")
        {
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.ReportEmbeddedResource = "ThirdPartyAppV2.Main.Reports.rptNpsPerformanceSummary.rdlc";
            //ToDo...
            var hospInfo = counter.LoadHospinfo();
            var dischProc = counter.LoadDischargeProc(rptMode, dateNow);
            var erToAdmission = counter.LoadErToAdmission(rptMode, dateNow);
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("HospitalInfo", hospInfo.Tables["HospitalInfo"]));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DischargeProc", dischProc.Tables["DischargeProcess"]));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ErToAdmission", erToAdmission.Tables["ErToAdmission"]));

            reportViewer.LocalReport.SetParameters(new List<ReportParameter>()
            {
                new ReportParameter("RptType", rptMode),
                new ReportParameter("DPMedDischarge", dischProc.Tables["DischargeProcess"].Rows[0]["TotalMedDischargeAvg"].ToString()),
                new ReportParameter("DPIntegrityCheck", dischProc.Tables["DischargeProcess"].Rows[0]["TotalIntegrityCheckAvg"].ToString()),
                new ReportParameter("DPBillGen", dischProc.Tables["DischargeProcess"].Rows[0]["TotalBillGenAvg"].ToString()),
                new ReportParameter("DPBillPrint", dischProc.Tables["DischargeProcess"].Rows[0]["TotalBillPrintAvg"].ToString()),
                new ReportParameter("DPBillPay", dischProc.Tables["DischargeProcess"].Rows[0]["TotalBillPayAvg"].ToString()),
                new ReportParameter("DPDocumentation", dischProc.Tables["DischargeProcess"].Rows[0]["TotalDocumentationAvg"].ToString()),
                new ReportParameter("DPPatExit", dischProc.Tables["DischargeProcess"].Rows[0]["TotalPatExitAvg"].ToString()),
                new ReportParameter("ERRegToDoc", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalRegToDocOrderAvg"].ToString()),
                new ReportParameter("ERDocCarryOut", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalDocOrderCarryOutAvg"].ToString()),
                new ReportParameter("ERPatProfiling", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalPatientProfilingAvg"].ToString()),
                new ReportParameter("ERPhicSubmission", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalPHICSubmissionAvg"].ToString()),
                new ReportParameter("ERRoomPrep", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalRoomPrepAvg"].ToString()),
                new ReportParameter("ERNursesCarryOut", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalNursesCarryOutAvg"].ToString()),
                new ReportParameter("ERReadyToTransfer", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalReadyToTransferAvg"].ToString()),
                new ReportParameter("ERTransferToRoom", erToAdmission.Tables["ErToAdmission"].Rows[0]["TotalTransferToRoomAvg"].ToString())
            });

            reportViewer.LocalReport.Refresh();
            reportViewer.RefreshReport();
        }

        private void RefreshRpt_Btn_Click(object sender, EventArgs e)
        {
            if (RptType_Cb.Text == "Weekly")
            {
                LoadLocalNPSReport(RptType_Cb.Text, DailyWeeklySelection_Dtp.Value.ToString());
            }
            else if (RptType_Cb.Text == "Daily")
            {
                LoadLocalNPSReport(RptType_Cb.Text, DailyWeeklySelection_Dtp.Value.ToString());
            }
            else
            {
                LoadLocalNPSReport(RptType_Cb.Text, MonthSelection_Dtp.Value.ToString());
            }
        }

        private void RptViewerCommon_Load(object sender, EventArgs e)
        {
            this.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.BringToFront();
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            RptType_Cb.Text = "Monthly";
            LoadLocalNPSReport();
        }

        private void RptType_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RptType_Cb.Text == "Monthly")
            {
                MonthSelection_Dtp.Enabled = true;
                DailyWeeklySelection_Dtp.Enabled = false;
            }
            else
            {
                MonthSelection_Dtp.Enabled = false;
                DailyWeeklySelection_Dtp.Enabled = true;
            }
        }
    }
}
