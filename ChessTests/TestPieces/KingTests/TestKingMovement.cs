using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces.KingTests
{
    public class TestKingMovement
    {
        private readonly LogicalBoard board = new("8/8/8/3K4/8/8/8/8");
        private const string square = "D5";

        [Fact]
        public void Test_King_Move_Generation()
        {
            board.UpdateBoard();
            Assert.Equal(8, board.GetPiece(square).LegalMoves.Count);
        }

        [Fact]
        public void Test_King_Move_Generation_With_Pieces()
        {
            LogicalBoard _board = new("8/8/2PPP3/2PKP3/2PPP3/8/8/8");
            Assert.Empty(_board.GetPiece(square).LegalMoves);
        }
    }
}
