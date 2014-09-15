using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DblFin
{
    public partial class report : Form
    {
        List<FileInfo> data = new List<FileInfo>();

        public report(List<FileInfo> d)
        {
            InitializeComponent();
            this.data = d;
            generateReport();
        }

        public void generateReport()
        {

            string page = null;

            page = page + "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><title>report</title><></head><body><h1>report</h1>";

            foreach(FileInfo f in data)
            {
                page = page + "<p>" + f.FullName + "</p>\n";
            }
            
            page = page + @"</body></html>";

            webBrowser1.Document.Write(page);
        }
    }
}
