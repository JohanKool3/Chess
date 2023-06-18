using PieceLibrary.Managers;
using Xunit;

namespace ChessTests.TestManagers
{
    public class SideTest
    {
        public LogicalBoard board = new LogicalBoard();

        [Fact]
        public void TestWhiteSideCreation()
        {
            Assert.IsType<Side>(board.returnWhitePieces);
        }

        [Fact]
        public void TestBlackSideCreation()
        {
            Assert.IsType<Side>(board.returnBlackPieces);
        }
    }
}
