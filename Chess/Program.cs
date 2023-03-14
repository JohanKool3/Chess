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

        static void TestPieceMovement(LogicalBoard board) 
        {
            //Move the A2 pawn to A4
            Move move = board.GetPieceMoves("A2")[1];
            Console.WriteLine(move);
            board.MovePiece(move);
        }

        static void DisplayAllSideMoves(LogicalBoard board, string color) 
        {
            List<Move> displayMoves = board.GetSideMoves(color);

            int index = 1;
            foreach(Move move in displayMoves)
            {
                Console.WriteLine($"{index}. {move}");

                index++;
            }
        }
        static void Main(string[] args)
        {
            LogicalBoard board = new LogicalBoard();
            board.LoadMoves();

            DisplayAllSideMoves(board, "white");

        }
    }
}