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
        public string StartSquare { get; }
        public string EndSquare { get; }
        public Piece Piece { get; }
        public bool Capture { get; set; } // If the move is a capture

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
                return $"{char.ToLower(Piece.PieceCode[2])}{EndSquare}";
            }
            else
            {
                return $"{EndSquare}";
            }
        }

    }
}
