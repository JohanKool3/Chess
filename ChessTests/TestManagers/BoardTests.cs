using PieceLibrary.Managers;
using PieceLibrary.Pieces;
using Xunit;

namespace ChessTests.TestManagers
{
    public class BoardTests
    {
        private readonly LogicalBoard board = new ();


        [Fact]
        public void Test_Full_Board_Creation()
        {
            Assert.Equal(64, board.Contents.Count);
        }

        [Fact]
        public void Test_Correct_FEN_Parsing()
        {
            string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            LogicalBoard board2 = new LogicalBoard(FEN);

            int matches = 0;
            foreach (var content in board.Contents.Keys)
            {
                var square1 = board.Contents[content];
                var square2 = board2.Contents[content];
                if (board.Contents[content] is null)
                {
                    if (square1 == null &&  square2 == null)
                    {
                        matches++;
                    }
                }

                else if (square1?.PieceCode == square2?.PieceCode)
                {
                    matches++;
                }

            }

            Assert.Equal(64, matches);
        }

        [Fact]
        public void Test_Invalid_FEN_Parsing_Illegal_Character()
        {
            string FEN = "rnbqkbnr/tppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            Assert.Throws<Exception>(() => new LogicalBoard(FEN));
        }

        [Fact]
        public void Test_Invalid_FEN_Parsing_Excessive_Length()
        {
            string FEN = "rnbqkbnr/pppppppp/9/8/8/8/PPPPPPPP/RNBQKBNRR";
            Assert.Throws<Exception>(() => new LogicalBoard(FEN));
        }

        [Fact]
        public void Test_Correct_Material_Calculation()
        {
            Assert.Equal(board.Material, new int[] {39, 39});
        }
    }
}
