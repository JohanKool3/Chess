// See https://aka.ms/new-console-template for more information
using Chess.Managers;
using Chess.Pieces;

namespace Chess
{
    class Program
    {
        static void DisplayMoves(LogicalBoard board, string square)
        {
            List<Move> moves = board.GetPieceMoves(square);
            foreach(Move move in moves)
            {
                Console.WriteLine(move);
            }

        }
        static void Main(string[] args)
        {
            LogicalBoard board = new LogicalBoard();
            board.LoadMoves();

            DisplayMoves(board, "A2");

        }
    }
}