using System;
using System.IO;

namespace Program
{
    public class Board
    {   // Cantidad de columnas y filas de la cuadrícula
        private readonly int columns;
        private readonly int rows;
        // Matriz de células que forman el tablero
        public readonly Cell[,] Cells;
        public readonly int CellSize;

        public int Columns => columns;
        public int Rows => rows;
        public int Width => Columns * CellSize;
        public int Height => Rows * CellSize;

        private readonly Random rand = new Random();

        public Board(int width, int height, int cellSize, double liveDensity = 0.1)     // Constructor: inicializa el tablero con las dimensiones y densidad de células vivas
        {
            CellSize = cellSize;
            columns = width / cellSize;
            rows = height / cellSize;
            // Crear la matriz de células
            Cells = new Cell[columns, rows];
            for (int x = 0; x < columns; x++)
            for (int y = 0; y < rows; y++)
                Cells[x, y] = new Cell();


            Randomize(liveDensity);
            ConnectNeighbors(); // Conecta cada célula con sus vecinas (esto es importante para que funcione correctamente)
        }

        public void Randomize(double liveDensity)   // Asigna aleatoriamente células vivas según la densidad especificada
        {
            foreach (var cell in Cells)
                cell.IsAlive = rand.NextDouble() < liveDensity;
        }

        public void Advance()
        {
            foreach (var cell in Cells)
                cell.DetermineNextLiveState();
            foreach (var cell in Cells)
                cell.Advance();
        }

        private void ConnectNeighbors()  // Conecta cada célula con sus 8 vecinas
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    int left = (x > 0) ? x - 1 : Columns - 1;
                    int right = (x < Columns - 1) ? x + 1 : 0;
                    int top = (y > 0) ? y - 1 : Rows - 1;
                    int bottom = (y < Rows - 1) ? y + 1 : 0;
                    // Agrega las 8 células vecinas (arriba, abajo, izquierda, derecha y diagonales)
                    var cell = Cells[x, y];
                    cell.Neighbors.Add(Cells[left, top]);
                    cell.Neighbors.Add(Cells[x, top]);
                    cell.Neighbors.Add(Cells[right, top]);
                    cell.Neighbors.Add(Cells[left, y]);
                    cell.Neighbors.Add(Cells[right, y]);
                    cell.Neighbors.Add(Cells[left, bottom]);
                    cell.Neighbors.Add(Cells[x, bottom]);
                    cell.Neighbors.Add(Cells[right, bottom]);
                }
            }
        }
        
    }

}
 

