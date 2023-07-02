using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces
{
    public class TestKnightGeneral
    {
        private readonly LogicalBoard board = new ();
        private const string Square = "D5";

        [Fact]
        public void Test_Knight_Exists()
        {
            Assert.NotNull(board.GetPiece(Square));
        }

    }
}
