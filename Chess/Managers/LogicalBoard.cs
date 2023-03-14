using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

namespace Chess.Managers
{
    internal class LogicalBoard
    {
        private Dictionary<string, Piece> Contents = new Dictionary<string, Piece>();
        // Objects that will be responsible for material counts and checks later on in development
        private Side WhitePieces = new Side("White");
        private Side BlackPieces = new Side("Black");

        private void CreateBoard()
        {
            List<string> ranks = new List<string>();
            ranks.Add("A");
            ranks.Add("B");
            ranks.Add("C");
            ranks.Add("D");
            ranks.Add("E");
            ranks.Add("F");
            ranks.Add("G");
            ranks.Add("H");

            foreach(string file in ranks)
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
                if(newPiece.GetColor() == "White")
                {
                    WhitePieces.AddPiece(newPiece);
                }
                else
                {
                    BlackPieces.AddPiece(newPiece);
                }
            }
            catch
            {
                Console.Write($"Key {key} is not compatable");
            }
        }
        private void PopulateBoard()
        {

            // White Pawns
            for (char file = 'A'; file <= 'H'; file ++)
            {
                AddPiece(new Pawn("White", $"{file}2"), $"{file}2");
            }
            // White Rooks
            AddPiece(new Rook("White", "A1"), "A1");
            AddPiece(new Rook("White", "H1"), "H1");

            // White Knights
            AddPiece(new Knight("White", "B1"), "B1");
            AddPiece(new Knight("White", "G1"), "G1");

            // White Bishops
            AddPiece(new Bishop("White", "C1"), "C1");
            AddPiece(new Bishop("White", "F1"), "F1");

            // White Royalty
            AddPiece(new Queen("White", "D1"), "D1");
            AddPiece(new King("White", "E1"), "E1");


            // Black Pawns
            for (char file = 'A'; file <= 'H'; file++)
            {
                AddPiece(new Pawn("Black", $"{file}7"), $"{file}7");
            }
            // Black Rooks
            AddPiece(new Rook("Black", "A8"), "A8");
            AddPiece(new Rook("Black", "H8"), "H8");

            // Black Knights
            AddPiece(new Knight("Black", "B8"), "B8");
            AddPiece(new Knight("Black", "G8"), "G8");

            // Black Bishops
            AddPiece(new Bishop("Black", "C8"), "C8");
            AddPiece(new Bishop("Black", "F8"), "F8");

            // Black Royalty
            AddPiece(new Queen("Black", "D8"), "D8");
            AddPiece(new King("Black", "E8"), "E8");

            
            
        }
        public LogicalBoard()
        {
            // Create the board
            CreateBoard();
            PopulateBoard();
            DisplayBoard();
        }

        public static void CustomBoardSetup()
        {
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

                    Piece piece = Contents[square]; // Fetches the contents of that square
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
                        Console.Write($"{output}({piece.GetPieceCode()})|");
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
                Piece movingPiece = Contents[move.GetStartSquare()];
                movingPiece.MovePiece(move);
                

                // Update the board to reflect the move that has been made within the piece object
                Contents[move.GetStartSquare()] = null;
                Contents[move.GetEndSquare()] = movingPiece;

                DisplayBoard();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid square");
            }

        }
        public List<Move> GetPieceMoves(string square)
        {
            Piece piece = Contents[square];

            return piece.GetMoves();

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
    }
}
