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
            board.UpdateBoard();
            Assert.Equal(2, board.GetPiece("A2").LegalMoves.Count);

        }
    }
}
