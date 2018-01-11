using System;
using System.Windows.Forms;

namespace FileCopier
{
    partial class UserInterface
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
            this.uxProgressLabel = new System.Windows.Forms.Label();
            this.uxDest = new System.Windows.Forms.TextBox();
            this.uxSource = new System.Windows.Forms.TextBox();
            this.uxDestButton = new System.Windows.Forms.Button();
            this.uxSourceButton = new System.Windows.Forms.Button();
            this.uxProgressBar = new System.Windows.Forms.ProgressBar();
            this.uxCopyButton = new System.Windows.Forms.Button();
            this.uxSourceBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.uxDestBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // uxProgressLabel
            // 
            this.uxProgressLabel.AutoSize = true;
            this.uxProgressLabel.Location = new System.Drawing.Point(123, 96);
            this.uxProgressLabel.Name = "uxProgressLabel";
            this.uxProgressLabel.Size = new System.Drawing.Size(24, 13);
            this.uxProgressLabel.TabIndex = 14;
            this.uxProgressLabel.Text = "0/0";
            // 
            // uxDest
            // 
            this.uxDest.Location = new System.Drawing.Point(12, 44);
            this.uxDest.Name = "uxDest";
            this.uxDest.ReadOnly = true;
            this.uxDest.Size = new System.Drawing.Size(221, 20);
            this.uxDest.TabIndex = 13;
            // 
            // uxSource
            // 
            this.uxSource.Location = new System.Drawing.Point(12, 12);
            this.uxSource.Name = "uxSource";
            this.uxSource.ReadOnly = true;
            this.uxSource.Size = new System.Drawing.Size(221, 20);
            this.uxSource.TabIndex = 12;
            // 
            // uxDestButton
            // 
            this.uxDestButton.Location = new System.Drawing.Point(239, 41);
            this.uxDestButton.Name = "uxDestButton";
            this.uxDestButton.Size = new System.Drawing.Size(32, 23);
            this.uxDestButton.TabIndex = 11;
            this.uxDestButton.Text = "...";
            this.uxDestButton.UseVisualStyleBackColor = true;
            this.uxDestButton.Click += new System.EventHandler(this.uxDestButton_Click);
            // 
            // uxSourceButton
            // 
            this.uxSourceButton.Location = new System.Drawing.Point(239, 12);
            this.uxSourceButton.Name = "uxSourceButton";
            this.uxSourceButton.Size = new System.Drawing.Size(32, 23);
            this.uxSourceButton.TabIndex = 10;
            this.uxSourceButton.Text = "...";
            this.uxSourceButton.UseVisualStyleBackColor = true;
            this.uxSourceButton.Click += new System.EventHandler(this.uxSourceButton_Click);
            // 
            // uxProgressBar
            // 
            this.uxProgressBar.Location = new System.Drawing.Point(12, 70);
            this.uxProgressBar.Name = "uxProgressBar";
            this.uxProgressBar.Size = new System.Drawing.Size(259, 23);
            this.uxProgressBar.TabIndex = 9;
            // 
            // uxCopyButton
            // 
            this.uxCopyButton.Location = new System.Drawing.Point(12, 126);
            this.uxCopyButton.Name = "uxCopyButton";
            this.uxCopyButton.Size = new System.Drawing.Size(259, 23);
            this.uxCopyButton.TabIndex = 8;
            this.uxCopyButton.Text = "Copy";
            this.uxCopyButton.UseVisualStyleBackColor = true;
            this.uxCopyButton.Click += new System.EventHandler(this.uxCopyButton_ClickAsync);
            // 
            // UserInterface
            // 
            this.ClientSize = new System.Drawing.Size(284, 163);
            this.Controls.Add(this.uxProgressLabel);
            this.Controls.Add(this.uxDest);
            this.Controls.Add(this.uxSource);
            this.Controls.Add(this.uxDestButton);
            this.Controls.Add(this.uxSourceButton);
            this.Controls.Add(this.uxProgressBar);
            this.Controls.Add(this.uxCopyButton);
            this.Name = "UserInterface";
            this.Text = "Copy Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private Label uxProgressLabel;
        private TextBox uxDest;
        private TextBox uxSource;
        private Button uxDestButton;
        private Button uxSourceButton;
        private ProgressBar uxProgressBar;
        private Button uxCopyButton;
        private FolderBrowserDialog uxSourceBrowser;
        private FolderBrowserDialog uxDestBrowser;
    }
}

