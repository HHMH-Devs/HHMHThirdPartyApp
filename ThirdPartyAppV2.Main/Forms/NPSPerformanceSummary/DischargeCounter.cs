using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Modules.NPSPerformance;

namespace ThirdPartyAppV2.Main.Forms.NPSPerformanceSummary
{
    [Log]
    public partial class DischargeCounter : Form
    {
        public string PatientName;
        public string PatRegistryNo;
        private readonly NPSCounter nPSCounter = new();
        private readonly Dictionary<string, TimeSpan> timerList = new();
        public DischargeCounter()
        {
            InitializeComponent();
            ProcessDetails_Text.Text = string.Empty;
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
                    foreach (var b in btn)
                    {
                        if (b.Tag != null)
                        {
                            if (b.Tag.ToString() == item.Name)
                            {
                                b.Enabled = false;
                            }
                        }
                    }
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
                try
                {
                    foreach (DataRow rw in stData.Tables[0].Rows)
                    {
                        MDStartDate_Text.Text = rw["MDStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["MDStartDateTime"].ToString();
                        MDEndDate_Text.Text = rw["MDEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["MDEndDateTime"].ToString();
                        IEStartDateTime_Text.Text = rw["IEStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["IEStartDateTime"].ToString();
                        IEEndDateTime_Text.Text = rw["IEEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["IEEndDateTime"].ToString();
                        BGStartDate_Text.Text = rw["BGStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["BGStartDateTime"].ToString();
                        BGEndDate_Text.Text = rw["BGEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["BGEndDateTime"].ToString();
                        BP1StartDateTime_Text.Text = rw["BP1StartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["BP1StartDateTime"].ToString();
                        BP1EndDateTime_Text.Text = rw["BP1EndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["BP1EndDateTime"].ToString();
                        BP2StartDate_Text.Text = rw["BP2StartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["BP1StartDateTime"].ToString();
                        BP2EndDate_Text.Text = rw["BP2EndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["BP2EndDateTime"].ToString();
                        DIDStartDate_Text.Text = rw["DIDStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["DIDStartDateTime"].ToString();
                        DIDEndDate_Text.Text = rw["DIDEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["DIDEndDateTime"].ToString();
                        PEStartDate_Text.Text = rw["PatExitStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["PatExitStartDateTime"].ToString();
                        PEEndDate_Text.Text = rw["PatExitEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["PatExitEndDateTime"].ToString();
                        MDLabel_Label.Text = $"Medical Discharge - {GetMDTimeDiff("Medical Discharge", MDStartDate_Text.Text, MDEndDate_Text.Text)}";
                        IELabel_Lbl.Text = $"Integrity Check - {GetMDTimeDiff("Integrity Check", IEStartDateTime_Text.Text, IEEndDateTime_Text.Text)}";
                        BGLabel_Lbl.Text = $"Bill Generation - {GetMDTimeDiff("Bill Generation", BGStartDate_Text.Text, BGEndDate_Text.Text)}";
                        BP1Label_Lbl.Text = $"Bill Printing - {GetMDTimeDiff("Bill Printing", BP1StartDateTime_Text.Text, BP1EndDateTime_Text.Text)}";
                        BP2Label_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", BP2StartDate_Text.Text, BP2EndDate_Text.Text)}";
                        DIDLabel_Lbl.Text = $"Discharge Instruction and Documentation - {GetMDTimeDiff("Discharge Instruction and Documentation", DIDStartDate_Text.Text, DIDEndDate_Text.Text)}";
                        PELabel_Lbl.Text = $"Patient Exit - {GetMDTimeDiff("Patient Exit", PEStartDate_Text.Text, PEEndDate_Text.Text)}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            var ds = nPSCounter.InPatientMGH(PatRegistryNo);
            if (ds != null)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (!DBNull.Value.Equals(item["mghdatetime"]) || !string.IsNullOrEmpty(item["mghdatetime"].ToString()))
                    {
                        IEEndDateTime_Text.Text = item["mghdatetime"].ToString();
                        IEEndDateTime_Text.ReadOnly = true;
                        IEEndDateTime_Btn.Enabled = false;
                        BGStartDate_Text.Text = item["mghdatetime"].ToString();
                        BGStartDate_Text.ReadOnly = true;
                        BGStartDate_Btn.Enabled = false;

                    }
                    if (!DBNull.Value.Equals(item["dischdate"]) || !string.IsNullOrEmpty(item["dischdate"].ToString()))
                    {
                        PEStartDate_Text.Text = item["dischdate"].ToString();
                        PEStartDate_Text.ReadOnly = true;
                        PEStartDate_Btn.Enabled = false;
                    }
                }
            }

            if (string.IsNullOrEmpty(MDStartDate_Text.Text))
            {
                MDEndDate_Text.ReadOnly = true;
                MDSetEndDate_Btn.Enabled = false;
            }
            else
            {
                MDEndDate_Text.ReadOnly = false;
                MDSetEndDate_Btn.Enabled = true;
            }
            if (string.IsNullOrEmpty(BGStartDate_Text.Text))
            {
                BGEndDate_Text.ReadOnly = true;
                BGEndDate_Btn.Enabled = false;
            }
            else
            {
                BGEndDate_Text.ReadOnly = false;
                BGEndDate_Btn.Enabled = true;
            }
            if (string.IsNullOrEmpty(IEStartDateTime_Text.Text))
            {
                IEEndDateTime_Text.ReadOnly = true;
                IEEndDateTime_Btn.Enabled = false;
            }
            else
            {
                IEEndDateTime_Text.ReadOnly = false;
                IEEndDateTime_Btn.Enabled = true;
            }
            if (string.IsNullOrEmpty(BP1StartDateTime_Text.Text))
            {
                BP1EndDateTime_Text.ReadOnly = true;
                BP1EndDateTime_Btn.Enabled = false;
            }
            else
            {
                BP1EndDateTime_Text.ReadOnly = false;
                BP1EndDateTime_Btn.Enabled = true;
            }
            if (string.IsNullOrEmpty(BP2StartDate_Text.Text))
            {
                BP2EndDate_Text.ReadOnly = true;
                BP2EndDate_Btn.Enabled = false;
            }
            else
            {
                BP2EndDate_Text.ReadOnly = false;
                BP2EndDate_Btn.Enabled = true;
            }
            if (string.IsNullOrEmpty(DIDStartDate_Text.Text))
            {
                DIDEndDate_Text.ReadOnly = true;
                DIDEndDate_Btn.Enabled = false;
            }
            else
            {
                DIDEndDate_Text.ReadOnly = false;
                DIDEndDate_Btn.Enabled = true;
            }
            if (string.IsNullOrEmpty(PEStartDate_Text.Text))
            {
                PEEndDate_Text.ReadOnly = true;
                PEEndDate_Btn.Enabled = false;
            }
            else
            {
                PEEndDate_Text.ReadOnly = false;
                PEEndDate_Btn.Enabled = true;
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
                        Convert.ToDateTime(string.IsNullOrEmpty(IEStartDateTime_Text.Text) ? DateTime.MinValue.ToString() : IEStartDateTime_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(IEEndDateTime_Text.Text) ? DateTime.MinValue.ToString() : IEEndDateTime_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BGStartDate_Text.Text) ? DateTime.MinValue.ToString() : BGStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BGEndDate_Text.Text) ? DateTime.MinValue.ToString() : BGEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BP1StartDateTime_Text.Text) ? DateTime.MinValue.ToString() : BP1StartDateTime_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BP1EndDateTime_Text.Text) ? DateTime.MinValue.ToString() : BP1EndDateTime_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BP2StartDate_Text.Text) ? DateTime.MinValue.ToString() : BP2StartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(BP2EndDate_Text.Text) ? DateTime.MinValue.ToString() : BP2EndDate_Text.Text),
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
        }

        private void MDSetEndDate_Btn_Click(object sender, EventArgs e)
        {
            MDEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void BGStartDate_Btn_Click(object sender, EventArgs e)
        {
            BGStartDate_Text.Text = DateTime.Now.ToString();
            BGEndDate_Text.ReadOnly = false;
            BGEndDate_Btn.Enabled = true;
        }

        private void BGEndDate_Btn_Click(object sender, EventArgs e)
        {
            BGEndDate_Text.Text = DateTime.Now.ToString();
            if (string.IsNullOrEmpty(BP1StartDateTime_Text.Text))
            {
                BP1StartDateTime_Text.Text = DateTime.Now.ToString();
            }
        }

        private void BPStartDate_Btn_Click(object sender, EventArgs e)
        {
            BP2StartDate_Text.Text = DateTime.Now.ToString();
            BP2EndDate_Text.ReadOnly = false;
            BP2EndDate_Btn.Enabled = true;
        }

        private void BPEndDate_Btn_Click(object sender, EventArgs e)
        {
            BP2EndDate_Text.Text = DateTime.Now.ToString();
        }

        private void DIDStartDate_Btn_Click(object sender, EventArgs e)
        {
            DIDStartDate_Text.Text = DateTime.Now.ToString();
            DIDEndDate_Text.ReadOnly = false;
            DIDEndDate_Btn.Enabled = true;
        }

        private void DIDEndDate_Btn_Click(object sender, EventArgs e)
        {
            DIDEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void PEStartDate_Btn_Click(object sender, EventArgs e)
        {
            PEStartDate_Text.Text = DateTime.Now.ToString();
            PEEndDate_Text.ReadOnly = false;
            PEEndDate_Btn.Enabled = true;
        }

        private void PEEndDate_Btn_Click(object sender, EventArgs e)
        {
            PEEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void MDStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(MDStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(MDEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                MDLabel_Label.Text = $"Medical Discharge - {GetMDTimeDiff("Medical Discharge", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            MDEndDate_Text.ReadOnly = false;
            MDSetEndDate_Btn.Enabled = true;
        }

        private void MDEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(MDStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(MDEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                MDLabel_Label.Text = $"Medical Discharge - {GetMDTimeDiff("Medical Discharge", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void BGStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BGStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(BGEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                BGLabel_Lbl.Text = $"Bill Generation - {GetMDTimeDiff("Bill Generation", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            BGEndDate_Text.ReadOnly = false;
            BGEndDate_Btn.Enabled = true;
        }

        private void BGEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BGStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(BGEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                BGLabel_Lbl.Text = $"Bill Generation - {GetMDTimeDiff("Bill Generation", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void BPStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BP2StartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(BP2EndDate_Text.Text, out DateTime parsedDateTime2))
            {
                BP2Label_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            BP2EndDate_Text.ReadOnly = false;
            BP2EndDate_Btn.Enabled = true;
        }

        private void BPEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BP2StartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(BP2EndDate_Text.Text, out DateTime parsedDateTime2))
            {
                BP2Label_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void DIDStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(DIDStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(DIDEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                DIDLabel_Lbl.Text = $"Discharge Instruction and Documentation - {GetMDTimeDiff("Discharge Instruction and Documentation", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            DIDEndDate_Text.ReadOnly = false;
            DIDEndDate_Btn.Enabled = true;
        }

        private void DIDEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(DIDStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(DIDEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                DIDLabel_Lbl.Text = $"Discharge Instruction and Documentation - {GetMDTimeDiff("Discharge Instruction and Documentation", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void PEStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(PEStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(PEEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                PELabel_Lbl.Text = $"Patient Exit - {GetMDTimeDiff("Patient Exit", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            PEEndDate_Text.ReadOnly = false;
            PEEndDate_Btn.Enabled = true;
        }

        private void PEEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(PEStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(PEEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                PELabel_Lbl.Text = $"Patient Exit - {GetMDTimeDiff("Patient Exit", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void IEStartDateTime_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(IEStartDateTime_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(IEEndDateTime_Text.Text, out DateTime parsedDateTime2))
            {
                IELabel_Lbl.Text = $"Integrity Check - {GetMDTimeDiff("Integrity Check", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            IEEndDateTime_Text.ReadOnly = false;
            IEEndDateTime_Btn.Enabled = true;
        }

        private void IEEndDateTime_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(IEStartDateTime_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(IEEndDateTime_Text.Text, out DateTime parsedDateTime2))
            {
                IELabel_Lbl.Text = $"Integrity Check - {GetMDTimeDiff("Integrity Check", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }

            if (string.IsNullOrEmpty(BGStartDate_Text.Text))
            {
                BGStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void BP1StartDateTime_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BP1StartDateTime_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(BP1EndDateTime_Text.Text, out DateTime parsedDateTime2))
            {
                BP1Label_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            BP1EndDateTime_Text.ReadOnly = false;
            BP1EndDateTime_Btn.Enabled = true;
        }

        private void BP1EndDateTime_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BP1StartDateTime_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(BP1EndDateTime_Text.Text, out DateTime parsedDateTime2))
            {
                BP1Label_Lbl.Text = $"Bill Payment - {GetMDTimeDiff("Bill Payment", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void IEStartDateTime_Btn_Click(object sender, EventArgs e)
        {
            IEStartDateTime_Text.Text = DateTime.Now.ToString();
            IEEndDateTime_Text.ReadOnly = false;
            IEEndDateTime_Btn.Enabled = true;
        }

        private void IEEndDateTime_Btn_Click(object sender, EventArgs e)
        {
            IEEndDateTime_Text.Text = DateTime.Now.ToString();
            if (string.IsNullOrEmpty(BGStartDate_Text.Text))
            {
                BGStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void BP1StartDateTime_Btn_Click(object sender, EventArgs e)
        {
            BP1StartDateTime_Text.Text = DateTime.Now.ToString();
            BP1EndDateTime_Text.ReadOnly = false;
            BP1EndDateTime_Btn.Enabled = true;
        }

        private void BP1EndDateTime_Btn_Click(object sender, EventArgs e)
        {
            BP1EndDateTime_Text.Text = DateTime.Now.ToString();
        }

        private void DischargeCounter_Load(object sender, EventArgs e)
        {
            LoadDatesAndTime();
            PatientName_Lbl.Text = PatientName;
            DataLoaded();
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}