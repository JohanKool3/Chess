using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace Chess.Tests.TestPieces.QueenTests
{
    public class TestQueenTaking
    {
        private readonly LogicalBoard board = new("8/2p5/8/8/2Q5/8/8/8");
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
        public void Test_White_Queen_Move_Generation_With_Take()
        {
            board.LoadMoves();
            Piece? queen = board.Contents[startSquare];
            List<Move> moves = queen.LegalMoves;
            Assert.Equal(24, moves.Count);
        }

        [Fact]
        public void Test_White_Queen_Taking_Move_Exists()
        {
            board.LoadMoves();
            Piece? queen = board.Contents[startSquare];

            Assert.Equal(destinationSquare, FindTakingMove(queen, destinationSquare)?.EndSquare);
        }

        [Fact]
        public void Test_White_Queen_Taking_Move_To_Right_Square()
        {
            board.LoadMoves();
            Piece? queen = board.Contents[startSquare];
            Move? takingMove = FindTakingMove(queen, destinationSquare);
            queen.MovePiece(takingMove);
            Assert.Equal(destinationSquare, queen.Square);

        }

        [Fact]
        public void Test_White_Queen_Taking_Material_Update()
        {
            board.LoadMoves();
            Piece? queen = board.Contents[startSquare];
            Move? takingMove = FindTakingMove(queen, destinationSquare);
            queen.MovePiece(takingMove);
            Assert.Equal(0, board.Material[1]);
        }
    }
}
