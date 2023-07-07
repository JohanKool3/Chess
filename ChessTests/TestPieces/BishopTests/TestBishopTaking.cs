using PieceLibrary.Pieces;
using PieceLibrary.Managers;
using Xunit;

namespace Chess.Tests.TestPieces.BishopTests
{
    public class TestBishopTaking
    {
        LogicalBoard board = new ("8/8/8/3p4/2B5/8/8/8");

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
            board.LoadMoves();
            Piece? bishop = board.Contents["C4"];
            List<Move> moves = bishop.LegalMoves;
            Assert.Equal(8, moves.Count);
        }

        [Fact]
        public void Test_White_Bishop_Taking_Move_Exists()
        {
            board.LoadMoves();
            Piece? bishop = board.Contents["C4"];
            List<Move> moves = bishop.LegalMoves;

            Assert.Equal("D5", FindTakingMove(bishop)?.EndSquare);
        }

        [Fact]
        public void Test_White_Bishop_Taking_Move_To_Right_Square()
        {
            board.LoadMoves();
            Piece? bishop = board.Contents["C4"];
            Move? takingMove = FindTakingMove(bishop);
            bishop.MovePiece(takingMove);
            Assert.Equal("D5", bishop.Square);

        }

        [Fact]
        public void Test_White_Bishop_Taking_Material_Update()
        {
            board.LoadMoves();
            Piece? bishop = board.Contents["C4"];
            Move? takingMove = FindTakingMove(bishop);
            bishop.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
