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

delegate void workerFolderListerDelegate(string path);
delegate void workerFileListerDelegate(string path);

public delegate void populateNumberOfFolderDelegate(string number);
delegate void populateNumberOfFileDelegate(string number);
delegate void populatePercentageDelegate(string number);

delegate void updateLabel(string labelname, string status);

namespace DblFin
{
    public partial class Form1 : Form
    {
        public Form1()
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

            workerFolderListerDelegate w1 = workerFolderLister;
            w1.BeginInvoke(path, null, null);

        }

        #region backgroundworkers


        public void workerFolderLister(string path)
        {
            
            /*
            DblFinFinder finder = new DblFinFinder();
            finder.scanDir(path);

            string temp = finder.getNumberOfFolder().ToString();

            this.Invoke(new populateNumberOfFolderDelegate(populateNumberOfFolder), new object[] { temp });

            finder.scanFile();*/
        }

        protected void DblFinFinder_ReportProgress(object sender, DblFinFinder.progressArguments e)
        {

        }

        void populateNumberOfFolder(string number)
        {
            lbl_numberOfFolder.Text = number;
        }

        #endregion
    }
}
