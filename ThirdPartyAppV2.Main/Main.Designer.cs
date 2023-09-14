namespace ThirdPartyAppV2.Main
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchAdmitted_Text = new System.Windows.Forms.ToolStripTextBox();
            this.Search_Btn = new System.Windows.Forms.ToolStripButton();
            this.AdmittedPatienstListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dischargeHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hostorySheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prescriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dischargeInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DischIns_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MedAbstract_Btn = new System.Windows.Forms.Button();
            this.DischSum_Btn = new System.Windows.Forms.Button();
            this.HistorySheet_Btn = new System.Windows.Forms.Button();
            this.CustomRpts_Btn = new System.Windows.Forms.Button();
            this.ERTToAdmissionSum_Btn = new System.Windows.Forms.Button();
            this.DischProcSum_Btn = new System.Windows.Forms.Button();
            this.NPSSum_Btn = new System.Windows.Forms.Button();
            this.Prescription_btn = new System.Windows.Forms.Button();
            this.ERToAD_Btn = new System.Windows.Forms.Button();
            this.PerformanceCounter_Btn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DPATAT_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ETAATAT_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.AsForTheMonth_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DateandTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.SearchAdmitted_Text,
            this.Search_Btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1398, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::ThirdPartyAppV2.Main.Properties.Resources.File;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(54, 22);
            this.toolStripDropDownButton1.Text = "&File";
            // 
            // connectionSettingsToolStripMenuItem
            // 
            this.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
            this.connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectionSettingsToolStripMenuItem.Text = "&Connection Settings";
            this.connectionSettingsToolStripMenuItem.Click += new System.EventHandler(this.ConnectionSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // SearchAdmitted_Text
            // 
            this.SearchAdmitted_Text.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SearchAdmitted_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SearchAdmitted_Text.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.SearchAdmitted_Text.Name = "SearchAdmitted_Text";
            this.SearchAdmitted_Text.Size = new System.Drawing.Size(400, 25);
            this.SearchAdmitted_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchAdmitted_Text_KeyPress);
            // 
            // Search_Btn
            // 
            this.Search_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Search_Btn.Image = global::ThirdPartyAppV2.Main.Properties.Resources.Search;
            this.Search_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(62, 22);
            this.Search_Btn.Text = "Search";
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // AdmittedPatienstListView
            // 
            this.AdmittedPatienstListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdmittedPatienstListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.AdmittedPatienstListView.ContextMenuStrip = this.contextMenuStrip1;
            this.AdmittedPatienstListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.AdmittedPatienstListView.FullRowSelect = true;
            this.AdmittedPatienstListView.GridLines = true;
            this.AdmittedPatienstListView.HideSelection = false;
            this.AdmittedPatienstListView.Location = new System.Drawing.Point(0, 25);
            this.AdmittedPatienstListView.Name = "AdmittedPatienstListView";
            this.AdmittedPatienstListView.Size = new System.Drawing.Size(1217, 243);
            this.AdmittedPatienstListView.TabIndex = 1;
            this.AdmittedPatienstListView.UseCompatibleStateImageBehavior = false;
            this.AdmittedPatienstListView.View = System.Windows.Forms.View.Details;
            this.AdmittedPatienstListView.SelectedIndexChanged += new System.EventHandler(this.AdmittedPatienstListView_SelectedIndexChanged);
            this.AdmittedPatienstListView.Click += new System.EventHandler(this.AdmittedPatienstListView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Registry No.";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Patient";
            this.columnHeader2.Width = 350;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Patient Type";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date Admitted";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date Discharged";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Attending Doctor";
            this.columnHeader6.Width = 400;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.dischargeHistoryToolStripMenuItem,
            this.toolStripMenuItem2,
            this.hostorySheetToolStripMenuItem,
            this.prescriptionsToolStripMenuItem,
            this.dischargeInstructionsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 136);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // dischargeHistoryToolStripMenuItem
            // 
            this.dischargeHistoryToolStripMenuItem.Name = "dischargeHistoryToolStripMenuItem";
            this.dischargeHistoryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.dischargeHistoryToolStripMenuItem.Text = "&Discharge History";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItem2.Text = "&Medical Abstract";
            // 
            // hostorySheetToolStripMenuItem
            // 
            this.hostorySheetToolStripMenuItem.Name = "hostorySheetToolStripMenuItem";
            this.hostorySheetToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.hostorySheetToolStripMenuItem.Text = "&Hostory Sheet";
            // 
            // prescriptionsToolStripMenuItem
            // 
            this.prescriptionsToolStripMenuItem.Name = "prescriptionsToolStripMenuItem";
            this.prescriptionsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.prescriptionsToolStripMenuItem.Text = "&Prescriptions";
            // 
            // dischargeInstructionsToolStripMenuItem
            // 
            this.dischargeInstructionsToolStripMenuItem.Name = "dischargeInstructionsToolStripMenuItem";
            this.dischargeInstructionsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.dischargeInstructionsToolStripMenuItem.Text = "Discharge &Instructions";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DischIns_Btn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.MedAbstract_Btn);
            this.panel1.Controls.Add(this.DischSum_Btn);
            this.panel1.Controls.Add(this.HistorySheet_Btn);
            this.panel1.Controls.Add(this.CustomRpts_Btn);
            this.panel1.Controls.Add(this.ERTToAdmissionSum_Btn);
            this.panel1.Controls.Add(this.DischProcSum_Btn);
            this.panel1.Controls.Add(this.NPSSum_Btn);
            this.panel1.Controls.Add(this.Prescription_btn);
            this.panel1.Controls.Add(this.ERToAD_Btn);
            this.panel1.Controls.Add(this.PerformanceCounter_Btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1217, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 584);
            this.panel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Other Reports";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Reports";
            // 
            // DischIns_Btn
            // 
            this.DischIns_Btn.Location = new System.Drawing.Point(3, 208);
            this.DischIns_Btn.Name = "DischIns_Btn";
            this.DischIns_Btn.Size = new System.Drawing.Size(175, 23);
            this.DischIns_Btn.TabIndex = 6;
            this.DischIns_Btn.Text = "Discharge Instruction";
            this.DischIns_Btn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Discharge Instructions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "History Sheet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Discharge Summary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NPS Performance";
            // 
            // MedAbstract_Btn
            // 
            this.MedAbstract_Btn.Location = new System.Drawing.Point(3, 124);
            this.MedAbstract_Btn.Name = "MedAbstract_Btn";
            this.MedAbstract_Btn.Size = new System.Drawing.Size(175, 23);
            this.MedAbstract_Btn.TabIndex = 1;
            this.MedAbstract_Btn.Text = "Medical Abstract";
            this.MedAbstract_Btn.UseVisualStyleBackColor = true;
            // 
            // DischSum_Btn
            // 
            this.DischSum_Btn.Location = new System.Drawing.Point(3, 95);
            this.DischSum_Btn.Name = "DischSum_Btn";
            this.DischSum_Btn.Size = new System.Drawing.Size(175, 23);
            this.DischSum_Btn.TabIndex = 1;
            this.DischSum_Btn.Text = "Discharge Summary";
            this.DischSum_Btn.UseVisualStyleBackColor = true;
            // 
            // HistorySheet_Btn
            // 
            this.HistorySheet_Btn.Location = new System.Drawing.Point(3, 166);
            this.HistorySheet_Btn.Name = "HistorySheet_Btn";
            this.HistorySheet_Btn.Size = new System.Drawing.Size(175, 23);
            this.HistorySheet_Btn.TabIndex = 1;
            this.HistorySheet_Btn.Text = "History Sheet";
            this.HistorySheet_Btn.UseVisualStyleBackColor = true;
            // 
            // CustomRpts_Btn
            // 
            this.CustomRpts_Btn.Location = new System.Drawing.Point(3, 379);
            this.CustomRpts_Btn.Name = "CustomRpts_Btn";
            this.CustomRpts_Btn.Size = new System.Drawing.Size(175, 23);
            this.CustomRpts_Btn.TabIndex = 1;
            this.CustomRpts_Btn.Text = "Custom Reports";
            this.CustomRpts_Btn.UseVisualStyleBackColor = true;
            // 
            // ERTToAdmissionSum_Btn
            // 
            this.ERTToAdmissionSum_Btn.Location = new System.Drawing.Point(3, 337);
            this.ERTToAdmissionSum_Btn.Name = "ERTToAdmissionSum_Btn";
            this.ERTToAdmissionSum_Btn.Size = new System.Drawing.Size(175, 23);
            this.ERTToAdmissionSum_Btn.TabIndex = 1;
            this.ERTToAdmissionSum_Btn.Text = "ER to Admission Summary";
            this.ERTToAdmissionSum_Btn.UseVisualStyleBackColor = true;
            // 
            // DischProcSum_Btn
            // 
            this.DischProcSum_Btn.Location = new System.Drawing.Point(3, 308);
            this.DischProcSum_Btn.Name = "DischProcSum_Btn";
            this.DischProcSum_Btn.Size = new System.Drawing.Size(175, 23);
            this.DischProcSum_Btn.TabIndex = 1;
            this.DischProcSum_Btn.Text = "Discharge Process Summary";
            this.DischProcSum_Btn.UseVisualStyleBackColor = true;
            // 
            // NPSSum_Btn
            // 
            this.NPSSum_Btn.Location = new System.Drawing.Point(3, 279);
            this.NPSSum_Btn.Name = "NPSSum_Btn";
            this.NPSSum_Btn.Size = new System.Drawing.Size(175, 23);
            this.NPSSum_Btn.TabIndex = 1;
            this.NPSSum_Btn.Text = "NPS Performace Summary";
            this.NPSSum_Btn.UseVisualStyleBackColor = true;
            this.NPSSum_Btn.Click += new System.EventHandler(this.NPSReport_Btn_Click);
            // 
            // Prescription_btn
            // 
            this.Prescription_btn.Location = new System.Drawing.Point(3, 237);
            this.Prescription_btn.Name = "Prescription_btn";
            this.Prescription_btn.Size = new System.Drawing.Size(175, 23);
            this.Prescription_btn.TabIndex = 1;
            this.Prescription_btn.Text = "Prescriptions";
            this.Prescription_btn.UseVisualStyleBackColor = true;
            // 
            // ERToAD_Btn
            // 
            this.ERToAD_Btn.Location = new System.Drawing.Point(3, 53);
            this.ERToAD_Btn.Name = "ERToAD_Btn";
            this.ERToAD_Btn.Size = new System.Drawing.Size(175, 23);
            this.ERToAD_Btn.TabIndex = 0;
            this.ERToAD_Btn.Text = "ER to Admission";
            this.ERToAD_Btn.UseVisualStyleBackColor = true;
            this.ERToAD_Btn.Click += new System.EventHandler(this.ERToAD_Btn_Click);
            // 
            // PerformanceCounter_Btn
            // 
            this.PerformanceCounter_Btn.Location = new System.Drawing.Point(3, 24);
            this.PerformanceCounter_Btn.Name = "PerformanceCounter_Btn";
            this.PerformanceCounter_Btn.Size = new System.Drawing.Size(175, 23);
            this.PerformanceCounter_Btn.TabIndex = 0;
            this.PerformanceCounter_Btn.Text = "Discharge Process";
            this.PerformanceCounter_Btn.UseVisualStyleBackColor = true;
            this.PerformanceCounter_Btn.Click += new System.EventHandler(this.PerformanceCounter_Btn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.DPATAT_Label,
            this.toolStripStatusLabel4,
            this.ETAATAT_Label,
            this.AsForTheMonth_Label,
            this.toolStripStatusLabel1,
            this.DateandTimeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1398, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(250, 17);
            this.toolStripStatusLabel2.Text = "Discharge Process Average Turn Arround Time";
            // 
            // DPATAT_Label
            // 
            this.DPATAT_Label.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.DPATAT_Label.Name = "DPATAT_Label";
            this.DPATAT_Label.Size = new System.Drawing.Size(55, 17);
            this.DPATAT_Label.Text = "00:00:00";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(241, 17);
            this.toolStripStatusLabel4.Text = "ER To Admission Average Turn Arround Time";
            // 
            // ETAATAT_Label
            // 
            this.ETAATAT_Label.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            this.ETAATAT_Label.Name = "ETAATAT_Label";
            this.ETAATAT_Label.Size = new System.Drawing.Size(55, 17);
            this.ETAATAT_Label.Text = "00:00:00";
            // 
            // AsForTheMonth_Label
            // 
            this.AsForTheMonth_Label.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F);
            this.AsForTheMonth_Label.Name = "AsForTheMonth_Label";
            this.AsForTheMonth_Label.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(648, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // DateandTimeLabel
            // 
            this.DateandTimeLabel.Image = global::ThirdPartyAppV2.Main.Properties.Resources.Digital_Clock;
            this.DateandTimeLabel.Name = "DateandTimeLabel";
            this.DateandTimeLabel.Size = new System.Drawing.Size(134, 17);
            this.DateandTimeLabel.Text = "toolStripStatusLabel2";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1217, 341);
            this.panel2.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 631);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.AdmittedPatienstListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox SearchAdmitted_Text;
        private System.Windows.Forms.ListView AdmittedPatienstListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel DateandTimeLabel;
        private System.Windows.Forms.Button MedAbstract_Btn;
        private System.Windows.Forms.Button DischSum_Btn;
        private System.Windows.Forms.Button HistorySheet_Btn;
        private System.Windows.Forms.Button Prescription_btn;
        private System.Windows.Forms.Button PerformanceCounter_Btn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dischargeHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hostorySheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prescriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dischargeInstructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Search_Btn;
        private System.Windows.Forms.Button ERToAD_Btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DischIns_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NPSSum_Btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CustomRpts_Btn;
        private System.Windows.Forms.Button ERTToAdmissionSum_Btn;
        private System.Windows.Forms.Button DischProcSum_Btn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel DPATAT_Label;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel ETAATAT_Label;
        private System.Windows.Forms.ToolStripStatusLabel AsForTheMonth_Label;
        private System.Windows.Forms.Panel panel2;
    }
}

