using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LibDblFin
{

    public class DblFinFinder : IDisposable
    {
        // Event used to report progress
        public EventHandler<progressArguments> ReportProgress;

        //  List used to store file and folders
        private List<string> dirList = new List<string>();
        private List<string> fileList = new List<string>();
        private List<FileInfo> fileInfos = new List<FileInfo>();
        private List<FileInfo> matchedSizes = new List<FileInfo>();

        //  Progress class, to group status
        public class progressArguments : EventArgs
        {
            public double scannedFolder {get; set;}
            public double scannedFile { get; set; }
            public int percentageSizeScanned { get; set; }
            public int possibleDoubles { get; set; }
            public string status {get; set;}

            //  Constructor
            public progressArguments(double scannedFold, double scannedFiles, int percentSizeAnalysis, int possibleDoubles, string strStatus)
            {
                this.scannedFolder = scannedFold;
                this.scannedFile = scannedFiles;
                this.percentageSizeScanned = percentSizeAnalysis;
                this.status = strStatus;
                this.possibleDoubles = possibleDoubles;
            }

        }

        public DblFinFinder()
        {

        }

        public void Dispose()
        {

        }

        //  Used to list every folder and store it in a list
        public void scanDir (string path)
        {

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

                    //  If someone is listening for progress report, send it
                    if (ReportProgress != null)
                    {
                        ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), 0, 0, "Scanning Folder..."));
                    }
                }

                catch(UnauthorizedAccessException)
                {
                    
                }

            }
        }

        //  Used to scan every directory and store every file in a list
        public void scanFile()
        {

            int count = 1;

            foreach(string s in dirList)
            {
                try
                {
                    string[] tmpFile = Directory.GetFiles(s);
                    fileList.AddRange(tmpFile);
                    int completed = Convert.ToInt32(((double)count / (double)this.dirList.Count()) * 100);

                    if (ReportProgress != null)
                    {
                        ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), completed, 0, "Scanning File..."));
                    }

                    count++;
                }

                catch (UnauthorizedAccessException)
                {

                }
            }
        }

        public void readFiles()
        {
            int count = 1;
            foreach (string s in fileList)
            {
                int completed = Convert.ToInt32(((double)count / (double)this.fileList.Count()) * 100);

                fileInfos.Add(new FileInfo(s));

                if (ReportProgress != null)
                {
                    ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), completed, 0, "Reading File..."));
                }

                count++;
            }
        }

        public void compareSize()
        {
            ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), 0, matchedSizes.Count(), "Pre-analysis of files to determine possible doubles..."));
            
            //  I will have to optimize this part, doubles are analyzed multiple times, because for each element I check the whole array, not only the onw we didn't check.
            //  Maybe by using stack...

            int count = 1;
            int completed = Convert.ToInt32(((double)count / (double)this.fileList.Count()) * 100);

            List<int> doublesIndex = new List<int>();

            for (int i = fileInfos.Count() - 1; i >= 0; i--)
            {
                bool firstAdd = true;

                for(int j = i-1; j >= 0; j--)
                {
                    if(fileInfos[i].Length == fileInfos[j].Length)
                    {
                        if(firstAdd == true)
                        {
                            if (!doublesIndex.Contains(i))
                            {
                                this.matchedSizes.Add(fileInfos[i]);
                                firstAdd = false;
                                doublesIndex.Add(i);
                            }
                        }

                        if(!doublesIndex.Contains(j))
                        {
                            this.matchedSizes.Add(fileInfos[j]);
                            doublesIndex.Add(j);
                        }
                    }
                }

                ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), completed, this.matchedSizes.Count(), "Pre-analysis of files to determine possible doubles..."));
                count++;
            }

            using (StreamWriter sw = new StreamWriter("log.txt"))
            {

                for(int i = 0; i <= matchedSizes.Count()-1;i++)
                {
                    sw.WriteLine(i + "\t\t" + doublesIndex[i].ToString() + "\t\t\t\t" + matchedSizes[i].Name + "\t\t\t\t" + matchedSizes[i].Length);
                }

            }

        }

        public void analyze(string file)
        {
            if(Directory.Exists(file))
            {
                dirList.Add(file);
            }
            scanDir(file);
            scanFile();
            readFiles();
            compareSize();

            if (ReportProgress != null)
            {
                ReportProgress(this, new progressArguments(this.dirList.Count(), this.fileList.Count(), 100, matchedSizes.Count(), "DONE !"));
            }
        }

        public List<FileInfo> getMatchedList()
        {
            return this.matchedSizes;
        }
    }
}
