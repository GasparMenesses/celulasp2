namespace Library
{
    public class Motor
    {
        public static void GenerateNewGeneration()
        {
            int boardRow = Board.GetLength0();
            int boardColumn = Board.GetLength1();
            Board.PreviousBoard();
            
            for (int x = 0; x < boardRow; x++)//Recorre las filas del board
            {
                for (int y = 0; y < boardColumn; y++)//Recorre las columnas de la fila actual
                {
                    int neighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardRow && j >= 0 && j < boardColumn && Board.IsAlive(i, j, 1))
                            {
                                neighbors++;
                            }
                        }
                    }
                    if (Board.IsAlive(x, y, 1))
                    {
                        //Al contar los vecinos se cuenta uno de mas, esto elimina ese que se conto de mas
                        neighbors--;
                    }

                    if (Board.IsAlive(x, y, 1) && neighbors < 2)
                    {
                        //Una célula viva con menos de 2 vecinos vivos muere, por soledad.
                        Board.ChangeStatus(x, y, false);
                    }
                    else if (Board.IsAlive(x, y, 1) && neighbors > 3)
                    {
                        //Una célula viva con más de 3 vecinos vivos muere, por sobrepoblación.
                        Board.ChangeStatus(x, y, false);
                    }
                    else if (!Board.IsAlive(x, y, 1) && neighbors == 3)
                    {
                        //Una célula muerta con exactamente 3 vecinos vivos se convierte en una célula viva, por
                        //reproducción.
                        Board.ChangeStatus(x, y, true);
                    }
                    else
                    {
                        //Una célula viva con 2 o 3 vecinos vivos sobrevive a la siguiente generación.
                        //En caso de que no cumpla las reglas previas y este muerta se mantendra en su estado original
                        Board.ChangeStatus(x, y, Board.IsAlive(x, y, 1));
                    }
                }
            }
        }
    }
}    