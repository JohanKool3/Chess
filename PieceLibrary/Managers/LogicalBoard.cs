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

        public LogicalBoard(string FENnotation)
        {
            // Create the board
            CreateBoard();
            PopulateBoard(FENnotation);
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
