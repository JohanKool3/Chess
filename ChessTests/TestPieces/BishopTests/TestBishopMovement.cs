using Xunit;
using PieceLibrary.Managers;
using PieceLibrary.Pieces;

namespace ChessTests.TestPieces.BishopTests
{
    public class TestBishopMovement
    {
        private const string Square = "D5";
        public LogicalBoard board = new("8/8/8/3b4/8/8/8/8");

        [Fact]
        public void Test_Board_Move_Load_Bishop()
        {
            board.LoadMoves();
        }

        [Fact]
        public void Test_Bishop_Exists()
        {
            Assert.IsType<Bishop>(board.GetPiece(Square));

        }

        //[Fact]
        //public void Test_Bishop_Moves()
        //{
        //    board.LoadMoves();
        //    Assert.Equal(13, board.GetPiece(Square).LegalMoves.Count);
        //}

    }
}
