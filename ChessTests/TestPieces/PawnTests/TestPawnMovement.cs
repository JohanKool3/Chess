using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces.PawnTests
{
    public class TestPawnMovement
    {
        private readonly LogicalBoard board = new ();
        [Fact]
        public void Test_Board_Move_Load_Pawn()
        {
            board.LoadMoves();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(2, board.GetPiece("A2").LegalMoves.Count);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }
    }
}
