using System;

namespace Mickey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File file = CreateNewFile();
                
                Console.WriteLine("Insira um Diretório base para busca: ");
                var path = Console.ReadLine();

                Explorer explorer = new Explorer(file, path);

                explorer.MatchFile();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        static File CreateNewFile()
        {
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Type: ");
            var type = Console.ReadLine();

            Console.Write("Date: ");
            var date = Console.ReadLine();

            Console.Write("File size: ");
            var fileSize = Console.ReadLine();

            Console.Write("Content (phrase or word in file): ");
            var content = Console.ReadLine();

            return new File()
            {
                Type = type,
                Name = name,
                Date = DateTime.Parse(date),
                FileSize = int.Parse(fileSize),
                Content = content
            };
        }

        /*
            Nome: encontroukrl
'           Type: txt
'           Date: 01/04/2022 20:34
'           File size: 1
'           Content (phrase or word in file): jlaskdjfkljsklgjlfsdjgkldfjlkgjsdjflgjdlfjglkdsjgljsdk
         */
    }
}
