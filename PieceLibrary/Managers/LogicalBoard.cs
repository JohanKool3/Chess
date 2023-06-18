using PieceLibrary.Pieces;


namespace PieceLibrary.Managers
{
    partial class LogicalBoard
    {
        private readonly Dictionary<string, Piece?> Contents = new Dictionary<string, Piece?>();

        public Dictionary<string, Piece?> contents { get { return Contents; } }
        public List<Move> MoveOrder = new List<Move>();

        public LogicalBoard()
        {
            // Create the board
            CreateBoard();
            PopulateBoard();
        }

        public static void CustomBoardSetup()
        {
            // This method will allow the user to create a custom board setup
            // This will be used for testing purposes
        }

        public void LoadMoves()
        {
            foreach(var piece in Contents.Values)
            {
                if (piece != null)
                {
                    piece.GenerateMoves();
                }

            }
        }

    }

}
