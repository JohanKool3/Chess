using Xunit;
using PieceLibrary.Managers;
using PieceLibrary.Pieces;

namespace ChessTests.TestPieces.PawnTests
{
    public class TestPawnTaking
    {
        private readonly LogicalBoard board = new("8/8/8/3p4/2P5/8/8/8");
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
        public void Test_White_Pawn_Move_Generation_With_Take()
        {
            board.UpdateBoard();
            Piece? pawn = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            List<Move> moves = pawn.LegalMoves;
            Assert.Equal(3, moves.Count);
        }

        [Fact]
        public void Test_White_Pawn_Taking_Move_Exists()
        {
            board.UpdateBoard();
            Piece? pawn = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");

            Assert.Equal(destinationSquare, FindTakingMove(pawn, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_Pawn_Taking_Move_To_Right_Square()
        {
            board.UpdateBoard();
            Piece? pawn = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(pawn, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            pawn.MovePiece(takingMove);
            Assert.Equal(destinationSquare, pawn.Square);

        }

        [Fact]
        public void Test_White_Pawn_Taking_Material_Update()
        {
            board.UpdateBoard();
            Piece? pawn = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(pawn, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            pawn.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
