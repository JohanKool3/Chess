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
            board.LoadMoves();
            Piece? rook = board.Contents[startSquare];
            List<Move> moves = rook.LegalMoves;
            Assert.Equal(13, moves.Count);
        }

        [Fact]
        public void Test_White_Rook_Taking_Move_Exists()
        {
            board.LoadMoves();
            Piece? rook = board.Contents[startSquare];

            Assert.Equal(destinationSquare, FindTakingMove(rook, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_Rook_Taking_Move_To_Right_Square()
        {
            board.LoadMoves();
            Piece? rook = board.Contents[startSquare];
            Move? takingMove = FindTakingMove(rook, destinationSquare);
            rook.MovePiece(takingMove);
            Assert.Equal(destinationSquare, rook.Square);

        }

        [Fact]
        public void Test_White_Rook_Taking_Material_Update()
        {
            board.LoadMoves();
            Piece? rook = board.Contents[startSquare];
            Move? takingMove = FindTakingMove(rook, destinationSquare);
            rook.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
