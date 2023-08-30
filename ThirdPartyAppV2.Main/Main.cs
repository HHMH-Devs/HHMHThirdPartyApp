using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Modules.Main;
using ThirdPartyAppV2.Main.Forms.DBConnectionConfig;
using ThirdPartyAppV2.Main.Forms.NPSPerformanceSummary;

namespace ThirdPartyAppV2.Main
{
    public partial class Main : Form
    {
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateandTimeLabel.Text = DateTime.Now.ToString("F");
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
    }
}
