using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces.PawnTests
{
    public class TestPawnMovement
    {
        public LogicalBoard board = new ();
        [Fact]
        public void Test_Board_Move_Load_Pawn()
        {
            board.LoadMoves();

            Assert.Equal(2, board.GetPiece("A2").LegalMoves.Count);

        }
    }
}
