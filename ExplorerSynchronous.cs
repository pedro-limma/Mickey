using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mickey
{
    public class ExplorerSynchronous
    {
        public static bool IsMatch { get; private set; }
        private readonly File _file;
        public string Path { get; private set; }

        public ExplorerSynchronous(File file, string path)
        {
            _file = file;
            Path = path;
        }

        public void MatchFile()
        {
            var directory = new DirectoryInfo($@"{Path}");

            if (!directory.Exists)
                throw new DirectoryNotFoundException("The directory does not exist.");

            ScanDirectories(Path);
            
        }

        private void ScanDirectories(string path)
        {
            if (IsMatch) return;
            try
            {
                VerifyFile(path);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (!IsMatch)
            {
                try
                {
                    string[] directories = Directory.GetDirectories(path);

                    foreach(string directory in directories)
                    {
                        ScanDirectories(directory);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void VerifyFile(string path)
        {
            string[] Files = Directory.GetFiles(path);

            foreach (string File in Files)
            {
                if (IsMatch) return;

                FileInfo info = new FileInfo(File);

                IsEquals(info);
            }
        }

        private void IsEquals(FileInfo fileInfo)
        {
            if ((fileInfo.Name == _file.Name && _file.Size == fileInfo.Length))
                Console.WriteLine($"Arquivo encontrado em {fileInfo.FullName}");
        }
    }
}
