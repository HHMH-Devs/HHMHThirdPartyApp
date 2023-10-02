namespace ThirdPartyAppV2.Main.Reports
{
    partial class RptViewerCommon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.PrintDoc_Btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MonthSelection_Dtp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DailyWeeklySelection_Dtp = new System.Windows.Forms.DateTimePicker();
            this.RptType_Cb = new System.Windows.Forms.ComboBox();
            this.RefreshRpt_Btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cancel_Btn);
            this.panel1.Controls.Add(this.PrintDoc_Btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 681);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 30);
            this.panel1.TabIndex = 0;
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Btn.Location = new System.Drawing.Point(841, 3);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Btn.TabIndex = 0;
            this.Cancel_Btn.Text = "&Cancel";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            // 
            // PrintDoc_Btn
            // 
            this.PrintDoc_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintDoc_Btn.Location = new System.Drawing.Point(760, 3);
            this.PrintDoc_Btn.Name = "PrintDoc_Btn";
            this.PrintDoc_Btn.Size = new System.Drawing.Size(75, 23);
            this.PrintDoc_Btn.TabIndex = 0;
            this.PrintDoc_Btn.Text = "&Print";
            this.PrintDoc_Btn.UseVisualStyleBackColor = true;
            this.PrintDoc_Btn.Click += new System.EventHandler(this.PrintDoc_Btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MonthSelection_Dtp);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.DailyWeeklySelection_Dtp);
            this.panel2.Controls.Add(this.RptType_Cb);
            this.panel2.Controls.Add(this.RefreshRpt_Btn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 29);
            this.panel2.TabIndex = 1;
            // 
            // MonthSelection_Dtp
            // 
            this.MonthSelection_Dtp.CustomFormat = "MMMM";
            this.MonthSelection_Dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MonthSelection_Dtp.Location = new System.Drawing.Point(278, 4);
            this.MonthSelection_Dtp.Name = "MonthSelection_Dtp";
            this.MonthSelection_Dtp.Size = new System.Drawing.Size(132, 20);
            this.MonthSelection_Dtp.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select Date";
            // 
            // DailyWeeklySelection_Dtp
            // 
            this.DailyWeeklySelection_Dtp.Location = new System.Drawing.Point(485, 4);
            this.DailyWeeklySelection_Dtp.Name = "DailyWeeklySelection_Dtp";
            this.DailyWeeklySelection_Dtp.Size = new System.Drawing.Size(236, 20);
            this.DailyWeeklySelection_Dtp.TabIndex = 4;
            // 
            // RptType_Cb
            // 
            this.RptType_Cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RptType_Cb.FormattingEnabled = true;
            this.RptType_Cb.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.RptType_Cb.Location = new System.Drawing.Point(75, 4);
            this.RptType_Cb.Name = "RptType_Cb";
            this.RptType_Cb.Size = new System.Drawing.Size(121, 21);
            this.RptType_Cb.TabIndex = 3;
            this.RptType_Cb.SelectedIndexChanged += new System.EventHandler(this.RptType_Cb_SelectedIndexChanged);
            // 
            // RefreshRpt_Btn
            // 
            this.RefreshRpt_Btn.Location = new System.Drawing.Point(841, 3);
            this.RefreshRpt_Btn.Name = "RefreshRpt_Btn";
            this.RefreshRpt_Btn.Size = new System.Drawing.Size(75, 23);
            this.RefreshRpt_Btn.TabIndex = 2;
            this.RefreshRpt_Btn.Text = "&Refresh";
            this.RefreshRpt_Btn.UseVisualStyleBackColor = true;
            this.RefreshRpt_Btn.Click += new System.EventHandler(this.RefreshRpt_Btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Report Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Month";
            // 
            // RptViewerCommon
            // 
            this.AcceptButton = this.PrintDoc_Btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Btn;
            this.ClientSize = new System.Drawing.Size(919, 711);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RptViewerCommon";
            this.Text = "RptViewer";
            this.Load += new System.EventHandler(this.RptViewerCommon_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button PrintDoc_Btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button RefreshRpt_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RptType_Cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DailyWeeklySelection_Dtp;
        private System.Windows.Forms.DateTimePicker MonthSelection_Dtp;
    }
}