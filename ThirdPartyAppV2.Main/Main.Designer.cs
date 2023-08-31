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
            components = new System.ComponentModel.Container();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SearchAdmitted_Text = new System.Windows.Forms.ToolStripTextBox();
            Search_Btn = new System.Windows.Forms.ToolStripButton();
            AdmittedPatienstListView = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dischargeHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            hostorySheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            prescriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dischargeInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            NPSReport_Btn = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            ERToAD_Btn = new System.Windows.Forms.Button();
            PerformanceCounter_Btn = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            DPATAT_Label = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            ETAATAT_Label = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            DateandTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripDropDownButton1, SearchAdmitted_Text, Search_Btn });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1398, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { connectionSettingsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            toolStripDropDownButton1.Image = Properties.Resources.File;
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new System.Drawing.Size(55, 22);
            toolStripDropDownButton1.Text = "&File";
            // 
            // connectionSettingsToolStripMenuItem
            // 
            connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
            connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            connectionSettingsToolStripMenuItem.Text = "&Connection Settings";
            connectionSettingsToolStripMenuItem.Click += ConnectionSettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // SearchAdmitted_Text
            // 
            SearchAdmitted_Text.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            SearchAdmitted_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            SearchAdmitted_Text.Name = "SearchAdmitted_Text";
            SearchAdmitted_Text.Size = new System.Drawing.Size(400, 25);
            // 
            // Search_Btn
            // 
            Search_Btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            Search_Btn.Image = Properties.Resources.Search;
            Search_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            Search_Btn.Name = "Search_Btn";
            Search_Btn.Size = new System.Drawing.Size(63, 22);
            Search_Btn.Text = "Search";
            Search_Btn.Click += Search_Btn_Click;
            // 
            // AdmittedPatienstListView
            // 
            AdmittedPatienstListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            AdmittedPatienstListView.ContextMenuStrip = contextMenuStrip1;
            AdmittedPatienstListView.Dock = System.Windows.Forms.DockStyle.Fill;
            AdmittedPatienstListView.FullRowSelect = true;
            AdmittedPatienstListView.GridLines = true;
            AdmittedPatienstListView.Location = new System.Drawing.Point(0, 25);
            AdmittedPatienstListView.Name = "AdmittedPatienstListView";
            AdmittedPatienstListView.Size = new System.Drawing.Size(1217, 584);
            AdmittedPatienstListView.TabIndex = 1;
            AdmittedPatienstListView.UseCompatibleStateImageBehavior = false;
            AdmittedPatienstListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Registry No.";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Patient";
            columnHeader2.Width = 350;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Patient Type";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date Admitted";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Date Discharged";
            columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Attending Doctor";
            columnHeader6.Width = 400;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { refreshToolStripMenuItem, dischargeHistoryToolStripMenuItem, toolStripMenuItem2, hostorySheetToolStripMenuItem, prescriptionsToolStripMenuItem, dischargeInstructionsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(194, 136);
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            refreshToolStripMenuItem.Text = "&Refresh";
            refreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
            // 
            // dischargeHistoryToolStripMenuItem
            // 
            dischargeHistoryToolStripMenuItem.Name = "dischargeHistoryToolStripMenuItem";
            dischargeHistoryToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            dischargeHistoryToolStripMenuItem.Text = "&Discharge History";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(193, 22);
            toolStripMenuItem2.Text = "&Medical Abstract";
            // 
            // hostorySheetToolStripMenuItem
            // 
            hostorySheetToolStripMenuItem.Name = "hostorySheetToolStripMenuItem";
            hostorySheetToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            hostorySheetToolStripMenuItem.Text = "&Hostory Sheet";
            // 
            // prescriptionsToolStripMenuItem
            // 
            prescriptionsToolStripMenuItem.Name = "prescriptionsToolStripMenuItem";
            prescriptionsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            prescriptionsToolStripMenuItem.Text = "&Prescriptions";
            // 
            // dischargeInstructionsToolStripMenuItem
            // 
            dischargeInstructionsToolStripMenuItem.Name = "dischargeInstructionsToolStripMenuItem";
            dischargeInstructionsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            dischargeInstructionsToolStripMenuItem.Text = "Discharge &Instructions";
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(NPSReport_Btn);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(ERToAD_Btn);
            panel1.Controls.Add(PerformanceCounter_Btn);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(1217, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(181, 584);
            panel1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 363);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(73, 13);
            label6.TabIndex = 8;
            label6.Text = "Other Reports";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 263);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 13);
            label5.TabIndex = 7;
            label5.Text = "Reports";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(3, 208);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(175, 23);
            button1.TabIndex = 6;
            button1.Text = "Discharge Instruction";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 192);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(112, 13);
            label4.TabIndex = 5;
            label4.Text = "Discharge Instructions";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 13);
            label3.TabIndex = 4;
            label3.Text = "History Sheet";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 79);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 13);
            label2.TabIndex = 3;
            label2.Text = "Discharge Summary";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 13);
            label1.TabIndex = 2;
            label1.Text = "NPS Performance";
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(3, 124);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(175, 23);
            button5.TabIndex = 1;
            button5.Text = "Medical Abstract";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(3, 95);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(175, 23);
            button4.TabIndex = 1;
            button4.Text = "Discharge Summary";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(3, 166);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(175, 23);
            button3.TabIndex = 1;
            button3.Text = "History Sheet";
            button3.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(3, 379);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(175, 23);
            button9.TabIndex = 1;
            button9.Text = "Custom Reports";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(3, 337);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(175, 23);
            button8.TabIndex = 1;
            button8.Text = "ER to Admission Summary";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(3, 308);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(175, 23);
            button7.TabIndex = 1;
            button7.Text = "Discharge Process Summary";
            button7.UseVisualStyleBackColor = true;
            // 
            // NPSReport_Btn
            // 
            NPSReport_Btn.Location = new System.Drawing.Point(3, 279);
            NPSReport_Btn.Name = "NPSReport_Btn";
            NPSReport_Btn.Size = new System.Drawing.Size(175, 23);
            NPSReport_Btn.TabIndex = 1;
            NPSReport_Btn.Text = "NPS Performace Summary";
            NPSReport_Btn.UseVisualStyleBackColor = true;
            NPSReport_Btn.Click += NPSReport_Btn_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(3, 237);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(175, 23);
            button2.TabIndex = 1;
            button2.Text = "Prescriptions";
            button2.UseVisualStyleBackColor = true;
            // 
            // ERToAD_Btn
            // 
            ERToAD_Btn.Location = new System.Drawing.Point(3, 53);
            ERToAD_Btn.Name = "ERToAD_Btn";
            ERToAD_Btn.Size = new System.Drawing.Size(175, 23);
            ERToAD_Btn.TabIndex = 0;
            ERToAD_Btn.Text = "ER to Admission";
            ERToAD_Btn.UseVisualStyleBackColor = true;
            ERToAD_Btn.Click += ERToAD_Btn_Click;
            // 
            // PerformanceCounter_Btn
            // 
            PerformanceCounter_Btn.Location = new System.Drawing.Point(3, 24);
            PerformanceCounter_Btn.Name = "PerformanceCounter_Btn";
            PerformanceCounter_Btn.Size = new System.Drawing.Size(175, 23);
            PerformanceCounter_Btn.TabIndex = 0;
            PerformanceCounter_Btn.Text = "Discharge Process";
            PerformanceCounter_Btn.UseVisualStyleBackColor = true;
            PerformanceCounter_Btn.Click += PerformanceCounter_Btn_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel2, DPATAT_Label, toolStripStatusLabel4, ETAATAT_Label, toolStripStatusLabel1, DateandTimeLabel });
            statusStrip1.Location = new System.Drawing.Point(0, 609);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1398, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(262, 17);
            toolStripStatusLabel2.Text = "Discharge Process Average Turn Arround Time";
            // 
            // DPATAT_Label
            // 
            DPATAT_Label.Name = "DPATAT_Label";
            DPATAT_Label.Size = new System.Drawing.Size(50, 17);
            DPATAT_Label.Text = "00:00:00";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold);
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(253, 17);
            toolStripStatusLabel4.Text = "ER To Admission Average Turn Arround Time";
            // 
            // ETAATAT_Label
            // 
            ETAATAT_Label.Name = "ETAATAT_Label";
            ETAATAT_Label.Size = new System.Drawing.Size(50, 17);
            ETAATAT_Label.Text = "00:00:00";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(633, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // DateandTimeLabel
            // 
            DateandTimeLabel.Image = Properties.Resources.Digital_Clock;
            DateandTimeLabel.Name = "DateandTimeLabel";
            DateandTimeLabel.Size = new System.Drawing.Size(135, 17);
            DateandTimeLabel.Text = "toolStripStatusLabel2";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1398, 631);
            Controls.Add(AdmittedPatienstListView);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NPSReport_Btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel DPATAT_Label;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel ETAATAT_Label;
    }
}

