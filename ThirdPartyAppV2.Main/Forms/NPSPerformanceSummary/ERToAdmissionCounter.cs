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
    public partial class ERToAdmissionCounter : Form
    {
        public string PatientName;
        public string PatRegistryNo;
        private readonly NPSCounter nPSCounter = new();
        private readonly Dictionary<string, TimeSpan> timerList = new();

        public ERToAdmissionCounter()
        {
            InitializeComponent();
        }

        private void ERToAdmissionCounter_Load(object sender, EventArgs e)
        {
            LoadDatesAndTime();
            PatientName_Lbl.Text = PatientName;
            DataLoaded();
        }

        private void DataLoaded()
        {
            var txt = groupBox2.Controls.OfType<TextBox>().ToList();
            var btn = groupBox2.Controls.OfType<Button>().ToList();
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
            var stData = nPSCounter.LoadDataFromMySqlER(Convert.ToInt32(PatRegistryNo));
            if (stData.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow rw in stData.Tables[0].Rows)
                {
                    RegToDctrsOderStartDate_Text.Text = rw["RegToDocStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["RegToDocStartDateTime"].ToString();
                    RegToDctrsOderEndDate_Text.Text = rw["RegToDocEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["RegToDocEndDateTime"].ToString();
                    DctrsOrderCarryOutStartDate_Text.Text = rw["DocOrderStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["DocOrderStartDateTime"].ToString();
                    DctrsOrderCarryOutEndDate_Text.Text = rw["DocOrderEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["DocOrderEndDateTime"].ToString();
                    APPStartDate_Text.Text = rw["APPStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["APPStartDateTime"].ToString();
                    APPEndDate_Text.Text = rw["APPEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["APPEndDateTime"].ToString();
                    PhicSubStartDate_Text.Text = rw["PHICStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["PHICStartDateTime"].ToString();
                    PhicSubEndDate_Text.Text = rw["PHICEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["PHICEndDateTime"].ToString();
                    RPStartDate_Text.Text = rw["RPStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["RPStartDateTime"].ToString();
                    RPEndDate_Text.Text = rw["RPDocEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["RPDocEndDateTime"].ToString();
                    NCOStartDate_Text.Text = rw["NCODocStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["NCODocStartDateTime"].ToString();
                    NCOEndDate_Text.Text = rw["NCOEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["NCOEndDateTime"].ToString();
                    ReadyToTransferStartDate_Text.Text = rw["ReadyToTransStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["ReadyToTransStartDateTime"].ToString();
                    ReadyToTransferEndDate_Text.Text = rw["ReadyToTransEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["ReadyToTransEndDateTime"].ToString();
                    TransferToRoomStartDate_Text.Text = rw["TransToRoomStartDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["TransToRoomStartDateTime"].ToString();
                    TransferToRoomEndDate_Text.Text = rw["TransToRoomEndDateTime"].ToString() == DateTime.MinValue.ToString() ? "" : rw["TransToRoomEndDateTime"].ToString();
                    RToDOLabel_Lbl.Text = $"Registration to Doctor's Order Done - {GetMDTimeDiff("Registration to Doctor's Order Done", RegToDctrsOderStartDate_Text.Text, RegToDctrsOderEndDate_Text.Text)}";
                    DOCOLabel_Lbl.Text = $"Doctor's Order Carry Out - {GetMDTimeDiff("Doctor's Order Carry Out", DctrsOrderCarryOutStartDate_Text.Text, DctrsOrderCarryOutEndDate_Text.Text)}";
                    APPLabel_Lbl.Text = $"Admitting/Patient Profiling - {GetMDTimeDiff("Admitting/Patient Profiling", APPStartDate_Text.Text, APPEndDate_Text.Text)}";
                    PHICLabel_Lbl.Text = $"PHIC Submission - {GetMDTimeDiff("PHIC Submission", PhicSubStartDate_Text.Text, PhicSubEndDate_Text.Text)}";
                    RPLabel_Lbl.Text = $"Room Preparation - {GetMDTimeDiff("Room Preparation", RPStartDate_Text.Text, RPEndDate_Text.Text)}";
                    NCOLabel_Lbl.Text = $"Nurses Carry Out - {GetMDTimeDiff("Nurses Carry Out", NCOStartDate_Text.Text, NCOEndDate_Text.Text)}";
                    RToTLabel_Lbl.Text = $"Ready for Transfer - {GetMDTimeDiff("Ready for Transfer", ReadyToTransferStartDate_Text.Text, ReadyToTransferEndDate_Text.Text)}";
                    TransToRoomLabel_Lbl.Text = $"Transfer to Room - {GetMDTimeDiff("Transfer to Room", TransferToRoomStartDate_Text.Text, TransferToRoomEndDate_Text.Text)}";
                }
            }
            else
            {
                if (nPSCounter.ErCaseDateTime(PatRegistryNo) != null)
                {
                    foreach (DataRow item in nPSCounter.ErCaseDateTime(PatRegistryNo).Tables[0].Rows)
                    {
                        if (!string.IsNullOrEmpty(item["registrydate"].ToString()))
                        {
                            RegToDctrsOderStartDate_Text.Text = item["registrydate"].ToString();
                            RegToDctrsOderStartDate_Text.ReadOnly = true;
                            RegToDctrsOderStartDate_Btn.Enabled = false;
                            RToDOLabel_Lbl.Text = $"Registration to Doctor's Order Done - {GetMDTimeDiff("Registration to Doctor's Order Done", RegToDctrsOderStartDate_Text.Text, RegToDctrsOderEndDate_Text.Text)}";
                        }

                        if (!string.IsNullOrEmpty(item["patclass"].ToString()))
                        {
                            if (DateTime.TryParse(item["patclass"].ToString(), out DateTime dt))
                            {
                                RegToDctrsOderEndDate_Text.Text = dt.ToString();
                                RegToDctrsOderEndDate_Text.ReadOnly = true;
                                RegToDctrsOderEndDate_Btn.Enabled = false;
                                RToDOLabel_Lbl.Text = $"Registration to Doctor's Order Done - {GetMDTimeDiff("Registration to Doctor's Order Done", RegToDctrsOderStartDate_Text.Text, RegToDctrsOderEndDate_Text.Text)}";
                                DctrsOrderCarryOutStartDate_Text.Text = dt.ToString();
                                DctrsOrderCarryOutStartDate_Text.ReadOnly = true;
                                DctrsOrderCarryOutStartDate_Btn.Enabled = false;
                                DOCOLabel_Lbl.Text = $"Doctor's Order Carry Out - {GetMDTimeDiff("Doctor's Order Carry Out", DctrsOrderCarryOutStartDate_Text.Text, DctrsOrderCarryOutEndDate_Text.Text)}";
                                foreach (DataRow b in nPSCounter.ErInPatient(PatientName, dt.ToString()).Tables[0].Rows)
                                {
                                    TransferToRoomEndDate_Text.Text = b["arrivedate"].ToString();
                                    TransferToRoomEndDate_Text.ReadOnly = true;
                                    TransferToRoomEndDate_Btn.Enabled = false;
                                    TransToRoomLabel_Lbl.Text = $"Transfer to Room - {GetMDTimeDiff("Transfer to Room", TransferToRoomStartDate_Text.Text, TransferToRoomEndDate_Text.Text)}";
                                }
                            }
                            else
                            {
                                var st = item["patclass"].ToString().Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                                var newdate = string.Join(" ", st);
                                var fixedDate = DateTime.TryParse(newdate, out dt);
                                if (fixedDate)
                                {
                                    RegToDctrsOderEndDate_Text.Text = dt.ToString();
                                    RegToDctrsOderEndDate_Text.ReadOnly = true;
                                    RegToDctrsOderEndDate_Btn.Enabled = false;
                                    RToDOLabel_Lbl.Text = $"Registration to Doctor's Order Done - {GetMDTimeDiff("Registration to Doctor's Order Done", RegToDctrsOderStartDate_Text.Text, RegToDctrsOderEndDate_Text.Text)}";
                                    DctrsOrderCarryOutStartDate_Text.Text = dt.ToString();
                                    DctrsOrderCarryOutStartDate_Text.ReadOnly = true;
                                    DctrsOrderCarryOutStartDate_Btn.Enabled = false;
                                    DOCOLabel_Lbl.Text = $"Doctor's Order Carry Out - {GetMDTimeDiff("Doctor's Order Carry Out", DctrsOrderCarryOutStartDate_Text.Text, DctrsOrderCarryOutEndDate_Text.Text)}";
                                    foreach (DataRow b in nPSCounter.ErInPatient(PatientName, dt.ToString()).Tables[0].Rows)
                                    {
                                        TransferToRoomEndDate_Text.Text = b["arrivedate"].ToString();
                                        TransferToRoomEndDate_Text.ReadOnly = true;
                                        TransferToRoomEndDate_Btn.Enabled = false;
                                        TransToRoomLabel_Lbl.Text = $"Transfer to Room - {GetMDTimeDiff("Transfer to Room", TransferToRoomStartDate_Text.Text, TransferToRoomEndDate_Text.Text)}";
                                    }
                                }
                            }
                        }

                    }

                }
            }
            if (string.IsNullOrEmpty(RegToDctrsOderStartDate_Text.Text))
            {
                RegToDctrsOderEndDate_Text.ReadOnly = true;
                RegToDctrsOderEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(DctrsOrderCarryOutStartDate_Text.Text))
            {
                DctrsOrderCarryOutEndDate_Text.ReadOnly = true;
                DctrsOrderCarryOutEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(APPStartDate_Text.Text))
            {
                APPEndDate_Text.ReadOnly = true;
                APPEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(PhicSubStartDate_Text.Text))
            {
                PhicSubEndDate_Text.ReadOnly = true;
                PhicSubEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(RPStartDate_Text.Text))
            {
                RPEndDate_Text.ReadOnly = true;
                RPEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(NCOStartDate_Text.Text))
            {
                NCOEndDate_Text.ReadOnly = true;
                NCOEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(ReadyToTransferStartDate_Text.Text))
            {
                ReadyToTransferEndDate_Text.ReadOnly = true;
                ReadyToTransferEndDate_Btn.Enabled = false;
            }
            if (string.IsNullOrEmpty(TransferToRoomStartDate_Text.Text))
            {
                TransferToRoomEndDate_Text.ReadOnly = true;
                TransferToRoomEndDate_Btn.Enabled = false;
            }
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

                ERToAdmissionTotalET_Label.Text = totalTime.ToString("h' hr(s), 'm' min(s) and 's' second(s)'");

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


        private void RegToDctrsOderStartDate_Btn_Click(object sender, EventArgs e)
        {
            RegToDctrsOderStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void RegToDctrsOderEndDate_Btn_Click(object sender, EventArgs e)
        {
            RegToDctrsOderEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void DctrsOrderCarryOutStartDate_Btn_Click(object sender, EventArgs e)
        {
            DctrsOrderCarryOutStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void DctrsOrderCarryOutEndDate_Btn_Click(object sender, EventArgs e)
        {
            DctrsOrderCarryOutEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void ReadyToTransferStartDate_Btn_Click(object sender, EventArgs e)
        {
            ReadyToTransferStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void ReadyToTransferEndDate_Btn_Click(object sender, EventArgs e)
        {
            ReadyToTransferEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void TransferToRoomStartDate_Btn_Click(object sender, EventArgs e)
        {
            TransferToRoomStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void TransferToRoomEndDate_Btn_Click(object sender, EventArgs e)
        {
            TransferToRoomEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void Done_Btn_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "&Edit")
            {
                var txt = groupBox2.Controls.OfType<TextBox>().ToList();
                var btn = groupBox2.Controls.OfType<Button>().ToList();
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
                    var isSaved = nPSCounter.SaveDataErToAdmission(Convert.ToInt32(Tag),
                        PatientName_Lbl.Text,
                        Convert.ToDateTime(string.IsNullOrEmpty(RegToDctrsOderStartDate_Text.Text) ? DateTime.MinValue.ToString() : RegToDctrsOderStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(RegToDctrsOderEndDate_Text.Text) ? DateTime.MinValue.ToString() : RegToDctrsOderEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(DctrsOrderCarryOutStartDate_Text.Text) ? DateTime.MinValue.ToString() : DctrsOrderCarryOutStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(DctrsOrderCarryOutEndDate_Text.Text) ? DateTime.MinValue.ToString() : DctrsOrderCarryOutEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(APPStartDate_Text.Text) ? DateTime.MinValue.ToString() : APPStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(APPEndDate_Text.Text) ? DateTime.MinValue.ToString() : APPEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(PhicSubStartDate_Text.Text) ? DateTime.MinValue.ToString() : PhicSubStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(PhicSubEndDate_Text.Text) ? DateTime.MinValue.ToString() : PhicSubEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(RPStartDate_Text.Text) ? DateTime.MinValue.ToString() : RPStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(RPEndDate_Text.Text) ? DateTime.MinValue.ToString() : RPEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(NCOStartDate_Text.Text) ? DateTime.MinValue.ToString() : NCOStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(NCOEndDate_Text.Text) ? DateTime.MinValue.ToString() : NCOEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(ReadyToTransferStartDate_Text.Text) ? DateTime.MinValue.ToString() : ReadyToTransferStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(ReadyToTransferEndDate_Text.Text) ? DateTime.MinValue.ToString() : ReadyToTransferEndDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(TransferToRoomStartDate_Text.Text) ? DateTime.MinValue.ToString() : TransferToRoomStartDate_Text.Text),
                        Convert.ToDateTime(string.IsNullOrEmpty(TransferToRoomEndDate_Text.Text) ? DateTime.MinValue.ToString() : TransferToRoomEndDate_Text.Text));
                    if (isSaved)
                    {
                        MessageBox.Show("Successfully Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void RegToDctrsOderStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(RegToDctrsOderStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(RegToDctrsOderEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                RToDOLabel_Lbl.Text = $"Registration to Doctor's Order Done - {GetMDTimeDiff("Registration to Doctor's Order Done", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void RegToDctrsOderEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(RegToDctrsOderStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(RegToDctrsOderEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                RToDOLabel_Lbl.Text = $"Registration to Doctor's Order Done - {GetMDTimeDiff("Registration to Doctor's Order Done", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            if (string.IsNullOrEmpty(DctrsOrderCarryOutStartDate_Text.Text))
            {
                DctrsOrderCarryOutStartDate_Text.Text = DateTime.Now.ToString();
            }

        }

        private void DctrsOrderCarryOutStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(DctrsOrderCarryOutStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(DctrsOrderCarryOutEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                DOCOLabel_Lbl.Text = $"Doctor's Order Carry Out - {GetMDTimeDiff("Doctor's Order Carry Out", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void DctrsOrderCarryOutEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(DctrsOrderCarryOutStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(DctrsOrderCarryOutEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                DOCOLabel_Lbl.Text = $"Doctor's Order Carry Out - {GetMDTimeDiff("Doctor's Order Carry Out", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            if (string.IsNullOrEmpty(APPStartDate_Text.Text))
            {
                APPStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void ReadyToTransferStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(ReadyToTransferStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(ReadyToTransferEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                RToTLabel_Lbl.Text = $"Ready for Transfer - {GetMDTimeDiff("Ready for Transfer", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void ReadyToTransferEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(ReadyToTransferStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(ReadyToTransferEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                RToTLabel_Lbl.Text = $"Ready for Transfer - {GetMDTimeDiff("Ready for Transfer", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            if (string.IsNullOrEmpty(TransferToRoomStartDate_Text.Text))
            {
                TransferToRoomStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void TransferToRoomStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(TransferToRoomStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(TransferToRoomEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                TransToRoomLabel_Lbl.Text = $"Transfer to Room - {GetMDTimeDiff("Transfer to Room", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void TransferToRoomEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(TransferToRoomStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(TransferToRoomEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                TransToRoomLabel_Lbl.Text = $"Transfer to Room - {GetMDTimeDiff("Transfer to Room", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void APPEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(APPStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(APPEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                APPLabel_Lbl.Text = $"Admitting/Patient Profiling - {GetMDTimeDiff("Admitting/Patient Profiling", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }

            if (string.IsNullOrEmpty(PhicSubStartDate_Text.Text))
            {
                PhicSubStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void APPStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(APPStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(APPEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                APPLabel_Lbl.Text = $"Admitting/Patient Profiling - {GetMDTimeDiff("Admitting/Patient Profiling", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void PhicSubStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(PhicSubStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(PhicSubEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                PHICLabel_Lbl.Text = $"PHIC Submission - {GetMDTimeDiff("PHIC Submission", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void PhicSubEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(PhicSubStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(PhicSubEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                PHICLabel_Lbl.Text = $"PHIC Submission - {GetMDTimeDiff("PHIC Submission", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            if (string.IsNullOrEmpty(RPStartDate_Text.Text))
            {
                RPStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void RPStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(RPStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(RPEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                RPLabel_Lbl.Text = $"Room Preparation - {GetMDTimeDiff("Room Preparation", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void RPEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(RPStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(RPEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                RPLabel_Lbl.Text = $"Room Preparation - {GetMDTimeDiff("Room Preparation", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            if (string.IsNullOrEmpty(NCOStartDate_Text.Text))
            {
                NCOStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void NCOStartDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(NCOStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(NCOEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                NCOLabel_Lbl.Text = $"Nurses Carry Out - {GetMDTimeDiff("Nurses Carry Out", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
        }

        private void NCOEndDate_Text_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(NCOStartDate_Text.Text, out DateTime parsedDateTime1) && DateTime.TryParse(NCOEndDate_Text.Text, out DateTime parsedDateTime2))
            {
                NCOLabel_Lbl.Text = $"Nurses Carry Out - {GetMDTimeDiff("Nurses Carry Out", parsedDateTime1.ToString(), parsedDateTime2.ToString())}";
            }
            if (string.IsNullOrEmpty(ReadyToTransferStartDate_Text.Text))
            {
                ReadyToTransferStartDate_Text.Text = DateTime.Now.ToString();
            }
        }

        private void APPStartDate_Btn_Click(object sender, EventArgs e)
        {
            APPStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void APPEndDate_Btn_Click(object sender, EventArgs e)
        {
            APPEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void PhicSubStartDate_Btn_Click(object sender, EventArgs e)
        {
            PhicSubStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void PhicSubEndDate_Btn_Click(object sender, EventArgs e)
        {
            PhicSubEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void RPStartDate_Btn_Click(object sender, EventArgs e)
        {
            RPStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void RPEndDate_Btn_Click(object sender, EventArgs e)
        {
            RPEndDate_Text.Text = DateTime.Now.ToString();
        }

        private void NCOStartDate_Btn_Click(object sender, EventArgs e)
        {
            NCOStartDate_Text.Text = DateTime.Now.ToString();
        }

        private void NCOEndDate_Btn_Click(object sender, EventArgs e)
        {
            NCOEndDate_Text.Text = DateTime.Now.ToString();
        }
    }
}
