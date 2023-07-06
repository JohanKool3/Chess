using Xunit;
using PieceLibrary.Managers;
using PieceLibrary.Pieces;

namespace ChessTests.TestPieces.PawnTests
{
    public class TestPawnTaking
    {
        private readonly LogicalBoard board = new("8/8/8/8/3p4/2P5/8/8");

        [Fact]
        public void Test_White_Pawn_Move_Generation_With_Take()
        {
            board.LoadMoves();
            Piece? pawn = board.Contents["C3"];
            List<Move> moves = pawn.LegalMoves;
            Assert.Equal(3, moves.Count);
        }

        [Fact]
        public void Test_White_Pawn_Taking_Move_Exists()
        {
            board.LoadMoves();
            Piece? pawn = board.Contents["C3"];
            List<Move> moves = pawn.LegalMoves;

            Assert.Equal("D4", moves[2].EndSquare);
        }

        [Fact]
        public void Test_White_Pawn_Taking_Move_To_Right_Square()
        {
            board.LoadMoves();
            Piece? pawn = board.Contents["C3"];
            Move takingMove = pawn.LegalMoves[2];
            pawn.MovePiece(takingMove);
            Assert.Equal("D4", pawn.Square);

        }

        [Fact]
        public void Test_White_Pawn_Taking_Material_Update()
        {
            board.LoadMoves();
            Piece? pawn = board.Contents["C3"];
            Move takingMove = pawn.LegalMoves[2];
            pawn.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
