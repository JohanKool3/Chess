using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace ChessTests.TestManagers
{
    public class BoardTests
    {
        public LogicalBoard board = new ();

        private bool Test_Null_Board_Creation()
        {
            return board == null;
        }

        [Fact]
        public void Test_Full_Board_Creation()
        {
            Assert.Equal(64, board.Contents.Count);
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
            Assert.Equal(2, board.GetPiece("B1").LegalMoves.Count);
        }

        [Fact]
        public void Test_Board_Move_Load_Bishop()
        {
            board.LoadMoves();
            Assert.Empty(board.GetPiece("C1").LegalMoves);
        }

        [Fact]
        public void Test_Correct_FEN_Parsing()
        {
            string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            LogicalBoard board2 = new LogicalBoard(FEN);

            foreach (var content in board.Contents.Keys)
            {
                if (board.Contents[content] != null)
                {
                    if (board.Contents[content].GetType() != board2.Contents[content].GetType())
                    {
                        Assert.False(true);
                    }
                }

            }
            Assert.True(true);
        }

        [Fact]
        public void Test_Invalid_FEN_Parsing_Illegal_Character()
        {
            string FEN = "rnbqkbnr/tppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            Assert.Throws<Exception>(() => new LogicalBoard(FEN));
        }

        [Fact]
        public void Test_Invalid_FEN_Parsing_Excessive_Length()
        {
            string FEN = "rnbqkbnr/pppppppp/9/8/8/8/PPPPPPPP/RNBQKBNRR";
            Assert.Throws<Exception>(() => new LogicalBoard(FEN));
        }
    }
}
