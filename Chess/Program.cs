using Chess.Managers;
using Chess.Pieces;

namespace Chess
{
    public static class Program
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

        static void TakeMoveInput(LogicalBoard board, ref string color, int index) 
        {
            List<Move> moves = board.GetSideMoves(color);
            Move move = moves[index - 1];
            board.MovePiece(move);

            if(color == "white")
            {
                color = "black";
                
            }
            else
            {
                color = "white";
            }
        }
        static void Main(string[] args)
        {
            //Initial Setup
            string color = "white";
            LogicalBoard board = new LogicalBoard();
            
      
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    board.DisplayBoard();
                    board.LoadMoves();
                    DisplayAllSideMoves(board, color);
                    int index = Int32.Parse(Console.ReadLine());
                    TakeMoveInput(board, ref color, index);
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            


        }
    }
}