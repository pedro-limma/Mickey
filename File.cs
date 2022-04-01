using System;

namespace Mickey
{
    public class File
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? FileSize { get; set; }
        public string? Word { get; set; }
        public string? Phrase { get; set; }

        public string GetFileName()
        {
            return $"{Name}.{Type}";
        }
        

        public override string ToString()
        {
            return 
                $"Name: {Name ?? ""}\n" +
                $"Type: {Type ?? ""}\n" +
                $"Date: {Date?.ToString("G") ?? ""}\n" +
                $"File Size:{FileSize ?? null}\n" +
                $"Word: {Word??""}\n" +
                $"Phrase: {Phrase??""}\n";
        }

    }
}
