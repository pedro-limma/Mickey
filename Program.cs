using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Mickey
{
    public class Program
    {
        private static Stopwatch _stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            try
            {
                File file = CreateNewFile();

                Console.WriteLine("Insira um Diretório base para busca: ");
                string path = Console.ReadLine();

                //Explorer explorer = new Explorer(file, path);
                ExplorerSynchronous explorerSynchronous = new ExplorerSynchronous(file, path);

                _stopwatch.Start();
                explorerSynchronous.MatchFile();
                _stopwatch.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Elapsed time: {0:hh\\:mm\\:ss\\.fff}", _stopwatch.Elapsed);
            Console.ReadLine();
        }


        /// <summary>
        /// Método para criação de parâmetros de busca
        /// </summary>
        /// <returns></returns>
        static File CreateNewFile()
        {
            Console.Write("Name(algumaCoisa.txt): ");
            string name = Console.ReadLine();


            Console.Write("File size (em Bytes): ");
            string fileSize = Console.ReadLine();

            return new File(name, double.Parse(fileSize));
        }

    }
}
