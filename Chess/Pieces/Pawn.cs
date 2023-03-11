using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace Chess
{

    internal class Pawn : Piece
    {
        // Base acts like super in python. It calls the constructor of the parent class on running of the child class
        public Pawn(string piece, string color, string startSquare): base(piece, color, startSquare)
        {
            this.setValue(1); // Pawns are worth 1 point
        }

        // Check to see if the move is valid
        private bool checkValid(string newSquare)
        {
            bool valid = true;
            // Check that the move is valid...
            return valid;
        }

        public void movePiece(string newSquare)
        {
            //Check that the move is valid...

            if (checkValid(newSquare))
            {
                setSquare(newSquare);
            }
        }

    }
}
