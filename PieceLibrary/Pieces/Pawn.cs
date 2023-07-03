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
             int[] newPosition = new[] { currentPosition[0], currentPosition[1] + colorMultiplier};
            AddMove(new Move(Square,
                helper.ConvertToString(newPosition),
                this, false));

            // Moving for the first time
            if (firstMove) // The piece can move two squares if it is the first move
            {
                newPosition[1] += colorMultiplier;
                AddMove(new Move(Square,
                    helper.ConvertToString(newPosition),
                    this, false));

            }

            #region Taking Pieces


            // To the right
            List<int[]> newPositionsList = new()
            { new [] {currentPosition[0] + 1, currentPosition[1] + colorMultiplier}, // Taking forwards
              new [] {currentPosition[0] - 1, currentPosition[1] + colorMultiplier},
              new [] {currentPosition[0] + 1, currentPosition[1]}, // Taking En Passant
              new [] {currentPosition[0] - 1, currentPosition[1]}
            };
            Piece? piece;
            int index = 0;
            foreach (int[] position in newPositionsList)
            {
                index++;
                if (helper.BoundsCheck(position))
                {
                    piece = Board.GetPiece(helper.ConvertToString(position));
                    if(index <= 2) // Normal Taking
                    {
                        if(piece is not null && piece.Color != Color)
                        {
                            AddMove(new Move(Square,
                                helper.ConvertToString(position),
                                    this, true));
                        }
                    }
                    else // Check En Passant Taking
                    {
                        if (piece is not null && firstMove && piece is Pawn && piece.Color != Color)
                        {
                            AddMove(new Move(Square,
                                helper.ConvertToString(position),
                                    this, true));
                        }
                    }

                }

            }
            #endregion
        }

        public override void MovePiece(Move move)
        {
            base.MovePiece(move);
            firstMove = false;
        }
    }
}
