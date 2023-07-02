using PieceLibrary.Pieces;


namespace PieceLibrary.Managers
{
    partial class LogicalBoard
    {
        private Dictionary<string, Piece?> contents = new ();
        public Dictionary<string, Piece?> Contents { get { return contents; } }
        public List<Move> MoveOrder = new ();

        public LogicalBoard()
        {
            // Create the board
            CreateBoard();
            PopulateBoard();
        }

        public LogicalBoard(string FENNotation)
        {
            // Create the board
            CreateBoard();
            PopulateBoard(FENNotation);
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
