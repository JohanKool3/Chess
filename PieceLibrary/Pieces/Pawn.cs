using System;
using System.Collections.Generic;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{

    public class Pawn : Piece
    {
        // Base acts like super in python. It calls the constructor of the parent class on running of the child class
        private bool firstMove = true; // So we know if the piece can move two spaces or not
        public Pawn(string color, string startSquare, LogicalBoard board) : base("Pawn", color, startSquare, board)
        {
            Value = 1; // Pawns are worth 1 point
        }

        public override void GenerateMoves()
        {
            /// <summary>
            /// This method generates all of the moves that the pawn can make
            /// </summary>
            ///
            base.GenerateMoves();


            int colorMultiplier = 1;
            int[] currentPosition = helper.ConvertToIntegers(Square);

            if (Color == "Black")
            {
                colorMultiplier *= -1;
            }

            // Normal Pawn Movement
            currentPosition[1] += colorMultiplier * 1;
            AddMove(new Move(Square,
                helper.ConvertToString(currentPosition),
                this, false));

            if (firstMove) // The piece can move two squares if it is the first move
            {
                currentPosition[1] += colorMultiplier * 1;
                AddMove(new Move(Square,
                    helper.ConvertToString(currentPosition),
                    this, false));

            }

        }

        public override void MovePiece(Move move)
        {
            base.MovePiece(move);
            firstMove = false;
        }
    }
}
