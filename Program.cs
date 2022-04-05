using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Mickey
{
    public class Program
    {
        public static List<FileInfo> ListFileInfo = new List<FileInfo>();
        private static Stopwatch _stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            try
            {
                File file = CreateNewFile();

                Console.WriteLine("Insira um Diretório base para busca: ");
                string path = Console.ReadLine();

                Explorer explorer = new Explorer(file, path, ListFileInfo);

                _stopwatch.Start();
                explorer.MatchFile();
                _stopwatch.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("-------------RESULT-------------");
            if (ListFileInfo.Count > 0)
                ListFileInfo.ForEach(file => Console.WriteLine($"File: {file.Name} Found in {file.FullName}"));
            else
                Console.WriteLine("A file was not found that contains the specified parameters.");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Elapsed time: {0:hh\\:mm\\:ss\\.fff}", _stopwatch.Elapsed);
            Console.ReadLine();
        }


        /// <summary>
        /// Método para criação de parâmetros de busca
        /// </summary>
        /// <returns></returns>
        static File CreateNewFile()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Type (txt, cs, js, ts): ");
            string type = Console.ReadLine();

            Console.Write("File size (em Bytes): ");
            string fileSize = Console.ReadLine();

            return new File(name, type, double.Parse(fileSize));
        }

    }
}
