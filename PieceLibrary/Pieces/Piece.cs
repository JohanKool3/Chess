using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    public class Piece
    {
        /// <summary>
        /// Standard chess piece
        ///</summary>
        public string Color { get; } // The color of the piece (either "White" or "Black")
        public string PieceCode { get; set; } // The code of the piece (format is "wK" for white king)
        protected int? Value { get; set; } // The material value of the given chess piece
        protected string Square { get; set; } // The key of the square that the piece is on (using the notation of the board)
        public List<Move> LegalMoves = new List<Move>(); // The moves that the piece can make that abide by the rules of chess

        private LogicalBoard Board; //Reference to the Board object

        // Constructor
        protected Piece(string piece, string color, string startSquare, LogicalBoard board)
        {
            // Cannot have null values for any of these parameters
            if(piece == null || color == null || startSquare == null|| board == null)
            {
                throw new ArgumentNullException("Null argument passed to Piece constructor");
            }

            PieceCode = $"{char.ToUpper(color[0])}-{char.ToUpper(piece[0])}"; // e.g. White King "W-K"
            Color = color;
            Square = startSquare;
            Board = board;
        }

        public override string ToString()
        {
            return PieceCode;
        }

        // Special Methods
        private bool CheckValidMove(Move move)
        {
            bool valid = true;

            if(move == null)
            {
                throw new ArgumentNullException("Null argument passed to CheckValidMove");
            }

            // If the move is out of bounds
            if (move.EndSquare.Length > 2 || move.EndSquare[0] < 'A' || move.EndSquare[0] > 'H' || move.EndSquare[1] < '1' || move.EndSquare[1] > '8')
            {
                valid = false;
            }

            // If the move puts the friendly king into check

            if (Board.GetPiece(move.EndSquare) is not null)
            {
                if (Board.GetPiece(move.EndSquare).Color == Color)
                {
                    valid = false;
                }
                // If the move is blocked by an enemy piece and the move is not a capture
                if (Board.GetPiece(move.EndSquare).Color != Color && !move.Capture)
                {
                    valid = false;
                }

            }
            return valid;
        }

        public virtual void MovePiece(Move move)
        { // This method is purely to update the attributes inside of the piece, Board updates will be done inside of the 'LogicalBoard' object
            if (LegalMoves.Contains(move))
            {
                Square = move.EndSquare; // Sets the square of the piece to the destination square
            }
        }

        public void AddMove(Move move)
        {
            if (CheckValidMove(move))
            {
                LegalMoves.Add(move);
            }
        }

        public virtual void GenerateMoves()
        {
            // This method is overridden in the child classes
            LegalMoves.Clear();
        }

    }
}
