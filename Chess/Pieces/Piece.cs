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
        private string pieceCode { get;}
        private int value { get; set; }
        private string square { get; set; }
        private List<Move> legalMoves = new List<Move>();

        public Piece(string piece, string color, string startSquare)
        {
            pieceCode = $"{char.ToUpper(color[0])}-{char.ToUpper(piece[0])}"; // e.g. "wK"
            square = startSquare ;
        }

        public bool checkValid(string newSquare)
        {
            bool valid = true;
            // Check that the move is valid...
            return valid;
        }

        public void MovePiece(string newSquare)
        {
            if (checkValid(newSquare))
            {

            }
        }

        public void addMove(Move move)
        {
            legalMoves.Add(move);
        }
        public string getSquare()
        {
            return square ;
        }

        public string getPieceCode()
        {
            return pieceCode;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int value)
        {
            if (0 < value  && value < 10)
            {
                this.value = value;
            }
            else
            {
                Console.WriteLine($"{value} is invalid. It must be a value between 1 and 9!");
            }
        }

        public void setSquare(string newSquare)
        {
            square = newSquare;
        }

    }   
}
