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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Cancel_Btn);
            panel1.Controls.Add(PrintDoc_Btn);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 420);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(800, 30);
            panel1.TabIndex = 0;
            // 
            // Cancel_Btn
            // 
            Cancel_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Cancel_Btn.Location = new System.Drawing.Point(722, 3);
            Cancel_Btn.Name = "Cancel_Btn";
            Cancel_Btn.Size = new System.Drawing.Size(75, 23);
            Cancel_Btn.TabIndex = 0;
            Cancel_Btn.Text = "&Cancel";
            Cancel_Btn.UseVisualStyleBackColor = true;
            // 
            // PrintDoc_Btn
            // 
            PrintDoc_Btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PrintDoc_Btn.Location = new System.Drawing.Point(641, 3);
            PrintDoc_Btn.Name = "PrintDoc_Btn";
            PrintDoc_Btn.Size = new System.Drawing.Size(75, 23);
            PrintDoc_Btn.TabIndex = 0;
            PrintDoc_Btn.Text = "&Print";
            PrintDoc_Btn.UseVisualStyleBackColor = true;
            PrintDoc_Btn.Click += PrintDoc_Btn_Click;
            // 
            // RptViewerCommon
            // 
            AcceptButton = PrintDoc_Btn;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel_Btn;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel1);
            Name = "RptViewerCommon";
            Text = "RptViewer";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button PrintDoc_Btn;
    }
}