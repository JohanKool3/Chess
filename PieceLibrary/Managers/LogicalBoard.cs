using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Pieces;


namespace PieceLibrary.Managers
{
    public class LogicalBoard
    {
        private readonly Dictionary<string, Piece?> Contents = new Dictionary<string, Piece?>();

        public Dictionary<string, Piece?> contents { get { return Contents; } }

        // Objects that will be responsible for material counts and checks later on in development
        private readonly Side WhitePieces = new Side("White");
        public Side returnWhitePieces { get { return WhitePieces; } }
        private readonly Side BlackPieces = new Side("Black");
        public Side returnBlackPieces { get { return BlackPieces; } }
        private List<Move> MoveOrder = new List<Move>();

        private void CreateBoard()
        {

            List<string> files = new List<string> {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H"
            };

            foreach(string file in files)
            {
                foreach(int rank in Enumerable.Range(1, 8))
                {
                    Contents.Add($"{file}{rank}", null);
                }

            }

        }
        private void AddPiece(Piece newPiece, string key)
        {
            try
            {
                Contents[key] = newPiece;

                // Adding Piece references to the side objects
                if(newPiece.Color == "White")
                {
                    WhitePieces.AddPiece(newPiece);
                }
                else
                {
                    BlackPieces.AddPiece(newPiece);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Invalid key, key must be a valid square",e);
            }
        }
        private void PopulateBoard()
        {

            // White Pawns
            for (char file = 'A'; file <= 'H'; file ++)
            {
                AddPiece(new Pawn("White", $"{file}2", this), $"{file}2");
            }
            // White Rooks
            AddPiece(new Rook("White", "A1", this), "A1");
            AddPiece(new Rook("White", "H1", this), "H1");

            // White Knights
            AddPiece(new Knight("White", "B1", this), "B1");
            AddPiece(new Knight("White", "G1", this), "G1");

            // White Bishops
            AddPiece(new Bishop("White", "C1", this), "C1");
            AddPiece(new Bishop("White", "F1", this), "F1");

            // White Royalty
            AddPiece(new Queen("White", "D1", this), "D1");
            AddPiece(new King("White", "E1", this), "E1");


            // Black Pawns
            for (char file = 'A'; file <= 'H'; file++)
            {
                AddPiece(new Pawn("Black", $"{file}7", this), $"{file}7");
            }
            // Black Rooks
            AddPiece(new Rook("Black", "A8", this), "A8");
            AddPiece(new Rook("Black", "H8", this), "H8");

            // Black Knights
            AddPiece(new Knight("Black", "B8", this), "B8");
            AddPiece(new Knight("Black", "G8", this), "G8");

            // Black Bishops
            AddPiece(new Bishop("Black", "C8", this), "C8");
            AddPiece(new Bishop("Black", "F8", this), "F8");

            // Black Royalty
            AddPiece(new Queen("Black", "D8", this), "D8");
            AddPiece(new King("Black", "E8", this), "E8");



        }
        public LogicalBoard()
        {
            // Create the board
            CreateBoard();
            PopulateBoard();
        }
        public static void CustomBoardSetup()
        {
            // This method will allow the user to create a custom board setup
            // This will be used for testing purposes
        }
        public void DisplayBoard()
        {
            // This method will display the contents that are currently stored inside of this object in a board layout

            // Iterates through the ranks from last to first
            for(int rank = 8; rank > 0; rank--)
            {
                // Iterates through the files from first to last
                for(char file = 'A'; file <= 'H'; file++)
                {
                    string square = $"{file}{rank}"; //Creates the key of the square to be displayed

                    Piece? piece = Contents[square]; // Fetches the contents of that square
                    string output = "";

                    // Adds readouts for the Ranks
                    if(file == 'A')
                    {
                        output += Convert.ToString(rank);
                    }
                    if (piece == null)
                    {
                        Console.Write($"{output}(   )|");
                    }
                    else
                    {
                        Console.Write($"{output}({piece.PieceCode})|");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(" ------------------------------------------------");
            }
            for (char file = 'A'; file <= 'H'; file++)
            {
                Console.Write($"   {file}  ");
            }
            Console.WriteLine();

        }

        public void LoadMoves()
        {
            foreach(var piece in Contents.Values)
            {
                if (piece != null)
                {
                    piece.GenerateMoves();
                }

            }
        }

        public void MovePiece(Move move)
        {
            // There will be another function that handles taking pieces
            try
            {

                Piece? movingPiece = Contents[move.StartSquare];

                if (movingPiece != null)
                {
                    movingPiece.MovePiece(move);
                    MoveOrder.Add(move);
                }
                else
                {
                    Console.WriteLine("No piece to move");
                }


                // Update the board to reflect the move that has been made within the piece object
                Contents[move.StartSquare] = null;
                Contents[move.EndSquare] = movingPiece;

                DisplayBoard();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid square");
            }

        }
        public List<Move> GetPieceMoves(string square)
        {
            if (Contents[square] != null)
            {
                Piece piece = Contents[square];

                return piece.LegalMoves;
            }
            else
            {
                return new List<Move>();
            }

        }

        public Piece? GetPiece(string square)
        {
           return Contents[square];
        }

        public List<Move> GetSideMoves(string color)
        {
            if(color == "white")
            {
                return WhitePieces.GetAllSideMoves();
            }
            else
            {
                return BlackPieces.GetAllSideMoves();
            }
        }

        public List<Move> GetMoveOrder()
        {
            return MoveOrder;
        }

    }
}
