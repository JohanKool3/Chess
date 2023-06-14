using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Chess.Library.Managers;

namespace Chess.Library.Pieces
{
    internal class Rook: Piece
    {

        public Rook(string color, string startSquare, LogicalBoard board): base("Rook", color, startSquare, board)
        {
            this.SetValue(5); // Rooks are worth 5 points
        }
    }
}
