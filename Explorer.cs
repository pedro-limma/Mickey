using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Mickey
{
    public class Explorer
    {
        private readonly File _file;
        public string Path { get; private set; }

        public Explorer(File file, string path)
        {
            _file = file;
            Path = path;
        }

        public void MatchFile()
        {
            DirectoryInfo directory = new DirectoryInfo($@"{Path}");

            if (!directory.Exists)
                throw new DirectoryNotFoundException("The directory does not exist.");

            FileSystemInfo[] infos = directory.GetFileSystemInfos();

            VerifyFiles(infos);
        }

        private void VerifyFiles(FileSystemInfo[] fsInfo)
        {
            foreach (FileSystemInfo info in fsInfo)
            {
                if (info is DirectoryInfo)
                {
                    /*Inserção das threads para adentrar nos arquivos desta pasta */
                    Console.WriteLine(info.Name);

                    //DirectoryInfo directoryInfo = info as DirectoryInfo;

                    //Task.Factory.StartNew(() => VerifyFiles(directoryInfo.GetFileSystemInfos()));
                    
                }
                else if (info is FileInfo)
                {
                    /*Inserção de Match*/
                    if (_file.GetFileName() == info.Name)
                    {
                        Console.WriteLine("MATCH");
                        break;
                    }
                }
            }
        }
    }
}
