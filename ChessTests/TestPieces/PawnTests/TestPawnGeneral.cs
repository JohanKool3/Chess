using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessTests.TestPieces.PawnTests
{
    public class TestPawnGeneral
    {
        private readonly LogicalBoard board = new ();

        [Fact]
        public void TestWhitePawnCreation()
        {
            Assert.IsType<Pawn>(board.GetPiece("A2"));
        }

        [Fact]
        public void TestBlackPawnCreation()
        {
            Assert.IsType<Pawn>(board.GetPiece("A7"));
        }
    }
}
