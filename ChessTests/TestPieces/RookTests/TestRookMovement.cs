using Xunit;
using PieceLibrary.Managers;

namespace ChessTests.TestPieces.RookTests
{
    public class TestRookMovement
    {
        private readonly LogicalBoard board = new("8/8/8/3R4/8/8/8/8");
        private const string Square = "D5";

        [Fact]
        public void Test_Rook_Moves()
        {
            board.LoadMoves();
            Assert.Equal(14, board.GetPiece(Square).LegalMoves.Count);
        }

        [Fact]
        public void Test_Rook_Moves_With_Pieces()
        {
            LogicalBoard _board = new("8/8/3P4/2PRP3/3P4/8/8/8");
            _board.LoadMoves();

            Assert.Empty(board.GetPiece(Square).LegalMoves);
        }

    }
}
