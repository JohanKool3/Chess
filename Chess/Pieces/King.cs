using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class King: Piece
    {
        public King(string color, string startSquare): base("King", color, startSquare)
        {
             // Kings are worth infinite points so they will continue to be worth null points
        }
    }
    
}
