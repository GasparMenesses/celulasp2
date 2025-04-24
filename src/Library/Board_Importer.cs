// Carga el board desde un archivo .txt

namespace Library
{
    using System.IO;
    public class BoardImporter
    {
        public static void ImportFromFile(string url)//url es la direccion del archivo .txt
        {
            string[] content = File.ReadAllText(url).Replace("\r", "").Split('\n');//Se reemplaza \r ya que de no ser asi no todos tendran la misma cantidad de elementos
            Board.CreateBoard(content.Length, content[0].Length);
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (content[i][j] == '1')
                    {
                        Board.ChangeStatus(i, j, true );
                    }
                }
            }
        }
    }
}