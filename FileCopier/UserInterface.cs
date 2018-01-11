using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopier
{
    public partial class UserInterface : Form
    {
        private bool _operationInProgress = false;
        public UserInterface()
        {
            InitializeComponent();
        }

        private void uxSourceButton_Click(object sender, EventArgs e)
        {
            if (uxSourceBrowser.ShowDialog() == DialogResult.OK)
            {
                uxSource.Text = uxSourceBrowser.SelectedPath;
            }
        }

        private void uxDestButton_Click(object sender, EventArgs e)
        {
            if (uxDestBrowser.ShowDialog() == DialogResult.OK)
            {
                uxDest.Text = uxDestBrowser.SelectedPath;
            }
        }

        private void UserInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            // We don't want to stop windows from trying to close down
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (_operationInProgress)
            {
                DialogResult result = MessageBox.Show("An operation is currently in progress, are you sure you would like to quit?", "Confirm exit", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    e.Cancel = true;
                else
                    return;
            }
        }


        /// <summary>
        /// Toggles all the UI buttons, and resets the progress bar
        /// </summary>
        private void ResetUI()
        {
            ToggleUIButtons();
            ResetProgress();
        }

        /// <summary>
        /// Resets the progress bar to its idle state
        /// </summary>
        private void ResetProgress()
        {
            uxProgressBar.Value = 0;
            uxProgressBar.Maximum = CalculateNumFiles(uxSource.Text, true);
            uxProgressLabel.Text = "0/" + uxProgressBar.Maximum;
        }

        /// <summary>
        /// </summary>
        /// <param name="location"></param>
        /// <param name="searchSubfolders"></param>
        /// <returns></returns>
        public static int CalculateNumFiles(string location, bool searchSubfolders)
        {
            SearchOption option = (searchSubfolders) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return Directory.GetFiles(location, "*.*", option).Length;
        }

        /// <summary>
        /// Sets all buttons to the opposite enabled status
        /// </summary>
        private void ToggleUIButtons()
        {
            uxSourceButton.Enabled = !uxSourceButton.Enabled;
            uxDestButton.Enabled = !uxDestButton.Enabled;
            uxCopyButton.Enabled = !uxCopyButton.Enabled;
        }


        private void RemoveEmptyFolders(string root)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                RemoveEmptyFolders(directory);
                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }

        private async Task<bool> MoveFolder(DirectoryInfo root, string savePath)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.pdf");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (files != null)
            {
                if (files.Count() > 0)
                {

                    foreach (FileInfo file in files)
                    {
                        try
                        { 
                              File.Move(file.FullName, Path.Combine(savePath, file.Name));
                        }
                        catch (IOException)
                        {
                            DirectoryInfo dir = new DirectoryInfo(savePath);
                            FileInfo[] saveFiles = dir.GetFiles(file.Name + "*");

                            string fileNameWithoutExt = StripExt(file.Name);

                            int fileCount = CheckFilesWithName(file.Name, savePath);

                            string newSavePath = Path.Combine(savePath, String.Format("{0}({1}).pdf", fileNameWithoutExt, fileCount));
                            File.Move(file.FullName, newSavePath);
                        }
                        
                        if (InvokeRequired)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                uxProgressBar.Value++;
                                uxProgressLabel.Text = uxProgressBar.Value + "/" + uxProgressBar.Maximum;
                            }));
                        }
                    }
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    await MoveFolder(dirInfo, savePath);
                }
            }

            return true;
        }


        private string StripExt(string file)
        {
            return file.Substring(0, file.LastIndexOf('.'));
        }

        private int CheckFilesWithName(string name, string path)
        {
            return Directory.GetFiles(path, "*" + StripExt(name) + "*").Count();
            
        }

        private async void uxCopyButton_ClickAsync(object sender, EventArgs e)
        {
            if (uxSource.Text != String.Empty && uxDest.Text != String.Empty)
            {
                ResetUI();
                _operationInProgress = true;

                DirectoryInfo dir = new DirectoryInfo(uxSource.Text);
                Task<bool> test = await Task.Factory.StartNew(() => MoveFolder(dir, uxDest.Text));

                RemoveEmptyFolders(uxSource.Text);
                MessageBox.Show("Finished dumping files!");

                _operationInProgress = false;
                ResetUI();
            }
        }
    }
}
