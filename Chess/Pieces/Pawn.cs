using System;
using System.Collections.Generic;
using Chess;

namespace Chess.Pieces
{

    internal class Pawn : Piece
    {
        // Base acts like super in python. It calls the constructor of the parent class on running of the child class
        private bool firstMove = true; // So we know if the piece can move two spaces or not
        public Pawn(string color, string startSquare): base("Pawn", color, startSquare)
        {
            this.SetValue(1); // Pawns are worth 1 point
        }

        public override void GenerateMoves()
        {
            base.GenerateMoves();
            // This is important for generating the new squares that the piece can move to
            char currentFile = GetSquare()[0];
            int currentRank = Convert.ToInt32(Char.GetNumericValue(GetSquare()[1]));

            int colorMultiplier = 1;

            if(GetColor() == "Black")
            {
                colorMultiplier *= -1;
            }

            // Normal Pawn Movement
            int newRank = currentRank + (colorMultiplier * 1);
            string destSquare = $"{currentFile}{newRank}";
            AddMove(new Move(GetSquare(), destSquare, this));

            if (firstMove) // The piece can move two squares if it is the first move
            {
                newRank = currentRank + (colorMultiplier * 2);
                destSquare = $"{currentFile}{newRank}";

                AddMove(new Move(GetSquare(), destSquare, this)); 
                
            }
            
        }

        public override void MovePiece(Move move)
        {
            base.MovePiece(move);
            firstMove = false;
        }
    }
}
