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
            board.LoadMoves();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Empty(board.GetPiece("C1").LegalMoves);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

    }
}
