using System;

namespace Mickey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = new File()
            {
                Type = "txt",
                Name = "algumarquivo",
                Date = DateTime.Now,
                FileSize = 123,
                Word = "coisa",
                Phrase = "alguma coisa",
            };

            Console.WriteLine(file.ToString());
            Console.ReadLine();
        }
    }
}
