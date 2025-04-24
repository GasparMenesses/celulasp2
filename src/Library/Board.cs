using System;

namespace Library
{
    public class Board
    {
        private static bool[,] board;
        private static bool[,] previousBoard;

        public static void CreateBoard(int length, int width)
        {
            board = new bool[length, width]; //Creo una matriz de las dimensiones del archivo .txt con valores booleanos en false por defecto
        }

        public static bool IsAlive(int x, int y, int previous = 0)
        {
            if (previous == 1)
            {
                return previousBoard[x, y];
            }
            else
            {
                return board[x, y];
            }
        }

        public static void ChangeStatus(int x, int y, bool state)
        {
            board[x, y] = state;
        }

        public static void PreviousBoard()
        {
            int rows = Board.GetLength0();
            int cols = Board.GetLength1();
            previousBoard = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    previousBoard[i, j] = board[i, j];
                }
            }
        }

        public static bool[,] CreatedBoard()
        {
            return board;
        }

        public static int GetLength0()
        {
            return board.GetLength(0);
        }
        
        public static int GetLength1()
        {
            return board.GetLength(1);
        }
    }   
}

