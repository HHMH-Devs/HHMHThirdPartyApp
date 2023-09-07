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
            panel1 = new System.Windows.Forms.Panel();
            Cancel_Btn = new System.Windows.Forms.Button();
            PrintDoc_Btn = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            DailyWeeklySelection_Dtp = new System.Windows.Forms.DateTimePicker();
            RptType_Cb = new System.Windows.Forms.ComboBox();
            RefreshRpt_Btn = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            MonthSelection_Dtp = new System.Windows.Forms.DateTimePicker();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Cancel_Btn);
            panel1.Controls.Add(PrintDoc_Btn);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 681);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(919, 30);
            panel1.TabIndex = 0;
            // 
            // Cancel_Btn
            // 
            Cancel_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Cancel_Btn.Location = new System.Drawing.Point(841, 3);
            Cancel_Btn.Name = "Cancel_Btn";
            Cancel_Btn.Size = new System.Drawing.Size(75, 23);
            Cancel_Btn.TabIndex = 0;
            Cancel_Btn.Text = "&Cancel";
            Cancel_Btn.UseVisualStyleBackColor = true;
            // 
            // PrintDoc_Btn
            // 
            PrintDoc_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PrintDoc_Btn.Location = new System.Drawing.Point(760, 3);
            PrintDoc_Btn.Name = "PrintDoc_Btn";
            PrintDoc_Btn.Size = new System.Drawing.Size(75, 23);
            PrintDoc_Btn.TabIndex = 0;
            PrintDoc_Btn.Text = "&Print";
            PrintDoc_Btn.UseVisualStyleBackColor = true;
            PrintDoc_Btn.Click += PrintDoc_Btn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(MonthSelection_Dtp);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(DailyWeeklySelection_Dtp);
            panel2.Controls.Add(RptType_Cb);
            panel2.Controls.Add(RefreshRpt_Btn);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(919, 29);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(416, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 13);
            label3.TabIndex = 5;
            label3.Text = "Select Date";
            // 
            // DailyWeeklySelection_Dtp
            // 
            DailyWeeklySelection_Dtp.Location = new System.Drawing.Point(485, 4);
            DailyWeeklySelection_Dtp.Name = "DailyWeeklySelection_Dtp";
            DailyWeeklySelection_Dtp.Size = new System.Drawing.Size(236, 20);
            DailyWeeklySelection_Dtp.TabIndex = 4;
            // 
            // RptType_Cb
            // 
            RptType_Cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            RptType_Cb.FormattingEnabled = true;
            RptType_Cb.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly" });
            RptType_Cb.Location = new System.Drawing.Point(75, 4);
            RptType_Cb.Name = "RptType_Cb";
            RptType_Cb.Size = new System.Drawing.Size(121, 21);
            RptType_Cb.TabIndex = 3;
            RptType_Cb.SelectedIndexChanged += RptType_Cb_SelectedIndexChanged;
            // 
            // RefreshRpt_Btn
            // 
            RefreshRpt_Btn.Location = new System.Drawing.Point(841, 3);
            RefreshRpt_Btn.Name = "RefreshRpt_Btn";
            RefreshRpt_Btn.Size = new System.Drawing.Size(75, 23);
            RefreshRpt_Btn.TabIndex = 2;
            RefreshRpt_Btn.Text = "&Refresh";
            RefreshRpt_Btn.UseVisualStyleBackColor = true;
            RefreshRpt_Btn.Click += RefreshRpt_Btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 13);
            label2.TabIndex = 1;
            label2.Text = "Report Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(202, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 13);
            label1.TabIndex = 1;
            label1.Text = "Select Month";
            // 
            // MonthSelection_Dtp
            // 
            MonthSelection_Dtp.CustomFormat = "MMMM";
            MonthSelection_Dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            MonthSelection_Dtp.Location = new System.Drawing.Point(278, 4);
            MonthSelection_Dtp.Name = "MonthSelection_Dtp";
            MonthSelection_Dtp.Size = new System.Drawing.Size(132, 20);
            MonthSelection_Dtp.TabIndex = 2;
            // 
            // RptViewerCommon
            // 
            AcceptButton = PrintDoc_Btn;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel_Btn;
            ClientSize = new System.Drawing.Size(919, 711);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "RptViewerCommon";
            Text = "RptViewer";
            Load += RptViewerCommon_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
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