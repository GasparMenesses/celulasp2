using System;

namespace Program
{
    public class Board
    {
        private static bool[,] board;

        public static void CreateBoard(int length, int width)
        {
            board = new bool[length, width]; //Creo una matriz de las dimensiones del archivo .txt con valores booleanos en false por defecto
        }

        public static void ChangeStatus(int x, int y, bool state)
        {
            board[x, y] = state;
            foreach (var a in board)
            {
                Console.WriteLine(a);
            }

            
        }

        public static bool[,] Send2Print()
        {
            return board;
        }
    }   
}

