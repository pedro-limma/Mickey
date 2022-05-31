using System;
using System.IO;
using System.Threading.Tasks;

namespace Mickey
{
    /// <summary>
    /// Minha Classe Explorer responsável por guardar os 
    /// métodos de acesso varredura dos arquivos e diretórios 
    /// utilizando paralelismo
    /// </summary>
    public class Explorer
    {

        public static bool IsMatch { get; private set; }
        private readonly File _file;
        public string Path { get; private set; }

        /// <summary>
        /// Construtor para fazer a atribuição de valores para nossas propriedades, "File" e "Path"
        /// </summary>
        /// <param name="file">Dados do arquivo a ser buscado</param>
        /// <param name="path">Caminho base de busca</param>
        public Explorer(File file, string path)
        {
            _file = file;
            Path = path;
        }


        /// <summary>
        /// Esta função vai fazer a invoke da nosso método "ScanDirectories" de forma paralela.
        /// </summary>
        public void MatchFile()
        {
            try
            {
                Parallel.Invoke(() => ScanDirectories(Path));
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Função responsavél por verificar se o arquivo foi encontrado, 
        /// utilizando recursão para que cada próximo diretório seja executado
        /// em uma thread disponíl de form a paralela
        /// </summary>
        /// <param name="path">Caminho base para busca</param>
        private void ScanDirectories(string path)
        {
            if (IsMatch) return;
            try
            {
                VerifyFile(path);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (!IsMatch)
            {

                try
                {
                    string[] directories = Directory.GetDirectories(path);
                    Parallel.ForEach(directories, d => ScanDirectories(d));
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        /// <summary>
        /// Este método vai fazer a varredura nos arquivos de determinado
        /// diretório verificando cada parâmetroem comum e adicionando na
        /// lista de arquivos que deram MATCH
        /// </summary>
        /// <param name="path">Diretório da base</param>
        private void VerifyFile(string path)
        {
            string[] Files = Directory.GetFiles(path);

            foreach (string File in Files)
            {
                if (IsMatch) return;

                FileInfo info = new FileInfo(File);

                IsEquals(info);
            }
        }

        /// <summary>
        /// Método que vai fazer a comparação dos parâmetros de busca informados e 
        /// vai inserir na lista de arquivos encontrados
        /// </summary>
        /// <param name="fileInfo"></param>
        private void IsEquals(FileInfo fileInfo)
        {
            if ((fileInfo.Name == _file.Name && _file.Size == fileInfo.Length))
                Console.WriteLine($"Arquivo encontrado em {fileInfo.FullName}");
        }

    }
}
