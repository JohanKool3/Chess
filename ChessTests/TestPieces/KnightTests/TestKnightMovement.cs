using PieceLibrary.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessTests.TestPieces.KnightTests
{
    public class TestKnightMovement
    {
        private readonly LogicalBoard board = new("8/8/8/3N4/8/8/8/8");
        private const string Square = "D5";

        [Fact]
        public void Test_Knight_Moves()
        {
            board.Update();
            Assert.Equal(8, board.GetPiece(Square).LegalMoves.Count);
        }

        [Fact]
        public void Test_Edge_Move_Cases()
        {
            LogicalBoard _ = new("8/8/8/8/8/8/8/1N6");
            _.Update();
            Assert.Equal(3, _.GetPiece("B1").LegalMoves.Count);
        }

        [Fact]
        public void Test_Blocked_Move_Cases()
        {
            LogicalBoard _ = new("8/2P1P3/1P3P2/3N4/1P3P2/2P1P3/8/8");
            _.Update();
            Assert.Empty(_.GetPiece("D5").LegalMoves);
        }

        [Fact]
        public void Test_Knight_Take_Cases()
        {
            LogicalBoard _ = new("8/2p1P3/1p3P2/3N4/1p3P2/2p1P3/8/8");
            _.Update();
            Assert.Equal(4, _.GetPiece("D5").TakingMoves.Count);
        }
    }
}
