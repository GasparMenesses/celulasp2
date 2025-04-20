using System;
using System.IO;

namespace Program
{
    
// Clase 2: Convierte ese contenido en una matriz booleana
    public class Board
    {
        public static bool[,] ImportFromLines(string[] lines)
        {
            bool[,] board = new bool[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j] == '1')
                    {
                        board[i, j] = true;
                    }
                }
            }
            
            return board;
        }
    }
}
 

