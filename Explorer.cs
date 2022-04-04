using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Mickey
{
    public class Explorer
    {
        private readonly File _file;
        public string Path { get; private set; }
        public static bool IsMatch { get; private set; }

        private static readonly Stopwatch _stopwatch = new Stopwatch();

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

            try
            {
                Parallel.Invoke(() => ScanDirectories(Path));
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ScanDirectories(string path)
        {
            _stopwatch.Start();
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
                string[] directories = Directory.GetDirectories(path);

                try
                {
                    Parallel.ForEach(directories, d => ScanDirectories(d));
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

                if (Equals(info))
                {
                    Console.WriteLine($"MATCH, Arquivo encontrado! {info.FullName}");
                    IsMatch = true;

                    _stopwatch.Stop();
                    Console.WriteLine("Tempo decorrido: {0:hh\\:mm\\:ss}", _stopwatch.Elapsed);

                    break;
                }
            }
        }

        private bool Equals(FileInfo fileInfo)
        {
            bool contentInFile = _file.GetContent(fileInfo.FullName);

            if (_file.FileName == fileInfo.Name &&
                _file.Date.ToString("G") == fileInfo.CreationTime.ToString("G") &&
                _file.FileSize == fileInfo.Length &&
                contentInFile)
                return true;

            return false;
        }
    }


}
