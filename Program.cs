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
                string path = Console.ReadLine();

                Explorer explorer = new Explorer(file, path);

                explorer.MatchFile();

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
            string name = Console.ReadLine();

            Console.Write("Type (txt, cs, js, ts): ");
            string type = Console.ReadLine();

            Console.Write("Date (dd/MM/yyyy hh:mm:ss): ");
            string date = Console.ReadLine();

            Console.Write("File size (em Bytes): ");
            string fileSize = Console.ReadLine();

            Console.Write("Content (phrase or word in file): ");
            string content = Console.ReadLine();

            return new File(name, type, DateTime.Parse(date), double.Parse(fileSize), content);
            //return new File("encontroukrl", "txt", DateTime.Parse("01/04/2022 20:14:32"), 970 , "jlaskdjfkljsklgjlfsdjgkldfjlkgjsdjflgjdlfjglkdsjgljsdk");
        }

    }
}
