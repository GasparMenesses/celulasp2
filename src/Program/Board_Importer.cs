// Carga el board desde un archivo .txt

namespace Program
{
    using System.IO;
    public class BoardImporter
    {
        public static bool[,] ImportFromFile(string url)//url es la direccion del archivo .txt
        {
            string[] content = File.ReadAllText(url).Split('\n');
            bool[,] board = new bool[content.Length, content[0].Length];//Creo una matriz de las dimensiones del archivo .txt con valores booleanos en false por defecto
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (content[i][j] == '1')
                    {
                        board[i, j] = true;//Se vuelve true cuando la celula esta viva, es decir, cuando en el archivo es 1
                    }
                }
            }

            return board;
        }
    }
}
