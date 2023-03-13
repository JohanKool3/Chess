using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Knight: Piece
    {
        public Knight(string color, string startSquare): base("Knight",color, startSquare)
        { 
            this.setValue(3); // Knights are worth 3 points
        }
    }
}
