using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces
{
    public class TestKnightGeneral
    {
        [Fact]
        public void Test_Board_Move_Load_Knight()
        {
            board.LoadMoves();
            Assert.Equal(2, board.GetPiece("B1").LegalMoves.Count);
        }
    }
}
