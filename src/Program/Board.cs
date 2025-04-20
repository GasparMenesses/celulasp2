using System;
using System.IO;

namespace Program
{
    public class Board
    {
        private readonly int columns;
        private readonly int rows;
        public readonly Cell[,] Cells;
        public readonly int CellSize;

        public int Columns => columns;
        public int Rows => rows;
        public int Width => Columns * CellSize;
        public int Height => Rows * CellSize;

        private readonly Random rand = new Random();

        public Board(int width, int height, int cellSize, double liveDensity = 0.1)
        {
            CellSize = cellSize;
            columns = width / cellSize;
            rows = height / cellSize;

            Cells = new Cell[columns, rows];
            for (int x = 0; x < columns; x++)
            for (int y = 0; y < rows; y++)
                Cells[x, y] = new Cell();


            Randomize(liveDensity);
        }

        public void Randomize(double liveDensity)
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

        private void ConnectNeighbors()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    int left = (x > 0) ? x - 1 : Columns - 1;
                    int right = (x < Columns - 1) ? x + 1 : 0;
                    int top = (y > 0) ? y - 1 : Rows - 1;
                    int bottom = (y < Rows - 1) ? y + 1 : 0;

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
 

