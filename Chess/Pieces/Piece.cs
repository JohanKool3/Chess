using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Piece
    {
        // This class is the super class for all of the piece types
        private string Color { get;} // The color of the piece (either "White" or "Black")
        private string PieceCode { get;} // The code of the piece (format is "wK" for white king)
        private int Value { get; set; } // The material value of the given chess piece
        private string Square { get; set; } // The key of the square that the piece is on (using the notation of the board)
        private List<Move> LegalMoves = new List<Move>(); // The moves that the piece can make that abide by the rules of chess

        // Constructor
        public Piece(string piece, string color, string startSquare)
        {
            PieceCode = $"{char.ToUpper(color[0])}-{char.ToUpper(piece[0])}"; // e.g. "wK"
            Color = color;
            Square = startSquare ;
        }

        public override string ToString()
        {
            return $"{PieceCode}| Current Square {Square}";
        }

        // Special Methods
        private bool CheckValidMove(Move move)
        {
            bool valid = true;

            // If the move is out of bounds

            // If the move puts the friendly king into check

            // If the move is blocked by another friendly piece

            // If the move is blocked by an enemy piece and the move is not a capture

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

    }   
}
