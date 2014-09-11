using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;
using System.IO;
using LibDblFin;

delegate void workerAnalyzerDelegate(string path);

public delegate void populateLabelsDelegate(DblFinFinder.progressArguments pa);

namespace DblFin
{
    public partial class MainForm : Form
    {
        //  Declare the DoubleFinder, which will carry every research and treatment
        DblFinFinder dff = new DblFinFinder();
        

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
            using (DblFinFinder dff = new DblFinFinder())
            {

                dff.ReportProgress += new EventHandler<DblFinFinder.progressArguments>(DblFinFinder_ReportProgress);

                dff.analyze(tb_path.Text.ToString());
            }

            MessageBox.Show("FINISHED !");
            
        }

        protected void DblFinFinder_ReportProgress(object sender, DblFinFinder.progressArguments e)
        {
            this.Invoke(new populateLabelsDelegate(populateLabels), new object[] { e });
        }

        void populateLabels(DblFinFinder.progressArguments e)
        {
            lbl_status.Text = e.status;
            lbl_numberOfFile.Text = e.scannedFile.ToString();
            lbl_numberOfFolder.Text = e.scannedFolder.ToString();

            lbl_doubles.Text = e.possibleDoubles.ToString();

            if (e.percentageSizeScanned > 0)
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Value = e.percentageSizeScanned;
            }

        }

        #endregion
    }
}
