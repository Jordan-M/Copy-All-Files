using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopier
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public void Increment()
        {
            progress.Value++;
            progressLabel.Text = String.Format("{0}/{1}", progress.Value, progress.Maximum);
        }

        public void Reset(int max)
        {
            progress.Value = 0;
            progress.Maximum = max;
            progressLabel.Text = String.Format("0/{0}", progress.Maximum);
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // We don't want to stop windows from trying to close down
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            DialogResult result = MessageBox.Show("An operation is currently in progress, are you sure you would like to quit?", "Confirm exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                e.Cancel = true;
            else
                return;
            
        }
    }
}
