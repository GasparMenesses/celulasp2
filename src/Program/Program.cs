
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Library.BoardImporter.ImportFromFile(".\\board.txt");
            while (true)
            {
                Library.Motor.GenerateNewGeneration();
                Library.BoardPrinter.Print();
            }
        }
    }
}