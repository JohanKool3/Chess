using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace Chess.Tests.TestPieces.RookTests
{
    public class TestRookTaking
    {
        private readonly LogicalBoard board = new("8/2p5/8/8/2R5/8/8/8");
        private readonly string destinationSquare = "C7";
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
        public void Test_White_Rook_Move_Generation_With_Take()
        {
            board.Update();
            Piece? rook = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            List<Move> moves = rook.LegalMoves;
            Assert.Equal(13, moves.Count);
        }

        [Fact]
        public void Test_White_Rook_Taking_Move_Exists()
        {
            board.Update();
            Piece? rook = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");

            Assert.Equal(destinationSquare, FindTakingMove(rook, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_Rook_Taking_Move_To_Right_Square()
        {
            board.Update();
            Piece? rook = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(rook, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            rook.MovePiece(takingMove);
            Assert.Equal(destinationSquare, rook.Square);

        }

        [Fact]
        public void Test_White_Rook_Taking_Material_Update()
        {
            board.Update();
            Piece? rook = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(rook, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            rook.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
