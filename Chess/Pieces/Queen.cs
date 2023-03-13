using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Queen: Piece
    {
        public Queen(string color, string startSquare): base("Queen", color, startSquare)
        {
            this.SetValue(9); // Queens are worth 9 points
        }
    }
       
}
