using System;
using System.IO;

namespace Program
{
    public class Board
    {
        // Cantidad de columnas y filas del tablero
        private readonly int columns;
        private readonly int rows;

        // Tamaño de cada celda en píxeles
        public readonly int CellSize;

        // Matriz que representa el estado de cada celda (viva o muerta)
        public bool[,] Cells;

        // Generador de números aleatorios
        private readonly Random rand = new Random();

        // Propiedades que calculan automáticamente los valores derivados
        public int Columns => columns;
        public int Rows => rows;
        public int Width => Columns * CellSize;  // Ancho total del tablero en píxeles
        public int Height => Rows * CellSize;    // Alto total del tablero en píxeles

        // Constructor del tablero
        // Recibe el tamaño en píxeles, el tamaño de cada celda y la densidad inicial de células vivas
        public Board(int width, int height, int cellSize, double liveDensity = 0.1)
        {
            CellSize = cellSize;
            columns = width / cellSize;  // Calcula cuántas columnas caben en el ancho
            rows = height / cellSize;    // Calcula cuántas filas caben en el alto

            // Inicializa la matriz de celdas como falsa (todas muertas)
            Cells = new bool[columns, rows];

            // Genera una configuración aleatoria de células vivas
            Randomize(liveDensity);
        }

        // Método que asigna aleatoriamente células vivas según la densidad especificada
        public void Randomize(double liveDensity)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    // Cada celda tiene una probabilidad "liveDensity" de estar viva
                    Cells[x, y] = rand.NextDouble() < liveDensity;
                }
            }
        }

        // Avanza a la siguiente generación aplicando las reglas del Juego de la Vida
        public void Advance()
        {
            // Usa la clase Motor para generar la nueva generación de células
            Cells = Motor.GenerateNewGeneration(Cells);
        }
    }

}
 

