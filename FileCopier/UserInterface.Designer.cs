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
            this.uxDest = new System.Windows.Forms.TextBox();
            this.uxSource = new System.Windows.Forms.TextBox();
            this.uxDestButton = new System.Windows.Forms.Button();
            this.uxSourceButton = new System.Windows.Forms.Button();
            this.uxCopyButton = new System.Windows.Forms.Button();
            this.uxSourceBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.uxDestBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.uxSourceLabel = new System.Windows.Forms.Label();
            this.uxDestLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxDest
            // 
            this.uxDest.Location = new System.Drawing.Point(67, 44);
            this.uxDest.Name = "uxDest";
            this.uxDest.ReadOnly = true;
            this.uxDest.Size = new System.Drawing.Size(220, 20);
            this.uxDest.TabIndex = 13;
            // 
            // uxSource
            // 
            this.uxSource.Location = new System.Drawing.Point(67, 12);
            this.uxSource.Name = "uxSource";
            this.uxSource.ReadOnly = true;
            this.uxSource.Size = new System.Drawing.Size(220, 20);
            this.uxSource.TabIndex = 12;
            // 
            // uxDestButton
            // 
            this.uxDestButton.Location = new System.Drawing.Point(293, 41);
            this.uxDestButton.Name = "uxDestButton";
            this.uxDestButton.Size = new System.Drawing.Size(32, 23);
            this.uxDestButton.TabIndex = 11;
            this.uxDestButton.Text = "...";
            this.uxDestButton.UseVisualStyleBackColor = true;
            this.uxDestButton.Click += new System.EventHandler(this.uxDestButton_Click);
            // 
            // uxSourceButton
            // 
            this.uxSourceButton.Location = new System.Drawing.Point(293, 10);
            this.uxSourceButton.Name = "uxSourceButton";
            this.uxSourceButton.Size = new System.Drawing.Size(32, 23);
            this.uxSourceButton.TabIndex = 10;
            this.uxSourceButton.Text = "...";
            this.uxSourceButton.UseVisualStyleBackColor = true;
            this.uxSourceButton.Click += new System.EventHandler(this.uxSourceButton_Click);
            // 
            // uxCopyButton
            // 
            this.uxCopyButton.Location = new System.Drawing.Point(12, 70);
            this.uxCopyButton.Name = "uxCopyButton";
            this.uxCopyButton.Size = new System.Drawing.Size(313, 23);
            this.uxCopyButton.TabIndex = 8;
            this.uxCopyButton.Text = "Copy";
            this.uxCopyButton.UseVisualStyleBackColor = true;
            this.uxCopyButton.Click += new System.EventHandler(this.uxCopyButton_ClickAsync);
            // 
            // uxSourceLabel
            // 
            this.uxSourceLabel.AutoSize = true;
            this.uxSourceLabel.Location = new System.Drawing.Point(17, 12);
            this.uxSourceLabel.Name = "uxSourceLabel";
            this.uxSourceLabel.Size = new System.Drawing.Size(44, 13);
            this.uxSourceLabel.TabIndex = 15;
            this.uxSourceLabel.Text = "Source:";
            // 
            // uxDestLabel
            // 
            this.uxDestLabel.AutoSize = true;
            this.uxDestLabel.Location = new System.Drawing.Point(1, 47);
            this.uxDestLabel.Name = "uxDestLabel";
            this.uxDestLabel.Size = new System.Drawing.Size(63, 13);
            this.uxDestLabel.TabIndex = 16;
            this.uxDestLabel.Text = "Destination:";
            // 
            // UserInterface
            // 
            this.ClientSize = new System.Drawing.Size(337, 101);
            this.Controls.Add(this.uxDestLabel);
            this.Controls.Add(this.uxSourceLabel);
            this.Controls.Add(this.uxDest);
            this.Controls.Add(this.uxSource);
            this.Controls.Add(this.uxDestButton);
            this.Controls.Add(this.uxSourceButton);
            this.Controls.Add(this.uxCopyButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(353, 140);
            this.MinimumSize = new System.Drawing.Size(353, 140);
            this.Name = "UserInterface";
            this.Text = "Copy Files";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserInterface_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private TextBox uxDest;
        private TextBox uxSource;
        private Button uxDestButton;
        private Button uxSourceButton;
        private Button uxCopyButton;
        private FolderBrowserDialog uxSourceBrowser;
        private FolderBrowserDialog uxDestBrowser;
        private Label uxSourceLabel;
        private Label uxDestLabel;
    }
}

