using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class King : Piece
    {
        public King(string color, string startSquare, LogicalBoard board) : base("King", color, startSquare, board)
        {
            // Kings are worth infinite points so they will continue to be worth null points
            Value = null;
        }

        public override void GenerateMoves()
        {
            base.GenerateMoves();

            // King can move one square in any direction

            int[] currentSquare = helper.ConvertToIntegers(Square);

            List<int[]> directions = new ()
            {
                new int[] { 1, 1 },
                new int[] { 1, 0 },
                new int[] { 1, -1 },
                new int[] { 0, 1 },
                new int[] { 0, -1 },
                new int[] { -1, 1 },
                new int[] { -1, 0 },
                new int[] { -1, -1 }
            };

            foreach (int[] direction in directions)
            {
                int[] newSquare = new int[] { currentSquare[0] + direction[0], currentSquare[1] + direction[1] };

                if (helper.BoundsCheck(newSquare))
                {
                    string newSquareString = helper.ConvertToString(newSquare);

                    // If the square is empty, add the move
                    // TODO: Add check for if the square cane be attacked
                    if (Board.GetPiece(newSquareString) == null)
                    {
                        AddMove(new Move(Square, newSquareString, this, false));
                    }
                }
            }



        }

    }
}
