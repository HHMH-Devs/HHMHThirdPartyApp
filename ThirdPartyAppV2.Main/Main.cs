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
        private int elapsedTime = 0;
        private readonly LoadData data = new();
        public Main()
        {
            InitializeComponent();
            Text = Application.ProductName;
            Text += " [" + Assembly.GetEntryAssembly().GetName().Version + "]";
            DateandTimeLabel.Text = DateTime.Now.ToString("F");
            var timer = new Timer();
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
                    if (!DBNull.Value.Equals(d["MDStartDateTime"]) && !DBNull.Value.Equals(d["MDEndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["MDEndDateTime"]).Subtract(Convert.ToDateTime(d["MDStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["IEStartDateTime"]) && !DBNull.Value.Equals(d["MDEndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["MDEndDateTime"]).Subtract(Convert.ToDateTime(d["IEStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["BGStartDateTime"]) && !DBNull.Value.Equals(d["BGEndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["BGEndDateTime"]).Subtract(Convert.ToDateTime(d["BGStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["BP1StartDateTime"]) && !DBNull.Value.Equals(d["BP1EndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["BP1EndDateTime"]).Subtract(Convert.ToDateTime(d["BP1StartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["BP2StartDateTime"]) && !DBNull.Value.Equals(d["BP2EndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["BP2EndDateTime"]).Subtract(Convert.ToDateTime(d["BP2StartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["DIDStartDateTime"]) && !DBNull.Value.Equals(d["DIDEndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["DIDEndDateTime"]).Subtract(Convert.ToDateTime(d["DIDStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["PatExitStartDateTime"]) && !DBNull.Value.Equals(d["PatExitEndDateTime"]))
                    {
                        dischargeProcDateList.Add(Convert.ToDateTime(d["PatExitEndDateTime"]).Subtract(Convert.ToDateTime(d["PatExitStartDateTime"])));
                    }                
                }

                if (dischargeProcDateList.Count > 0)
                {
                    var dischProcAverage = dischargeProcDateList.Average(timeSpan => timeSpan.TotalSeconds);
                    DPATAT_Label.Text = TimeSpan.FromSeconds(dischProcAverage).ToString("hh':'mm':'ss");
                }

            }

            var ErToAdmissionDateList = new List<TimeSpan>();

            var ATA = data.LoadNPSAverageErToAdmission(startDateString, endDateString);

            if (ATA != null)
            {
                foreach (DataRow d in ATA.Tables[0].Rows)
                {
                    if (!DBNull.Value.Equals(d["RegToDocStartDateTime"]) && !DBNull.Value.Equals(d["RegToDocEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["RegToDocEndDateTime"]).Subtract(Convert.ToDateTime(d["RegToDocStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["DocOrderStartDateTime"]) && !DBNull.Value.Equals(d["DocOrderEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["DocOrderEndDateTime"]).Subtract(Convert.ToDateTime(d["DocOrderStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["APPStartDateTime"]) && !DBNull.Value.Equals(d["APPEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["APPEndDateTime"]).Subtract(Convert.ToDateTime(d["APPStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["PHICStartDateTime"]) && !DBNull.Value.Equals(d["PHICEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["PHICEndDateTime"]).Subtract(Convert.ToDateTime(d["PHICStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["RPStartDateTime"]) && !DBNull.Value.Equals(d["RPEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["RPEndDateTime"]).Subtract(Convert.ToDateTime(d["RPStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["NCOStartDateTime"]) && !DBNull.Value.Equals(d["NCOEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["NCOEndDateTime"]).Subtract(Convert.ToDateTime(d["NCOStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["ReadyToTransStartDateTime"]) && !DBNull.Value.Equals(d["ReadyToTransEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["ReadyToTransEndDateTime"]).Subtract(Convert.ToDateTime(d["ReadyToTransStartDateTime"])));
                    }
                    if (!DBNull.Value.Equals(d["TransToRoomStartDateTime"]) && !DBNull.Value.Equals(d["TransToRoomEndDateTime"]))
                    {
                        ErToAdmissionDateList.Add(Convert.ToDateTime(d["TransToRoomEndDateTime"]).Subtract(Convert.ToDateTime(d["TransToRoomStartDateTime"])));
                    }
                }

                if (ErToAdmissionDateList.Count > 0)
                {
                    var ERAdmissionAverage = ErToAdmissionDateList.Average(timeSpan => timeSpan.TotalSeconds);
                    ETAATAT_Label.Text = TimeSpan.FromSeconds(ERAdmissionAverage).ToString("hh':'mm':'ss");
                }
            }

            AsForTheMonth_Label.Text = DateTime.Now.ToString("'As for the month of 'MMMM");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateandTimeLabel.Text = DateTime.Now.ToString("F");
            elapsedTime += 1;
            if (elapsedTime >= 600)
            {
                LoadAverageTurnArroundTime();
                elapsedTime = 0;
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

        private void SearchAdmitted_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadAdmitted();
            }
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

        private void AdmittedPatienstListView_Click(object sender, EventArgs e)
        {
            if (AdmittedPatienstListView.FocusedItem.SubItems[2].Text == "Inpatient")
            {
                ERToAD_Btn.Enabled = false;
                PerformanceCounter_Btn.Enabled = true;
            }
            else if (AdmittedPatienstListView.FocusedItem.SubItems[2].Text == "Emergency")
            {
                ERToAD_Btn.Enabled = true;
                PerformanceCounter_Btn.Enabled = false;
            }
        }

        private void AdmittedPatienstListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count <= 0)
            {
                foreach (var item in panel1.Controls)
                {
                    if (item is Button btn)
                    {
                        if (btn.Name == "PerformanceCounter_Btn" ||
                            btn.Name == "ERToAD_Btn" ||
                            btn.Name == "DischSum_Btn" ||
                            btn.Name == "MedAbstract_Btn" ||
                            btn.Name == "HistorySheet_Btn" ||
                            btn.Name == "DischIns_Btn" ||
                            btn.Name == "Prescription_btn")
                        {
                            btn.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                foreach (var item in panel1.Controls)
                {
                    if (item is Button btn)
                    {
                        if (AdmittedPatienstListView.FocusedItem.SubItems[2].Text == "Inpatient")
                        {
                            if (btn.Name == "PerformanceCounter_Btn" ||
                                btn.Name == "DischSum_Btn" ||
                                btn.Name == "MedAbstract_Btn" ||
                                btn.Name == "HistorySheet_Btn" ||
                                btn.Name == "DischIns_Btn" ||
                                btn.Name == "Prescription_btn" ||
                                btn.Name == "NPSSum_Btn" ||
                                btn.Name == "DischProcSum_Btn" ||
                                btn.Name == "ERTToAdmissionSum_Btn" ||
                                btn.Name == "CustomRpts_Btn")
                            {
                                btn.Enabled = true;
                            }
                            else if (btn.Name != "NPSSum_Btn" ||
                                btn.Name != "DischProcSum_Btn" ||
                                btn.Name != "ERTToAdmissionSum_Btn" ||
                                btn.Name != "CustomRpts_Btn")
                            {
                                btn.Enabled = false;
                            }
                        }
                        else if (AdmittedPatienstListView.FocusedItem.SubItems[2].Text == "Emergency")
                        {
                            if (btn.Name == "ERToAD_Btn" ||
                                btn.Name == "NPSSum_Btn" ||
                                btn.Name == "DischProcSum_Btn" ||
                                btn.Name == "ERTToAdmissionSum_Btn" ||
                                btn.Name == "CustomRpts_Btn")
                            {
                                btn.Enabled = true;
                            }
                            else if (btn.Name != "NPSSum_Btn" ||
                                btn.Name != "DischProcSum_Btn" ||
                                btn.Name != "ERTToAdmissionSum_Btn" ||
                                btn.Name != "CustomRpts_Btn")
                            {
                                btn.Enabled = false;
                            }
                        }
                    }
                }

            }
        }
    }
}
