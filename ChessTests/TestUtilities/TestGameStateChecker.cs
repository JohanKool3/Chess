using Xunit;
using PieceLibrary.Managers;


namespace Chess.Tests.TestUtilities
{
    public class TestGameStateChecker
    {
        private static readonly LogicalBoard board = new();

        [Fact]
        public void Test_Initialization_GameStateChecker_Controlled_Squares_White()
        {
            Assert.Equal(8, board.GameStateChecker.ControlledSquares[0].Count);
            Assert.Equal(8, board.GameStateChecker.ControlledSquares[0][0].Count);
        }

        [Fact]
        public void Test_Initialization_GameStateChecker_Controlled_Squares_Black()
        {
            Assert.Equal(8, board.GameStateChecker.ControlledSquares[1].Count);
            Assert.Equal(8, board.GameStateChecker.ControlledSquares[1][0].Count);
        }
        [Fact]
        public void Test_Load_Controlled_Squares_White()
        {
            board.Update();
            Assert.Equal(20, board.GameStateChecker.ControlledSquares[0].Count);
            Assert.Equal(20, board.GameStateChecker.ControlledSquares[0][0].Count);
        }

    }
}
