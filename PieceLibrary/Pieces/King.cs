﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    internal class King : Piece
    {
        public King(string color, string startSquare, LogicalBoard board) : base("King", color, startSquare, board)
        {
            // Kings are worth infinite points so they will continue to be worth null points
            Value = null;
        }
    }
}
