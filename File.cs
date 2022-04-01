using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mickey
{
    public class File
    {
        public string? Type { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public int? FileSize { get; set; }
        public string? Word { get; set; }
        public string? Phrase { get; set; }

        public override string ToString()
        {
            return 
                $"Name: {this.Name ?? ""}\n" +
                $"Type: {this.Type ?? ""}\n" +
                $"Date: {this.Date?.ToString("G") ?? ""}\n" +
                $"File Size:{this.FileSize ?? null}\n" +
                $"Word: {this.Word??""}\n" +
                $"Phrase: {this.Phrase??""}\n";
        }

    }
}
