﻿namespace FileDownloaderForm
{
    partial class frmDownloadeProgress
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
            progressBar1 = new ProgressBar();
            lblProgressPercentage = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(28, 41);
            progressBar1.Margin = new Padding(3, 2, 3, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(374, 22);
            progressBar1.TabIndex = 0;
            // 
            // lblProgressPercentage
            // 
            lblProgressPercentage.AutoSize = true;
            lblProgressPercentage.Location = new Point(427, 45);
            lblProgressPercentage.Name = "lblProgressPercentage";
            lblProgressPercentage.Size = new Size(12, 15);
            lblProgressPercentage.TabIndex = 4;
            lblProgressPercentage.Text = "?";
            // 
            // frmDownloadeProgress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 92);
            Controls.Add(lblProgressPercentage);
            Controls.Add(progressBar1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmDownloadeProgress";
            Text = "frmDownloadeProgress";
            Load += frmDownloadeProgress_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblProgressPercentage;
    }
}