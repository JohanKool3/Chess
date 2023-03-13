using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Rook: Piece
    {

        public Rook(string color, string startSquare): base("Rook", color, startSquare)
        {
            this.setValue(5); // Rooks are worth 5 points
        }
    }
}
