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

        [Fact]
        public void Test_Board_Move_Load_Pawn()
        {
            board.LoadMoves();
            Assert.Equal(2, board.GetPiece("A2").LegalMoves.Count);

        }

        [Fact]
        public void Test_Board_Move_Load_Knight()
        {
            board.LoadMoves();
            int count = board.GetPiece("B1").LegalMoves.Count;
            Assert.Equal(2, board.GetPiece("B1").LegalMoves.Count);
        }

        [Fact]
        public void Test_Board_Move_Load_Bishop()
        {
            board.LoadMoves();
            Assert.Equal(0, board.GetPiece("C1").LegalMoves.Count);
        }
    }
}
