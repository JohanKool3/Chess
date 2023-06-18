using PieceLibrary.Pieces;


namespace PieceLibrary.Managers
{
    partial class LogicalBoard
    {
        private Dictionary<string, Piece?> contents = new Dictionary<string, Piece?>();
        public Dictionary<string, Piece?> Contents { get { return contents; } }
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
            foreach(var piece in contents.Values)
            {
                if (piece != null)
                {
                    piece.GenerateMoves();
                }

            }
        }

    }

}
