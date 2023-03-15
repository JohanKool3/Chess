using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Managers;

namespace Chess.Pieces
{
    internal class Queen: Piece
    {
        public Queen(string color, string startSquare, LogicalBoard board): base("Queen", color, startSquare, board)
        {
            this.SetValue(9); // Queens are worth 9 points
        }
    }
       
}
