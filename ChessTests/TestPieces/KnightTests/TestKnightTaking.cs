using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace Chess.Tests.TestPieces.KnightTests
{
    public class TestKnightTaking
    {
        private readonly LogicalBoard board = new("8/8/3p4/P7/2N5/8/8/8");
        private readonly string destinationSquare = "D6";
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
        public void Test_White_Knight_Move_Generation_With_Take()
        {
            board.Update();
            Piece? knight = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            List<Move> moves = knight.LegalMoves;
            Assert.Equal(7, moves.Count);
        }

        [Fact]
        public void Test_White_Knight_Taking_Move_Exists()
        {
            board.Update();
            Piece? knight = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");

            Assert.Equal(destinationSquare, FindTakingMove(knight, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_Knight_Taking_Move_To_Right_Square()
        {
            board.Update();
            Piece? knight = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(knight, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            knight.MovePiece(takingMove);
            Assert.Equal(destinationSquare, knight.Square);

        }

        [Fact]
        public void Test_White_Knight_Taking_Material_Update()
        {
            board.Update();
            Piece? knight = board.Contents[startSquare] ?? throw new NullReferenceException("Piece must not be null to perform this test. Index given is null");
            Move? takingMove = FindTakingMove(knight, destinationSquare) ?? throw new NullReferenceException("Taking move must be a move in order to perform this test");
            knight.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
