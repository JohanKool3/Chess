using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    internal class Knight : Piece
    {
        public Knight(string color, string startSquare, LogicalBoard board) : base("Knight", color, startSquare, board)
        {
            Value = 3; // Knights are worth 3 points
            PieceCode = $"{char.ToUpper(color[0])}-N";
        }

        public override void GenerateMoves()
        {
            // Wipes moves from the Legal Moves List
            base.GenerateMoves();
            int[] currentPosition = helper.ConvertToIntegers(Square);

            // This is a list of all the possible moves that a knight can make
            List<int[]> possibleMoves = new()
            {
                new [] {currentPosition[0] + 1, currentPosition[1] + 2}, // Up to the Right
                new [] {currentPosition[0] - 1, currentPosition[1] + 2}, // Up to the Left

                new [] {currentPosition[0] + 1, currentPosition[1] - 2}, // Down to the Right
                new [] {currentPosition[0] - 1, currentPosition[1] - 2}, // Down to the Left

                new [] {currentPosition[0] + 2, currentPosition[1] + 1}, // Right then Up
                new [] {currentPosition[0] + 2, currentPosition[1] - 1}, // Right then down

                new [] {currentPosition[0] - 2, currentPosition[1] + 1}, // Left then Up
                new [] {currentPosition[0] - 2, currentPosition[1] - 1}, // Left then Down
            };

            foreach (int[] newSquare in possibleMoves)
            {

                // If the new square is on the board, add it to the list of legal moves
                if (helper.BoundsCheck(newSquare))
                {
                    Piece? _ = Board.GetPiece(helper.ConvertToString(newSquare));

                    if (_ != null && _.Color != Color)
                    {
                        // If the square is occupied by an enemy piece, add it to the list of legal moves
                        AddMove(new Move(Square,
                            helper.ConvertToString(newSquare),
                                this, true));
                    }
                    else
                    {
                        AddMove(new Move(Square,
                            helper.ConvertToString(newSquare),
                                this, false));
                    }
                }


            }
        }
    }
}
