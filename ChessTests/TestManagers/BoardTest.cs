using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestManagers
{
    public class BoardTest
    {

        [Fact]
        public void TestBoardSquareCreation()
        {
            // Arrange
            LogicalBoard board = new LogicalBoard();
            Assert.Equal(64, board.contents.Count);
        }
    }
}
