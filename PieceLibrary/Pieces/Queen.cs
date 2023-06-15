using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class Queen : Piece
    {
        public Queen(string color, string startSquare, LogicalBoard board) : base("Queen", color, startSquare, board)
        {
            Value = 9; // Queens are worth 9 points
        }
    }

}
