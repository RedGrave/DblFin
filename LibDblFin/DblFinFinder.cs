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
        // Event used to report progress
        public EventHandler<progressArguments> ReportProgress;

        //  List used to store file and folders
        private List<string> dirList = new List<string>();
        private List<string> fileList = new List<string>();

        //  Progress class, to group status
        public class progressArguments : EventArgs
        {
            public double scannedFolder {get; set;}
            public double scannedFile { get; set; }
            public int percentageSizeScanned { get; set; }
            public int percentageMD5Scanned { get; set; }
            public string status {get; set;}

            //  Constructor
            public progressArguments(double scannedFold, double scannedFiles, int percentSizeAnalysis, int percentMD5hash, string strStatus)
            {
                this.scannedFolder = scannedFold;
                this.scannedFile = scannedFiles;
                this.percentageSizeScanned = percentSizeAnalysis;
                this.percentageMD5Scanned = percentMD5hash;
                this.status = strStatus;
            }
        }

        public DblFinFinder()
        {

        }

        //  Used to list every folder and store it in a list
        public void scanDir (string path)
        {
            //  Clear dirList
            this.dirList.Clear();

            if(Directory.Exists(path))
            {

                try
                {
                    //  If someone is listening for progress report, send it
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

        //  Used to scan every directory and store every file in a list
        public void scanFile()
        {
            this.fileList.Clear();

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

        //  I don't kn0w if i'll keep this code... seems useless now
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
