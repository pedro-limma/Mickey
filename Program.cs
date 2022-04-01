using System;

namespace Mickey
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var file = new File()
            {
                Type = "h",
                Name = "abstract",
            };

            Console.WriteLine("Insira um Diretório base para busca: ");

            var path  = Console.ReadLine();

            var explorer = new Explorer(file, path);

            explorer.MatchFile();


            Console.ReadLine();
        }
    }
}
