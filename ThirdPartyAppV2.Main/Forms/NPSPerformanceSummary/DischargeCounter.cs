using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Modules.NPSPerformance;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ThirdPartyAppV2.Main.Forms.NPSPerformanceSummary
{
    [Log]
    public partial class DischargeCounter : Form
    {
        public string PatientName;
        public string PatRegistryNo;
        private readonly NPSCounter nPSCounter = new NPSCounter();
        private readonly Dictionary<string, TimeSpan> timerList = new Dictionary<string, TimeSpan>();
        public DischargeCounter()
        {
            InitializeComponent();
        }

        private string GetMDTimeDiff(string process, string startDate, string EndDate)
        {
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(EndDate))
            {
                var param1 = Convert.ToDateTime(startDate);
                var param2 = Convert.ToDateTime(EndDate);
                var dateDiff = param2.Subtract(param1);

                if (!timerList.ContainsKey(process))
                {
                    timerList.Add(process, dateDiff);
                }
                else
                {
                    timerList[process] = dateDiff;
                }

                var totalTime = new TimeSpan();

                foreach (var item in timerList)
                {
                    totalTime += item.Value;
                }

                var doubleAverageSeonds = timerList.Average(timeSpan => timeSpan.Value.TotalSeconds);

                AverageTime_Label.Text = TimeSpan.FromSeconds(doubleAverageSeonds).ToString("h' hr(s), 'm' min(s) and 's' second(s)'");

                DischargeProcOverAllET_Lbl.Text = totalTime.ToString("h' hr(s), 'm' min(s) and 's' second(s)'");

                if (dateDiff.Days > 0)
                {
                    return dateDiff.ToString("dd':'hh':'mm':'ss");
                }
                else
                {
                    return dateDiff.ToString("hh':'mm':'ss");
                }

            }
            return "00:00:00";
        }

        private void PerformanceCounter_Load(object sender, EventArgs e)
        {
            LoadDatesAndTime();
            PatientName_Lbl.Text = PatientName;
            DataLoaded();
        }

        private void DataLoaded()
        {
            var txt = groupBox1.Controls.OfType<TextBox>().ToList();
            var btn = groupBox1.Controls.OfType<Button>().ToList();
            if (txt.All(x => x.Text.Length > 0))
            {
                Done_Btn.Text = "&Edit";
                foreach (var x in txt)
                {
                    x.ReadOnly = true;
                }
                foreach (var b in btn)
                {
                    b.Enabled = false;
                }
            }
            else
            {
                foreach (var item in txt.Where(x => !string.IsNullOrEmpty(x.Text)))
                {
                    item.ReadOnly = true;
                    btn.First(x => x.Tag.ToString() == item.Name).Enabled = false;
                }
            }
        }

        private void LoadDatesAndTime()
        {
            if (string.IsNullOrEmpty(PatRegistryNo))
            {
                return;
            }
            var stData = nPSCounter.LoadDataFromMySqlDischarge(Convert.ToInt32(PatRegistryNo));
            if (stData.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow rw in stData.Tables[0].Rows)
                {
                    MDStartDate_Text.Text = rw["MDStartDateTime"].ToString();
                    MDEndDate_Text.Text = rw["MDEndDateTime"].ToString();
                    BillSendingStartDateTime_Text.Text = rw["BSStartDateTime"].ToString();
                    BillSendingEndDateTime_Text.Text = rw["BSEndDateTime"].ToString();
                    BGStartDate_Text.Text = rw["BGStartDateTime"].ToString();
                    BGEndDate_Text.Text = rw["BGEndDateTime"].ToString();
                    BPStartDate_Text.Text = rw["BPStartDateTime"].ToString();
                    BPEndDate_Text.Text = rw["BPEndDateTime"].ToString();
                    DIDStartDate_Text.Text = rw["DIDStartDateTime"].ToString();
                    DIDEndDate_Text.Text = rw["DIDEndDateTime"].ToString();
                    PEStartDate_Text.Text = rw["PatExitStartDateTime"].ToString();
                    PEEndDate_Text.Text = rw["PatExitEndDateTime"].ToString();
                    MDLabel_Label.Text = $"Medical Discharge - {GetMDTimeDiff("Medical Discharge", MDStartDate_Text.Text, MDEndDate_Text.Text)}";
                    BSLalbel_Lbl.Text = $"Bill Sending - {GetMDTimeDiff("Bill Sending", BillSendingStartDateTime_Text.Text, BillSendingEndDateTime_Text.Text)}";
                    BGLabel_Lbl.Text = $"Bill Generation - {GetMDTimeDiff("Bill Generation", BGStartDate_Text.Text, BGEndDate_Text.Text)}";
                    BPLabel_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", BPStartDate_Text.Text, BPEndDate_Text.Text)}";
                    DIDLabel_Lbl.Text = $"Discharge Instruction and Documentation - {GetMDTimeDiff("Discharge Instruction and Documentation", DIDStartDate_Text.Text, DIDEndDate_Text.Text)}";
                    PELabel_Lbl.Text = $"Patient Exit - {GetMDTimeDiff("Patient Exit", PEStartDate_Text.Text, PEEndDate_Text.Text)}";
                }
            }
            if (!string.IsNullOrEmpty(nPSCounter.InPatientMGH(PatRegistryNo)))
            {
                BillSendingStartDateTime_Text.Text = nPSCounter.InPatientMGH(PatRegistryNo);
                BillSendingStartDateTime_Text.ReadOnly = true;
                SetBillSendingStartTime_Btn.Enabled = false;

            }
        }

        private void Done_Btn_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "&Edit")
            {
                var txt = groupBox1.Controls.OfType<TextBox>().ToList();
                var btn = groupBox1.Controls.OfType<Button>().ToList();
                foreach (var x in txt)
                {
                    x.ReadOnly = false;
                }
                foreach (var b in btn)
                {
                    b.Enabled = true;
                }

                ((Button)sender).Text = "&Done";
            }
            else
            {
                if (Tag != null)
                {
                    var isSaved = nPSCounter.SaveDataDischargeProcess(Convert.ToInt32(Tag),
                        PatientName_Lbl.Text,
                        Convert.ToDateTime(string.IsNullOrEmpty(MDStartDate_Text.Text) ? DateTime.MinValue.ToString() : MDStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(MDEndDate_Text.Text) ? DateTime.MinValue.ToString() : MDEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BillSendingStartDateTime_Text.Text) ? DateTime.MinValue.ToString() : BillSendingStartDateTime_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BillSendingEndDateTime_Text.Text) ? DateTime.MinValue.ToString() : BillSendingEndDateTime_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BGStartDate_Text.Text) ? DateTime.MinValue.ToString() : BGStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BGEndDate_Text.Text) ? DateTime.MinValue.ToString() : BGEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BPStartDate_Text.Text) ? DateTime.MinValue.ToString() : BPStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BPEndDate_Text.Text) ? DateTime.MinValue.ToString() : BPEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(DIDStartDate_Text.Text) ? DateTime.MinValue.ToString() : DIDStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(DIDEndDate_Text.Text) ? DateTime.MinValue.ToString() : DIDEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(PEStartDate_Text.Text) ? DateTime.MinValue.ToString() : PEStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(PEEndDate_Text.Text) ? DateTime.MinValue.ToString() : PEEndDate_Text.Text));
                    if (isSaved)
                    {
                        MessageBox.Show("Successfully Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
        }

        private void MDSetStartDate_Btn_Click(object sender, EventArgs e)
        {
            MDStartDate_Text.Text = DateTime.Now.ToString();
            MDLabel_Label.Text = $"Medical Discharge - {GetMDTimeDiff("Medical Discharge", MDStartDate_Text.Text, MDEndDate_Text.Text)}";
        }

        private void MDSetEndDate_Btn_Click(object sender, EventArgs e)
        {
            MDEndDate_Text.Text = DateTime.Now.ToString();
            MDLabel_Label.Text = $"Medical Discharge - {GetMDTimeDiff("Medical Discharge", MDStartDate_Text.Text, MDEndDate_Text.Text)}";
        }

        private void SetBillSendingStartTime_Btn_Click(object sender, EventArgs e)
        {
            BillSendingStartDateTime_Text.Text = DateTime.Now.ToString();
            BSLalbel_Lbl.Text = $"Bill Sending - {GetMDTimeDiff("Bill Sending", BillSendingStartDateTime_Text.Text, BillSendingEndDateTime_Text.Text)}";
        }

        private void SetBillSendingEndTime_Btn_Click(object sender, EventArgs e)
        {
            BillSendingEndDateTime_Text.Text = DateTime.Now.ToString();
            BSLalbel_Lbl.Text = $"Bill Sending - {GetMDTimeDiff("Bill Sending", BillSendingStartDateTime_Text.Text, BillSendingEndDateTime_Text.Text)}";
        }

        private void BGStartDate_Btn_Click(object sender, EventArgs e)
        {
            BGStartDate_Text.Text = DateTime.Now.ToString();
            BGLabel_Lbl.Text = $"Bill Generation - {GetMDTimeDiff("Bill Generation", BGStartDate_Text.Text, BGEndDate_Text.Text)}";
        }

        private void BGEndDate_Btn_Click(object sender, EventArgs e)
        {
            BGEndDate_Text.Text = DateTime.Now.ToString();
            BGLabel_Lbl.Text = $"Bill Generation - {GetMDTimeDiff("Bill Generation", BGStartDate_Text.Text, BGEndDate_Text.Text)}";
        }

        private void BPStartDate_Btn_Click(object sender, EventArgs e)
        {
            BPStartDate_Text.Text = DateTime.Now.ToString();
            BPLabel_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", BPStartDate_Text.Text, BPEndDate_Text.Text)}";
        }

        private void BPEndDate_Btn_Click(object sender, EventArgs e)
        {
            BPEndDate_Text.Text = DateTime.Now.ToString();
            BPLabel_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", BPStartDate_Text.Text, BPEndDate_Text.Text)}";
        }

        private void DIDStartDate_Btn_Click(object sender, EventArgs e)
        {
            DIDStartDate_Text.Text = DateTime.Now.ToString();
            DIDLabel_Lbl.Text = $"Discharge Instruction and Documentation - {GetMDTimeDiff("Discharge Instruction and Documentation", DIDStartDate_Text.Text, DIDEndDate_Text.Text)}";
        }

        private void DIDEndDate_Btn_Click(object sender, EventArgs e)
        {
            DIDEndDate_Text.Text = DateTime.Now.ToString();
            DIDLabel_Lbl.Text = $"Discharge Instruction and Documentation - {GetMDTimeDiff("Discharge Instruction and Documentation", DIDStartDate_Text.Text, DIDEndDate_Text.Text)}";
        }

        private void PEStartDate_Btn_Click(object sender, EventArgs e)
        {
            PEStartDate_Text.Text = DateTime.Now.ToString();
            PELabel_Lbl.Text = $"Patient Exit - {GetMDTimeDiff("Patient Exit", PEStartDate_Text.Text, PEEndDate_Text.Text)}";
        }

        private void PEEndDate_Btn_Click(object sender, EventArgs e)
        {
            PEEndDate_Text.Text = DateTime.Now.ToString();
            PELabel_Lbl.Text = $"Patient Exit - {GetMDTimeDiff("Patient Exit", PEStartDate_Text.Text, PEEndDate_Text.Text)}";
        }     
    }
}