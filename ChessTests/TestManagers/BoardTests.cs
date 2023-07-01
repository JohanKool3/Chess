using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace ChessTests.TestManagers
{
    public class BoardTests
    {
        public LogicalBoard board = new ();


        [Fact]
        public void Test_Full_Board_Creation()
        {
            Assert.Equal(64, board.Contents.Count);
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
