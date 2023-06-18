using PieceLibrary.Pieces;
using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestPieces
{
    public class TestPawn
    {
        public LogicalBoard board = new LogicalBoard();

        [Fact]
        public void TestWhitePawnCreation()
        {
            Assert.IsType<Pawn>(board.GetPiece("A2"));
        }

        [Fact]
        public void TestBlackPawnCreation()
        {
            Assert.IsType<Pawn>(board.GetPiece("A7"));
        }

    }
}
