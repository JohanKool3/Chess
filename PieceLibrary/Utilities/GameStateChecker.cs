using PieceLibrary.Managers;
using PieceLibrary.Pieces;

namespace Chess.PieceLibrary.Utilities
{
    public class GameStateChecker
    {
        private readonly List<List<bool>> whiteSideControlledSquares;
        private readonly List<List<bool>> blackSideControlledSquares;
        public List<List<bool>>? WhiteControlledSquares { get; }
        public List<List<bool>>? BlackControlledSquares { get; }

        private readonly LogicalBoard parentBoard;
        private readonly Helper helper = new();
        public GameStateChecker(LogicalBoard parentBoard)
        {
            this.parentBoard = parentBoard;

            whiteSideControlledSquares = GenerateControlledGrid();
            blackSideControlledSquares = GenerateControlledGrid();
    }

        private List<List<bool>> GenerateControlledGrid()
        {
            List<List<bool>> grid = new();

            for(int rank = 0; rank < 8; rank++)
            {
                List<bool> row = new();
                foreach (string file in helper.Files)
                {
                    row.Add(false);
                }

                grid.Add(row);
            }

            return grid;
        }


        public void Update()
        {
            UpdateControlledSquares();
        }

        // TODO: Test this method
        private void UpdateControlledSquares()
        {
            parentBoard.LoadMoves(); // In case that the moves have not been loaded yet

            // TODO: Update the controlled squares to be equal to the squares that a piece can take in, in a given position
            // Disregard En Passant for this calculation.
        }
    }
}
