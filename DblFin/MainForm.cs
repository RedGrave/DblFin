using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using LibDblFin;

delegate void workerAnalyzerDelegate(string path);

public delegate void populateLabelsDelegate(int folderCount, int fileCount, int percentListed, int percentAnalyzed, string status);

namespace DblFin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if(Directory.Exists(folderBrowserDialog1.SelectedPath.ToString()))
            {
                tb_path.Text = folderBrowserDialog1.SelectedPath.ToString();
            }

        }

        private void btn_analyzer_Click(object sender, EventArgs e)
        {
            analyze(tb_path.Text.ToString());
        }

        private void analyze(string path)
        {
            DblFinFinder finder = new DblFinFinder();

            workerAnalyzerDelegate w1 = workerAnalyzer;
            w1.BeginInvoke(path, null, null);

        }

        #region backgroundworkers


        public void workerAnalyzer(string path)
        {
            DblFinFinder dff = new DblFinFinder();
            
        }

        protected void DblFinFinder_ReportProgress(object sender, DblFinFinder.progressArguments e)
        {
            lbl_numberOfFile.Text = e.scannedFile.ToString();
            lbl_numberOfFolder.Text = e.scannedFolder.ToString();
            lbl_status.Text = e.status;
        }

        void populateNumberOfFolder(string number)
        {
            lbl_numberOfFolder.Text = number;
        }

        #endregion
    }
}
