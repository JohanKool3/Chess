﻿using System;
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
            // This is important for generating the new squares that the piece can move to
            int colorMultiplier = 1;
            char currentFile = Square[0];
            int currentRank = Convert.ToInt32(char.GetNumericValue(Square[1]));

            if (Color == "Black")
            {
                colorMultiplier *= -1;
            }

            // Normal Pawn Movement
            int newRank = currentRank + colorMultiplier * 1;
            string destSquare = $"{currentFile}{newRank}";
            AddMove(new Move(Square, destSquare, this, false));

            if (firstMove) // The piece can move two squares if it is the first move
            {
                newRank = currentRank + colorMultiplier * 2;
                destSquare = $"{currentFile}{newRank}";

                AddMove(new Move(Square, destSquare, this, false));

            }

        }

        public override void MovePiece(Move move)
        {
            base.MovePiece(move);
            firstMove = false;
        }
    }
}
