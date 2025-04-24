//Board Printer es la clase que se encarga de la representaciónm gráfica del proigrama
//En este caso imprime por consola una matriz de "|X|" para las células vivas y "___" para las celulas muertas
//Lo hace continuamente con un retraso de 300 ms, limpiando la pantalla con cada iteración para simular un efecto de animación

//La única responsabilidad que tiene es imprimir el tablero. No está involucrado en la lógica de simulación del Juego de la Vida, cumpliendo con SRP
//Es la clase experta en cómo representar visualmente el tablero y, por lo tanto, debe ser la encargada de esta responsabilidad, cumpliendo con Expert

using System;
using System.Text;
using System.Threading;

namespace Library
{
    public class BoardPrinter
    {

        // Método que se encarga de imprimir el tablero. Recibe como parámetro una matriz bidimensional de booleanos (b)
        // donde cada valor puede ser true (célula viva) o false (célula muerta).
        public static void Print()
        {
            int height = Board.GetLength0(); // Filas (Y)
            int width = Board.GetLength1(); // Columnas (X)
            
                Console.Clear(); // limpio la consola para que el estado anterior desaparezca

                StringBuilder s = new StringBuilder(); // construye de manera eficiente una cadena de texto que representará el tablero
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)     // recorro cada elemento de la fila iterando columnas
                    {
                        if (Board.IsAlive(y, x)) // condicional para la posición de la célula
                        {
                            s.Append("|X|");   // si está viva
                        }
                        else
                        {
                            s.Append("___");   // si no
                        }
                    }

                    s.Append("\n"); // salto de linea al final de cada fila (después de recorrer todas las columnas de una fila)
                }
                Console.WriteLine(s.ToString());  // imprimo el tablero de cada generación
                Thread.Sleep(300); // espero 300 milisegundos para un mejor efecto visual
            
        }
    }
}