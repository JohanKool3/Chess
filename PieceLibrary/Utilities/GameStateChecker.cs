using PieceLibrary.Managers;
using PieceLibrary.Pieces;

namespace Chess.PieceLibrary.Utilities
{
    public class GameStateChecker
    {
        private List<List<bool>> whiteSideControlledSquares;
        private List<List<bool>> blackSideControlledSquares;

        private readonly LogicalBoard parentBoard;
        private readonly Helper helper = new();
        internal GameStateChecker(LogicalBoard parentBoard)
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

        // TODO: Test this method
        private void UpdateControlledSquares()
        {
            parentBoard.LoadMoves(); // In case that the moves have not been loaded yet
            foreach (Piece? piece in parentBoard.Contents.Values)
            {
                if(piece is null) // Do nothing if the square is empty
                {
                    continue;
                }
                else if (piece?.Color == "White")
                {
                    foreach (Move move in piece.LegalMoves)
                    {
                        int[] position = helper.ConvertToIntegers(move.EndSquare);
                        whiteSideControlledSquares[position[0]][position[1]] = true;
                    }

                }
                else if(piece?.Color == "Black")
                {
                    foreach (Move move in piece.LegalMoves)
                    {
                        int[] position = helper.ConvertToIntegers(move.EndSquare);
                        blackSideControlledSquares[position[0]][position[1]] = true;
                    }
                }
                else
                {
                    throw new InvalidDataException($"Invalid color for piece {piece?.Color}");
                }
            }
        }
    }
}
