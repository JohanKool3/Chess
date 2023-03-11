// See https://aka.ms/new-console-template for more information
using Chess;
using Chess.Managers;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicalBoard board = new LogicalBoard();
            Console.WriteLine(board);

        }
    }
}