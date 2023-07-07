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
            board.UpdateBoard();
            Piece? knight = board.Contents[startSquare];
            List<Move> moves = knight.LegalMoves;
            Assert.Equal(7, moves.Count);
        }

        [Fact]
        public void Test_White_Knight_Taking_Move_Exists()
        {
            board.UpdateBoard();
            Piece? knight = board.Contents[startSquare];

            Assert.Equal(destinationSquare, FindTakingMove(knight, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_Knight_Taking_Move_To_Right_Square()
        {
            board.UpdateBoard();
            Piece? knight = board.Contents[startSquare];
            Move? takingMove = FindTakingMove(knight, destinationSquare);
            knight.MovePiece(takingMove);
            Assert.Equal(destinationSquare, knight.Square);

        }

        [Fact]
        public void Test_White_Knight_Taking_Material_Update()
        {
            board.UpdateBoard();
            Piece? knight = board.Contents[startSquare];
            Move? takingMove = FindTakingMove(knight, destinationSquare);
            knight.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
