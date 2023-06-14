using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary;

namespace PieceLibrary.Pieces
{
    public class Move
    {
        private string StartSquare { get; }
        private string EndSquare { get; }
        private Piece Piece { get; }
        private bool Capture { get; set; } // If the move is a capture

        public Move(string startSquare, string endSquare, Piece piece, bool capture)
        {
            StartSquare = startSquare;
            EndSquare = endSquare;
            Piece = piece;
            Capture = capture;
        }

        public override string ToString()
        {
            if (Piece is not Pawn)
            {
                return $"{char.ToLower(Piece.GetPieceCode()[2])}{EndSquare}";
            }
            else
            {
                return $"{EndSquare}";
            }
        }

        public string GetStartSquare()
        {
            return StartSquare;
        }
        public string GetEndSquare()
        {
            return EndSquare;
        }
        public Piece GetPiece()
        {
            return Piece;
        }
        public bool GetCapture()
        {
            return Capture;
        }
    }
}
