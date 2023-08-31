using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Modules.Main;
using ThirdPartyAppV2.Main.Forms.DBConnectionConfig;
using ThirdPartyAppV2.Main.Forms.NPSPerformanceSummary;
using ThirdPartyAppV2.Main.Reports;

namespace ThirdPartyAppV2.Main
{
    public partial class Main : Form
    {
        private int elapsedTime = 100;
        private readonly LoadData data = new LoadData();
        public Main()
        {
            InitializeComponent();
            Text = Application.ProductName;
            Text += " [" + Assembly.GetEntryAssembly().GetName().Version + "]";
            DateandTimeLabel.Text = DateTime.Now.ToString("F");
            var timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            timer.Start();
            LoadAdmitted();
        }

        private void LoadAdmitted()
        {
            var startDate = DateTime.Now.AddDays(-90).ToString("d");
            var endDate = DateTime.Now.ToString("d");
            var result = data.LoadAdmitted(SearchAdmitted_Text.Text, startDate, endDate);
            AdmittedPatienstListView.BeginUpdate();
            AdmittedPatienstListView.Items.Clear();
            if (result != null)
            {
                foreach (DataRow item in result.Tables[0].Rows)
                {
                    var lvItem = AdmittedPatienstListView.Items.Add(item["pk_pspatregisters"].ToString());
                    lvItem.SubItems.Add(item["PatientFullName"].ToString());
                    switch (item["pattrantype"].ToString())
                    {
                        case "I":
                            lvItem.SubItems.Add("Inpatient");
                            break;
                        case "O":
                            lvItem.SubItems.Add("Outpatient");
                            break;
                        case "E":
                            lvItem.SubItems.Add("Emergency");
                            break;
                        default:
                            lvItem.SubItems.Add("Unspecified");
                            break;
                    }
                    lvItem.SubItems.Add(item["registrydate"].ToString());
                    lvItem.SubItems.Add(item["dischDatetime"].ToString());
                    lvItem.SubItems.Add(item["AttendingDoctor"].ToString());
                }
            }
            AdmittedPatienstListView.EndUpdate();
        }

        private void LoadAverageTurnArroundTime()
        {
            var dischargeProcDateList = new List<TimeSpan>();

            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddSeconds(-1);
            var startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
            var endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
            var DPDS = data.LoadNPSAverageDischarge(startDateString, endDateString);

            if (DPDS != null)
            {
                foreach (DataRow d in DPDS.Tables[0].Rows)
                {
                    dischargeProcDateList.Add(Convert.ToDateTime(d["MDStartDateTime"]).Subtract(Convert.ToDateTime(d["MDEndDateTime"])));
                    dischargeProcDateList.Add(Convert.ToDateTime(d["BSStartDateTime"]).Subtract(Convert.ToDateTime(d["BSEndDateTime"])));
                    dischargeProcDateList.Add(Convert.ToDateTime(d["BGStartDateTime"]).Subtract(Convert.ToDateTime(d["BGEndDateTime"])));
                    dischargeProcDateList.Add(Convert.ToDateTime(d["BPStartDateTime"]).Subtract(Convert.ToDateTime(d["BPEndDateTime"])));
                    dischargeProcDateList.Add(Convert.ToDateTime(d["DIDStartDateTime"]).Subtract(Convert.ToDateTime(d["DIDEndDateTime"])));
                    dischargeProcDateList.Add(Convert.ToDateTime(d["PatExitStartDateTime"]).Subtract(Convert.ToDateTime(d["PatExitEndDateTime"])));
                }

                var dischProcAverage = dischargeProcDateList.Average(timeSpan => timeSpan.TotalSeconds);
                DPATAT_Label.Text = TimeSpan.FromSeconds(dischProcAverage).ToString("hh':'mm':'ss");
            }

            var ErToAdmissionDateList = new List<TimeSpan>();

            var ATA = data.LoadNPSAverageErToAdmission(startDateString, endDateString);

            if (ATA != null)
            {
                foreach (DataRow d in ATA.Tables[0].Rows)
                {
                    ErToAdmissionDateList.Add(Convert.ToDateTime(d["DToTStartDateTime"]).Subtract(Convert.ToDateTime(d["DToTEndDateTime"])));
                    ErToAdmissionDateList.Add(Convert.ToDateTime(d["TriToRegStartDateTime"]).Subtract(Convert.ToDateTime(d["TriToRegEndDateTime"])));
                    ErToAdmissionDateList.Add(Convert.ToDateTime(d["RegToDocStartDateTime"]).Subtract(Convert.ToDateTime(d["RegToDocEndDateTime"])));
                    ErToAdmissionDateList.Add(Convert.ToDateTime(d["DocOrderStartDateTime"]).Subtract(Convert.ToDateTime(d["DocOrderEndDateTime"])));
                    ErToAdmissionDateList.Add(Convert.ToDateTime(d["ReadyToTransStartDateTime"]).Subtract(Convert.ToDateTime(d["ReadyToTransEndDateTime"])));
                    ErToAdmissionDateList.Add(Convert.ToDateTime(d["TransToRoomStartDateTime"]).Subtract(Convert.ToDateTime(d["TransToRoomEndDateTime"])));
                }

                var ERAdmissionAverage = ErToAdmissionDateList.Average(timeSpan => timeSpan.TotalSeconds);
                ETAATAT_Label.Text = TimeSpan.FromSeconds(ERAdmissionAverage).ToString("hh':'mm':'ss");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateandTimeLabel.Text = DateTime.Now.ToString("F");
            elapsedTime += 1;
            if (elapsedTime <= 100)
            {
                LoadAverageTurnArroundTime();
            }
        }

        private void ConnectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var conSettings = new AppDBSettings();
            conSettings.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        private void PerformanceCounter_Btn_Click(object sender, EventArgs e)
        {
            var Counter = new DischargeCounter();
            if (AdmittedPatienstListView.SelectedItems.Count > 0)
            {
                Counter.PatRegistryNo = AdmittedPatienstListView.SelectedItems[0].Text;
                Counter.PatientName = AdmittedPatienstListView.SelectedItems[0].SubItems[1].Text;
                Counter.Tag = AdmittedPatienstListView.SelectedItems[0].Text;
            }

            Counter.ShowDialog();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAdmitted();
        }

        private void Search_Btn_Click(object sender, EventArgs e)
        {
            LoadAdmitted();
        }

        private void ERToAD_Btn_Click(object sender, EventArgs e)
        {
            var Counter = new ERToAdmissionCounter();
            if (AdmittedPatienstListView.SelectedItems.Count > 0)
            {
                Counter.PatRegistryNo = AdmittedPatienstListView.SelectedItems[0].Text;
                Counter.PatientName = AdmittedPatienstListView.SelectedItems[0].SubItems[1].Text;
                Counter.Tag = AdmittedPatienstListView.SelectedItems[0].Text;
            }

            Counter.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadAverageTurnArroundTime();
        }

        private void NPSReport_Btn_Click(object sender, EventArgs e)
        {
            var rpt = new RptViewerCommon();
            rpt.ShowDialog();
        }
    }
}
