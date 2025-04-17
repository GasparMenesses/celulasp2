namespace Program
{
    public class Motor
    {
        public static bool[,] GenerateNewGeneration(bool[,] board)
        {
            int boardRow = board.GetLength(0);
            int boardColumn = board.GetLength(1);
            bool[,] newBoard = new bool[boardRow, boardColumn];//Nuevo tablero en donde se generara la nueva generacion
            for (int x = 0; x < boardRow; x++)//Recorre las filas del board
            {
                for (int y = 0; y < boardColumn; y++)//Recorre las columnas de la fila actual
                {
                    int neighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardRow && j >= 0 && j < boardColumn && board[i, j])
                            {
                                neighbors++;
                            }
                        }
                    }
                    if (board[x, y])
                    {
                        //Al contar los vecinos se cuenta uno de mas, esto elimina ese que se conto de mas
                        neighbors--;
                    }

                    if (board[x, y] && neighbors < 2)
                    {
                        //Una célula viva con menos de 2 vecinos vivos muere, por soledad.
                        newBoard[x, y] = false;
                    }
                    else if (board[x, y] && neighbors > 3)
                    {
                        //Una célula viva con más de 3 vecinos vivos muere, por sobrepoblación.
                        newBoard[x, y] = false;
                    }
                    else if (!board[x, y] && neighbors == 3)
                    {
                        //Una célula muerta con exactamente 3 vecinos vivos se convierte en una célula viva, por
                        //reproducción.
                        newBoard[x, y] = true;
                    }
                    else
                    {
                        //Una célula viva con 2 o 3 vecinos vivos sobrevive a la siguiente generación.
                        //En caso de que no cumpla las reglas previas y este muerta se mantendra en su estado original
                        newBoard[x, y] = board[x, y];
                    }
                }
            }

            return newBoard;
        }
    }
}    
