using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestManagers
{
    public class BoardTest
    {
        public LogicalBoard board = new LogicalBoard();

        [Fact]
        public void TestBoardSquareCreation()
        {
            Assert.Equal(64, board.contents.Count);
        }

        [Fact]
        public void TestBoardPieceAddition()
        {
            int count = 0;

            foreach(var piece in board.contents)
            {
                if (piece.Value != null)
                {
                    count++;
                }
            }

            Assert.Equal(32, count);
        }

        [Fact]
        public void TestBoardPieceRemoval()
        {
            board.contents["A2"] = null;
            board.contents["A7"] = null;

            int count = 0;

            foreach (var piece in board.contents)
            {
                if (piece.Value != null)
                {
                    count++;
                }
            }

            Assert.Equal(30, count);
        }
    }
}
