using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace Chess.Tests.TestPieces.KnightTests
{
    public class TestKnightTaking
    {
        LogicalBoard board = new("8/8/3p4/P7/2N5/8/8/8");

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
            board.LoadMoves();
            Piece? knight = board.Contents["C4"];
            List<Move> moves = knight.LegalMoves;
            Assert.Equal(7, moves.Count);
        }

        [Fact]
        public void Test_White_Knight_Taking_Move_Exists()
        {
            board.LoadMoves();
            Piece? knight = board.Contents["C4"];

            Assert.Equal("D6", FindTakingMove(knight, "D6")?.EndSquare);
        }

        [Fact]
        public void Test_White_Knight_Taking_Move_To_Right_Square()
        {
            board.LoadMoves();
            Piece? knight = board.Contents["C4"];
            Move? takingMove = FindTakingMove(knight, "D6");
            knight.MovePiece(takingMove);
            Assert.Equal("D6", knight.Square);

        }

        [Fact]
        public void Test_White_Knight_Taking_Material_Update()
        {
            board.LoadMoves();
            Piece? knight = board.Contents["C4"];
            Move? takingMove = FindTakingMove(knight, "D6");
            knight.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
