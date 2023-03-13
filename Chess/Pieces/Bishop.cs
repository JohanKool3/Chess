using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Bishop: Piece
    {
        public Bishop(string color, string startSquare): base("Bishop", color, startSquare)
        {
            this.setValue(3); // Bishops are worth 3 points
        }
    }
}
