using System;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] jorge = BoardImporter.ImportFromFile( ".\\board.txt");
            bool[,] a = jorge;
            while (true)
            {
                a = Motor.GenerateNewGeneration(a);
                BoardPrinter.Print(a);
            }
            
        }
    }
}

