using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces
{
    public class TestKnightGeneral
    {
        public LogicalBoard board = new ();
        [Fact]
        public void Test_Board_Move_Load_Knight()
        {
            board.LoadMoves();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(2, board.GetPiece("B1").LegalMoves.Count);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
