using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(string color, string startSquare, LogicalBoard board) : base("Bishop", color, startSquare, board)
        {
            Value = 3; // Bishops are worth 3 points
        }
    }
}
