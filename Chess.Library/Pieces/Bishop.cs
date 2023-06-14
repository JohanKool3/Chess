using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Library.Managers;

namespace Chess.Library.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(string color, string startSquare, LogicalBoard board) : base("Bishop", color, startSquare, board)
        {
            this.SetValue(3); // Bishops are worth 3 points
        }

        private Piece? isCollidingWithPiece(string currentSquare)
        {
            if (Board.GetPiece(currentSquare) != null)
            {
                return Board.GetPiece(currentSquare);
            }

            return null;
        }

        public override void GenerateMoves()
        {
            base.GenerateMoves();

            char currentFile = GetSquare()[0];
            int currentRank = Convert.ToInt32(Char.GetNumericValue(GetSquare()[1]));

            // This is a list of all the possible moves that a bishop can make
            List<string> possibleMoves = new List<string>();

            // Up to the Right
            for (int i = 1; i < 8; i++)
            {
                string currentSquare = $"{currentFile + i}{currentRank + i}";
                if (currentFile + i >= 'H' || currentRank + i >= 8)
                {
                    break;
                }

                else
                {
                    if (isCollidingWithPiece(currentSquare) != null)
                    {
                        break;
                    }
                    possibleMoves.Add($"{(char)(currentFile + i)}{currentRank + i}");
                }

            }

            // Up to the Left
            for (int i = 1; i < 8; i++)
            {
                string currentSquare = $"{currentFile - i}{currentRank + i}";
                if (currentFile - i <= 'A' || currentRank + i >= 8)
                {
                    break;
                }
                else
                {
                    if (isCollidingWithPiece(currentSquare) != null)
                    {
                        break;
                    }
                    possibleMoves.Add($"{(char)(currentFile - i)}{currentRank + i}");
                }
            }

            // Down to the Right
            for (int i = 1; i < 8; i++)
            {
                string currentSquare = $"{currentFile + i}{currentRank - i}";
                if (currentFile + i >= 'H' || currentRank - i <= 1)
                {
                    break;
                }
                else
                {
                    if (isCollidingWithPiece(currentSquare) != null)
                    {
                        break;
                    }
                    possibleMoves.Add($"{(char)(currentFile + i)}{currentRank - i}");
                }
            }

            // Down to the Left
            for (int i = 1; i < 8; i++)
            {
                string currentSquare = $"{currentFile - i}{currentRank - i}";
                if (currentFile - i <= 'A' || currentRank - i <= 1)
                {
                    break;
                }
                else
                {
                    if (isCollidingWithPiece(currentSquare) != null)
                    {
                        break;
                    }
                    possibleMoves.Add($"{(char)(currentFile - i)}{currentRank - i}");
                }
            }

            foreach (string newSquare in possibleMoves)
            {
                AddMove(new Move(GetSquare(), newSquare, this, false));
            }

        }
    }
}
