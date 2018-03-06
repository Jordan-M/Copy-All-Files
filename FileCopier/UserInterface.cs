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
        private ProgressForm progress = new ProgressForm();
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
            progress.Reset(FolderOperations.CalculateNumFiles(uxSource.Text, true));
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

        private async Task<bool> MoveFolder(DirectoryInfo root, string savePath)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (files != null && files.Count() > 0)
            {
                foreach (FileInfo file in files)
                {
                    MoveFile(file, savePath);

                    if (InvokeRequired)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            progress.Increment();
                        }));
                    }
                }
            }

            subDirs = root.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirs)
            {
                await MoveFolder(dirInfo, savePath);
            }

            return true;
        }

        private void MoveFile(FileInfo file, string destination)
        {
            File.Move(file.FullName, CreateUniqueFileName(file, destination));
        }

        private string CreateUniqueFileName(FileInfo file, string destination)
        {
            string savePath = Path.Combine(destination, file.Name);

            int fileCount = 0;
            string fileExt = "";
            string fileNameWithoutExt = "";

            if (File.Exists(savePath))
            {
                DirectoryInfo dir = new DirectoryInfo(destination);
                FileInfo[] saveFiles = dir.GetFiles(file.Name + "*");

                fileNameWithoutExt = FilePathDeconstructor.PathWithoutExt(file.Name);
                fileExt = FilePathDeconstructor.GetExt(file.Name);
                fileCount = FolderOperations.CheckFilesWithName(file.Name, destination);

                savePath = Path.Combine(destination, String.Format("{0}({1}).{2}", fileNameWithoutExt, fileCount, fileExt));
            }

            while (File.Exists(savePath))
            {
                fileCount++;
                savePath = Path.Combine(destination, String.Format("{0}({1}).{2}", fileNameWithoutExt, fileCount, fileExt));
            }

            return savePath;
        }

        private async void uxCopyButton_ClickAsync(object sender, EventArgs e)
        {
            if (uxSource.Text != String.Empty && uxDest.Text != String.Empty)
            {
                ResetUI();
                _operationInProgress = true;

                progress.Show();

                DirectoryInfo dir = new DirectoryInfo(uxSource.Text);
                Task<bool> test = await Task.Factory.StartNew(() => MoveFolder(dir, uxDest.Text));

                FolderOperations.RemoveEmptyFolders(uxSource.Text);
                MessageBox.Show("Finished dumping files!");

                _operationInProgress = false;
                progress.Hide();

                ResetUI();
            }
        }
    }
}
