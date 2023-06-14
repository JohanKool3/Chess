using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(string color, string startSquare, LogicalBoard board) : base("Bishop", color, startSquare, board)
        {
            SetValue(3); // Bishops are worth 3 points
        }
    }
}
