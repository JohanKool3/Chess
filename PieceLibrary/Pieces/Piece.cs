using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class Piece
    {
        /// <summary>
        /// Standard chess piece
        ///</summary>
        private string Color { get; } // The color of the piece (either "White" or "Black")
        private string PieceCode { get; set; } // The code of the piece (format is "wK" for white king)
        private int Value { get; set; } // The material value of the given chess piece
        private string Square { get; set; } // The key of the square that the piece is on (using the notation of the board)
        private readonly List<Move> LegalMoves = new List<Move>(); // The moves that the piece can make that abide by the rules of chess

        private readonly LogicalBoard Board; //Reference to the Board object

        // Constructor
        public Piece(string piece, string color, string startSquare, LogicalBoard board)
        {
            PieceCode = $"{char.ToUpper(color[0])}-{char.ToUpper(piece[0])}"; // e.g. White King "W-K"
            Color = color;
            Square = startSquare;
            Board = board;
        }

        public override string ToString()
        {
            return PieceCode;
        }

        // Special Methods
        private bool CheckValidMove(Move move)
        {
            bool valid = true;

            // If the move is out of bounds
            if (move.GetEndSquare().Length > 2 || move.GetEndSquare()[0] < 'A' || move.GetEndSquare()[0] > 'H' || move.GetEndSquare()[1] < '1' || move.GetEndSquare()[1] > '8')
            {
                valid = false;
            }

            // If the move puts the friendly king into check

            // If the move is blocked by another friendly piece
            else if (Board.GetPiece(move.GetEndSquare()) != null && Board.GetPiece(move.GetEndSquare()).GetColor() == Color)
            {
                valid = false;
            }
            // If the move is blocked by an enemy piece and the move is not a capture
            else if (Board.GetPiece(move.GetEndSquare()) != null && Board.GetPiece(move.GetEndSquare()).GetColor() != Color && !move.GetCapture())
            {
                valid = false;
            }

            return valid;
        }

        public virtual void MovePiece(Move move)
        { // This method is purely to update the attributes inside of the piece, Board updates will be done inside of the 'LogicalBoard' object
            if (LegalMoves.Contains(move))
            {
                Square = move.GetEndSquare(); // Sets the square of the piece to the destination square
            }
        }

        public void AddMove(Move move)
        {
            if (CheckValidMove(move))
            {
                LegalMoves.Add(move);
            }
        }

        public virtual void GenerateMoves()
        {
            LegalMoves.Clear();
        }

        // Get Methods
        public string GetColor()
        {
            return Color;
        }
        public int GetValue()
        {
            return Value;
        }

        public string GetPieceCode()
        {
            return PieceCode;
        }

        public string GetSquare()
        {
            return Square;
        }

        public List<Move> GetMoves()
        {
            return LegalMoves;
        }

        // Set Methods
        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetSquare(string square)
        {
            Square = square;
        }

        public void SetCode(string code)
        {
            if (this is Knight && (PieceCode != "W-N" || PieceCode != "B-N"))
            {
                PieceCode = code;
            }
            else
            {
                Console.WriteLine("Can only change the type of the Knight to adhere to the rules");
            }
        }
    }
}
