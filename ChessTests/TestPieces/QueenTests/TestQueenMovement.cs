using Xunit;
using PieceLibrary.Managers;

namespace ChessTests.TestPieces.QueenTests
{
    public class TestClassMovement
    {
        private readonly LogicalBoard board = new("8/8/8/3Q4/8/8/8/8");
        private const string Square = "D5";

        [Fact]
        public void Test_Queen_Moves()
        {
            board.UpdateBoard();
            Assert.Equal(27, board.GetPiece(Square).LegalMoves.Count);
        }

        [Fact]
        public void Test_Queen_Moves_With_Pieces()
        {
            LogicalBoard _board = new("8/8/2PPP3/2PQP3/2PPP3/8/8/8");
            _board.UpdateBoard();

            Assert.Empty(board.GetPiece(Square).LegalMoves);
        }
    }
}
