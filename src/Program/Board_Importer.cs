// Carga el board desde un archivo .txt

namespace Program
{
    using System.IO;
    public class BoardImporter
    {
        public static bool[,] ImportFromFile(string url)
        {
            string[] content = File.ReadAllText(url).Split('\n');
            bool[,] board = new bool[content.Length, content[0].Length];
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (content[i][j] == '1')
                    {
                        board[i, j] = true;
                    }
                }
            }

            return board;
        }
    }
}
