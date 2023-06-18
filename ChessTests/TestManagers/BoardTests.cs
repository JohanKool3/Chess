using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace ChessTests.TestManagers
{
    public class BoardTests
    {
        public LogicalBoard board = new LogicalBoard();

        [Fact]
        public void Test_Full_Board_Creation()
        {
            Assert.Equal(64, board.contents.Count);
        }

        [Fact]
        public void Test_Pawn_Creation()
        {
            Assert.IsType<Pawn>(board.GetPiece("A2"));
        }

        [Fact]
        public void Test_White_Piece_Creation()
        {
            Assert.Equal(16, board.GetWhitePieces().Count);
        }

        [Fact]
        public void Test_Black_Piece_Creation()
        {
            Assert.Equal(16, board.GetBlackPieces().Count);
        }
    }
}
