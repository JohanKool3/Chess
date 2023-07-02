
using Xunit;
using PieceLibrary.Managers;

namespace ChessTests.TestPieces
{
    public class TestRookGeneral
    {
        private readonly LogicalBoard board = new();
        [Fact]
        public void Test_Board_Move_Load_Rook()
        {
            board.LoadMoves();
        }
    }
}
