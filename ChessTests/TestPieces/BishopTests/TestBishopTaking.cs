using PieceLibrary.Pieces;
using PieceLibrary.Managers;
using Xunit;
using Newtonsoft.Json;

namespace Chess.Tests.TestPieces.BishopTests
{
    public class TestBishopTaking
    {
        private readonly LogicalBoard board = new ("8/8/8/3p4/2B5/8/8/8");

        private static Move? FindTakingMove(Piece pieceIn)
        {
            foreach (Move move in pieceIn.LegalMoves)
            {
                if (move.EndSquare == "D5")
                {
                    return move;
                }
            }
            return null;
        }
        [Fact]
        public void Test_White_Bishop_Move_Generation_With_Take()
        {
            board.UpdateBoard();
            Piece? bishop = board.Contents["C4"] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            List<Move> moves = bishop.LegalMoves;
            Assert.Equal(8, moves.Count);
        }

        [Fact]
        public void Test_White_Bishop_Taking_Move_Exists()
        {
            board.UpdateBoard();
            Piece? bishop = board.Contents["C4"] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");

            Assert.Equal("D5", FindTakingMove(bishop)?.EndSquare);
        }

        [Fact]
        public void Test_White_Bishop_Taking_Move_To_Right_Square()
        {
            board.UpdateBoard();
            Piece? bishop = board.Contents["C4"] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move takingMove = FindTakingMove(bishop) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test. No taking move has been found");
            bishop.MovePiece(takingMove);
            Assert.Equal("D5", bishop.Square);

        }

        [Fact]
        public void Test_White_Bishop_Taking_Material_Update()
        {
            board.UpdateBoard();
            Piece? bishop = board.Contents["C4"] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(bishop) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            bishop.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
