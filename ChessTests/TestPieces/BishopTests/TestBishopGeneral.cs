using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces
{
    public class TestBishopGeneral
    {
        private readonly LogicalBoard board = new ();
        [Fact]
        public void Test_Board_Move_Load_Bishop()
        {
            board.Update();
            Assert.Empty(board.GetPiece("C1").LegalMoves);
        }

    }
}
