using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces
{
    public class TestBishopGeneral
    {
        public LogicalBoard board = new ();
        [Fact]
        public void Test_Board_Move_Load_Bishop()
        {
            board.LoadMoves();
            Assert.Empty(board.GetPiece("C1").LegalMoves);
        }

    }
}
