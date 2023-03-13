using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace Chess.Pieces
{

    internal class Pawn : Piece
    {
        // Base acts like super in python. It calls the constructor of the parent class on running of the child class
        public Pawn(string color, string startSquare): base("Pawn", color, startSquare)
        {
            this.setValue(1); // Pawns are worth 1 point
        }
   
    }
}
