using System;
using System.IO;
using System.Text;

namespace Mickey
{
    public class File
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int FileSize { get; set; }
        public string Content { get; set; }

        public string GetFileName()
        {
            return $"{Name}.{Type}";
        }

        public override bool Equals(Object obj)
        {
            File fl = obj as File;
            if (fl == null)
                return false;
            
            return Name == fl.Name && 
                   Date == fl.Date && 
                   FileSize == fl.FileSize && 
                   Content == fl.Content &&
                   GetFileName() == fl.GetFileName();
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\n" +
                $"Type: {Type}\n" +
                $"Date: {Date.ToString("G")}\n" +
                $"File Size:{FileSize}\n" +
                $"Content: {Content}\n";
        }

        public void GetContent(string path)
        {
            using (FileStream stream = System.IO.File.OpenRead(path))
            {
                byte[] buffer = new byte[1024];
                UTF8Encoding reader = new UTF8Encoding(true);

                while (stream.Read(buffer, 0, buffer.Length) > 0)
                {
                    Console.WriteLine(reader.GetString(buffer));
                }
            }
        }
    }
}
