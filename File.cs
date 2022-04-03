using System;
using System.IO;
using System.Text;

namespace Mickey
{
    public class File
    {
        public string FileName { get; private set; }
        public DateTime Date { get; private set; }
        public double FileSize { get; private set; }
        public string Content { get; private set; }

        public File(string name, string extension, DateTime date, double fileSize, string content)
        {
            FileName = $"{name}.{extension}";
            Date = date;
            FileSize = fileSize;
            Content = content;
        }

        public bool GetContent(string path)
        {
            try
            {
                using (FileStream stream = System.IO.File.OpenRead(path))
                {
                    byte[] buffer = new byte[1024];
                    UTF8Encoding reader = new UTF8Encoding(true);

                    while (stream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        if (reader.GetString(buffer).Contains(Content))
                            return true;
                    }
                    return false;
                }
            }
            catch (IOException ex)
            {
                return false;
            }
        }
    }
}
