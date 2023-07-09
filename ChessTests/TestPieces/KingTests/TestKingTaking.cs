using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chess.Tests.TestPieces.KingTests
{
    public class TestKingTaking
    {
        private readonly LogicalBoard board = new("8/8/8/3n4/1PK5/8/8/8");
        private readonly string destinationSquare = "D5";
        private readonly string startSquare = "C4";

        private static Move? FindTakingMove(Piece pieceIn, string endSquare)
        {
            foreach (Move move in pieceIn.LegalMoves)
            {
                if (move.EndSquare == endSquare)
                {
                    return move;
                }
            }
            return null;
        }

        [Fact]
        public void Test_White_King_Move_Generation_With_Take()
        {
            board.Update();
            Piece? king = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            List<Move> moves = king.LegalMoves;
            Assert.Equal(7, moves.Count);
        }

        [Fact]
        public void Test_White_King_Taking_Move_Exists()
        {
            board.Update();
            Piece? king = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");

            Assert.Equal(destinationSquare, FindTakingMove(king, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_King_Taking_Move_To_Right_Square()
        {
            board.Update();
            Piece? king = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(king, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            king.MovePiece(takingMove);
            Assert.Equal(destinationSquare, king.Square);

        }

        [Fact]
        public void Test_White_King_Taking_Material_Update()
        {
            board.Update();
            Piece? king = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(king, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            king.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
