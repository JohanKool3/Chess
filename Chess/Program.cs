using PieceLibrary.Pieces;
using PieceLibrary.Managers;

namespace Chess
{
    public static class Program
    {
        public static bool running = true;
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

        static void DisplayMoveOrder(LogicalBoard board)
        {
            int currentMove = 1;
            foreach(Move move in board.GetMoveOrder())
            {
                if (currentMove % 2 == 1)
                {
                    Console.Write($"{currentMove}. {move}, ");

                }
                else
                {
                    Console.WriteLine(move);
                }

                currentMove++;
            }
        }
        static void TakeMoveInput(LogicalBoard board, ref string color, string userIn)
        {
            userIn = userIn.ToLower();
            if (userIn ==  "exit" || userIn ==  "q" || userIn ==  "quit")
            {
                running = false;
            }
            else
            {
                int index = Int32.Parse(userIn);
                List<Move> moves = board.GetSideMoves(color);
                Move move = moves[index - 1];
                board.MovePiece(move);

                if (color == "white")
                {
                    color = "black";

                }
                else
                {
                    color = "white";
                }
            }
        }
        static void Main(string[] args)
        {
        //Initial Setup
            string color = "white";
            LogicalBoard board = new LogicalBoard();

            while (running)
            {
                try
                {
                    board.DisplayBoard();
                    board.LoadMoves();
                    DisplayAllSideMoves(board, color);
                    string userIn = Console.ReadLine();
                    TakeMoveInput(board, ref color, userIn);
                    Console.Clear();
                }

                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");

                }

                // End of the program, display the board and moves that were played in the game
                Console.Clear();
                board.DisplayBoard();
                DisplayMoveOrder(board);
            }


        }
    }
}
