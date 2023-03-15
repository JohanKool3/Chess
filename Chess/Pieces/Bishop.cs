using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Managers;

namespace Chess.Pieces
{
    internal class Bishop: Piece
    {
        public Bishop(string color, string startSquare, LogicalBoard board): base("Bishop", color, startSquare, board)
        {
            this.SetValue(3); // Bishops are worth 3 points
        }
    }
}
