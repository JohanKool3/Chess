using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Move
    {
        private string startSquare;
        private string endSquare;

        public Move(string startSquare, string endSquare)
        {
            this.startSquare = startSquare;
            this.endSquare = endSquare;
        }
    }
}
