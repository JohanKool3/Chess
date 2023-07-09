using PieceLibrary.Pieces;


namespace PieceLibrary.Managers
{
    partial class LogicalBoard
    {
        private Dictionary<string, Piece?> contents = new ();
        public Dictionary<string, Piece?> Contents { get { return contents; } }
        public List<Move> MoveOrder = new ();
        public int[] Material = new int[2] {0, 0}; // 0 = White, 1 = Black

        /// <summary>
        /// Creates the board without having a FEN notation string given.
        /// </summary>
        public LogicalBoard()
        {
            // Create the board
            CreateBoard();
            PopulateBoard();
            CalculateMaterial();
        }

        /// <summary>
        /// Creates a board from a FEN notation string.
        /// </summary>
        /// <param name="FENNotation"></param>
        public LogicalBoard(string FENNotation)
        {
            // Create the board
            CreateBoard();
            PopulateBoard(FENNotation);
            CalculateMaterial();
        }


        /// <summary>
        /// Updates the board with current moves and also performs a check to see if the king is in check, checkmate or stalemate.
        /// </summary>
        public void UpdateBoard()
        {

            // To be able to effectively update the board, we need to:
            // 1. Check for checkmate, check, stalemate
            // 2. Update the board with the current moves

            // Check for checkmate, check, stalemate
            string? gameState = DetectGameState();

            LoadMoves();

        }

        /// <summary>
        /// Calculates all of the material in the board.
        /// </summary>
        internal void CalculateMaterial()
        {
            Material[0] = 0;
            Material[1] = 0;


            foreach(Piece? piece in contents.Values)
            {
                int value = piece?.Value ?? 0;

                if(piece?.Color == "White")
                {
                    Material[0] += value;
                }
                else
                {
                    Material[1] += value;
                }
            }
        }

        /// <summary>
        /// Calculates the material after a given move is made.
        /// </summary>
        /// <param name="move"></param>
        internal void CalculateMaterial(Move move)
        {

            // Check to make sure there is a piece at the end square, prevents a null reference exception
            Piece takenPiece = GetPiece(move.EndSquare) ??
                throw new Exception("No piece found at end square");

            int takenPieceValue = takenPiece.Value ??
                throw new Exception("The king Shouldn't be able to be taken!"); // Again, another catch for if a King is taken

            // If the taking piece is white
            if(move.Piece.Color == "White")
            {
                Material[1] -= takenPieceValue;
            }
            else
            {
                Material[0] -= takenPieceValue;
            }
        }

        internal void LoadMoves()
        {
            foreach (var piece in contents.Values)
            {
                piece?.GenerateMoves();

            }
        }

        /// <summary>
        /// This method is used to check if the king is in check or checkmate
        /// </summary>
        /// <returns></returns>
        private string? DetectGameState()
        {
            return null;
        }
    }

}
