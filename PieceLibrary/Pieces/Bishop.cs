using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(string color, string startSquare, LogicalBoard board) : base("Bishop", color, startSquare, board)
        {
            Value = 3; // Bishops are worth 3 points
        }

        public override void GenerateMoves()
        {
            base.GenerateMoves();

            List<int[]> _allDirections = new(){
                new [] {1, 1},
                new [] {1, -1},
                new [] {-1, 1},
                new [] {-1, -1}
            };

            foreach (int[] direction in _allDirections)
            {
                List<Move> moves = GetMoves(direction);

                foreach(Move move in moves)
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
                //TODO: Add logic to check if the piece is an enemy piece
                if(Board.GetPiece(helper.ConvertToString(currentPosition)) != null)
                {
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
