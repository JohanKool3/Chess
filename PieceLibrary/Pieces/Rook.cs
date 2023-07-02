using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class Rook : Piece
    {

        public Rook(string color, string startSquare, LogicalBoard board) : base("Rook", color, startSquare, board)
        {
            Value = 5; // Rooks are worth 5 points
        }

        public override void GenerateMoves()
        {
            base.GenerateMoves();

            List<int[]> _allDirections = new()
            {
                new [] {1, 0},
                new [] {0, 1},
                new [] {-1, 0},
                new [] {0, -1}
            };

            foreach (int[] direction in _allDirections)
            {
                List<Move> moves = GetMoves(direction);
                foreach (Move move in moves)
                {
                    AddMove(move);
                }

            }
        }

        private List<Move> GetMoves(int[] direction)
        {
            int[] currentPosition = helper.ConvertToIntegers(Square);

            List<Move> possibleMoves = new();

            currentPosition[0] += direction[0];
            currentPosition[1] += direction[1];

            while (helper.BoundsCheck(currentPosition))
            {
                // Break out of the movement loop.
                // TODO: Add logic to check if the piece is an enemy piece
                Piece? _ = Board.GetPiece(helper.ConvertToString(currentPosition));
                if (_ != null)
                {
                    if (_.Color != Color)
                    {
                        possibleMoves.Add(new Move(Square,
                            helper.ConvertToString(currentPosition),
                                this, true));
                    }
                    break;
                }

                possibleMoves.Add(new Move(Square,
                helper.ConvertToString(currentPosition),
                    this, false));

                currentPosition[0] += direction[0];
                currentPosition[1] += direction[1];


            }
            return possibleMoves;
        }
    }
}
