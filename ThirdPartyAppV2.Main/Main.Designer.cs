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
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            ERToAD_Btn = new System.Windows.Forms.Button();
            PerformanceCounter_Btn = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            DateandTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
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
            toolStrip1.Size = new System.Drawing.Size(1209, 25);
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
            AdmittedPatienstListView.Size = new System.Drawing.Size(1028, 584);
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
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(ERToAD_Btn);
            panel1.Controls.Add(PerformanceCounter_Btn);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(1028, 25);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(181, 584);
            panel1.TabIndex = 2;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(3, 148);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(175, 23);
            button5.TabIndex = 1;
            button5.Text = "Medical Abstract";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(3, 119);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(175, 23);
            button4.TabIndex = 1;
            button4.Text = "Discharge Summary";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(3, 90);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(175, 23);
            button3.TabIndex = 1;
            button3.Text = "History Sheet";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(3, 61);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(175, 23);
            button2.TabIndex = 1;
            button2.Text = "Prescriptions";
            button2.UseVisualStyleBackColor = true;
            // 
            // ERToAD_Btn
            // 
            ERToAD_Btn.Location = new System.Drawing.Point(3, 32);
            ERToAD_Btn.Name = "ERToAD_Btn";
            ERToAD_Btn.Size = new System.Drawing.Size(175, 23);
            ERToAD_Btn.TabIndex = 0;
            ERToAD_Btn.Text = "ER to Admission";
            ERToAD_Btn.UseVisualStyleBackColor = true;
            ERToAD_Btn.Click += ERToAD_Btn_Click;
            // 
            // PerformanceCounter_Btn
            // 
            PerformanceCounter_Btn.Location = new System.Drawing.Point(3, 3);
            PerformanceCounter_Btn.Name = "PerformanceCounter_Btn";
            PerformanceCounter_Btn.Size = new System.Drawing.Size(175, 23);
            PerformanceCounter_Btn.TabIndex = 0;
            PerformanceCounter_Btn.Text = "Discharge Process";
            PerformanceCounter_Btn.UseVisualStyleBackColor = true;
            PerformanceCounter_Btn.Click += PerformanceCounter_Btn_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel1, DateandTimeLabel });
            statusStrip1.Location = new System.Drawing.Point(0, 609);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1209, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(821, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // DateandTimeLabel
            // 
            DateandTimeLabel.Image = Properties.Resources.Digital_Clock;
            DateandTimeLabel.Name = "DateandTimeLabel";
            DateandTimeLabel.Size = new System.Drawing.Size(135, 17);
            DateandTimeLabel.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(119, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(119, 17);
            toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1209, 631);
            Controls.Add(AdmittedPatienstListView);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "Main";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

