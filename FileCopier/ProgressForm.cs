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
    }
}
