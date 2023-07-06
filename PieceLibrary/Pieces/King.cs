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
                new [] { 1, 1 },
                new [] { 1, 0 },
                new [] { 1, -1 },
                new [] { 0, 1 },
                new [] { 0, -1 },
                new [] { -1, 1 },
                new [] { -1, 0 },
                new [] { -1, -1 }
            };

            foreach (int[] direction in directions)
            {
                int[] newSquare = new [] { currentSquare[0] + direction[0], currentSquare[1] + direction[1] };

                if (helper.BoundsCheck(newSquare))
                {
                    string newSquareString = helper.ConvertToString(newSquare);

                    // If the square is empty, add the move
                    Piece? _squareContents = Board.GetPiece(newSquareString);
                    if (_squareContents == null)
                    {
                        AddMove(new Move(Square, newSquareString, this, false));
                    }
                    else if(_squareContents?.Color != Color)
                    {
                        AddMove(new Move(Square, newSquareString, this, true));
                    }
                }
            }



        }

    }
}
