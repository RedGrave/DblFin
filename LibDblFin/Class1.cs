using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LibDblFin
{

    public class DblFinFinder
    {
        public EventHandler<progressArguments> ReportProgress;

        public class progressArguments : EventArgs
        {
            public double scannedFolder {get; set;}
            public double scannedFile { get; set; }
            public int percentageSizeScanned { get; set; }
            public int percentageMD5Scanned { get; set; }
            public string status {get; set;}

            public progressArguments(double scannedFold, double scannedFiles, int percentSizeAnalysis, int percentMD5hash, string strStatus)
            {
                this.scannedFolder = scannedFold;
                this.scannedFile = scannedFiles;
                this.percentageSizeScanned = percentSizeAnalysis;
                this.percentageMD5Scanned = percentMD5hash;
                this.status = strStatus;
            }
        }

        private List<string> dirList = new List<string>();
        private List<string> fileList = new List<string>();

        public DblFinFinder()
        {

        }

        public void scanDir (string path)
        {
            if(Directory.Exists(path))
            {

                try
                {
                    if (ReportProgress != null)
                    {
                        ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), 0, 0, "Scanning Folder..."));
                    }

                    string[] tmpDir = Directory.GetDirectories(path);
                    dirList.AddRange(tmpDir);
                    foreach (string s in tmpDir)
                    {
                        scanDir(s);
                    }
                }

                catch(UnauthorizedAccessException)
                {
                    
                }
                if(ReportProgress != null)
                {
                    ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), 0, 0, "Folder Scanned"));
                }
            }
        }

        public void scanFile()
        {
            foreach(string s in dirList)
            {
                try
                {
                    string[] tmpFile = Directory.GetFiles(s);
                    fileList.AddRange(tmpFile);
                }

                catch (UnauthorizedAccessException)
                {

                }
            }
        }

        public double getNumberOfFolder()
        {
            return this.dirList.Count();
        }
        public double getNumberOfFile()
        {
            return this.fileList.Count();
        }
    }


}
