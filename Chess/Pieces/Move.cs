using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Move
    {
        private string StartSquare { get;}
        private string EndSquare { get;}
        private Piece Piece { get;}

        public Move(string startSquare, string endSquare, Piece piece)
        {
           StartSquare = startSquare;
           EndSquare = endSquare;
           Piece = piece;
        }

        public override string ToString()
        {
            return $"From {StartSquare} to {EndSquare}";
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


    }
}
