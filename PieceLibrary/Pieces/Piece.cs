using Chess.PieceLibrary.Utilities;
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
        public int? Value { get; set; } // The material value of the given chess piece
        public string Square { get; set; } // The key of the square that the piece is on (using the notation of the board)
        protected List<Move> legalMoves = new (); // The moves that the piece can make that abide by the rules of chess
        public List<Move> LegalMoves { get { return legalMoves; } }

        public List<Move> TakingMoves
        {
            get
            {   List<Move> output = new();
                foreach(Move move in LegalMoves)
                {
                    if(move.Capture)
                    {
                        output.Add(move);
                    }
                }
                return output;
            }
        }

        protected readonly Helper helper = new();
        protected LogicalBoard Board; //Reference to the Board object

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

        /// <summary>
        /// This method is used to Check moves to make sure that they are valid and can be added to the 'LegalMoves' list
        /// </summary>
        /// <param name="move">The move to be checked</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private bool CheckValidMove(Move move)
        {
            bool valid = true; // Move is Valid

            if(move == null)
            {
                throw new ArgumentNullException($"Null argument passed to CheckValidMove ,Value:{move}");
            }

            if (move.EndSquare.Length > 2  // The move is comprised of more than a rank and file
                || move.EndSquare[0] < 'A' // If the move is out of the bounds of the Files
                || move.EndSquare[0] > 'H'
                || move.EndSquare[1] < '1' // If the move is out of the bounds of the Ranks
                || move.EndSquare[1] > '8')
            {
                return false;
            }

            // If the move puts the friendly king into check

            if (Board?.GetPiece(move.EndSquare) is Piece piece)
            {
                // If the move is blocked by a friendly piece
                if (piece.Color == Color)
                {
                    valid = false;
                }

                // If the move is blocked by an enemy piece and the move is not a capture
                if (piece.Color != Color && !move.Capture)
                {
                    valid = false;
                }

            }
            return valid;
        }

        public virtual void MovePiece(Move move)
        {
            // If the move isn't legal
            if (LegalMoves.Contains(move) is false)
            {

            }

            else if (move.Capture is false) // Normal Movement
            {
                Square = move.EndSquare;
                Board.MoveOrder.Add(move);
            }

            else if (move.Capture) // Capture a Piece
            {
                Board.CalculateMaterial(move);
                Board.RemovePiece(move.EndSquare);

                Square = move.EndSquare;
                Board.MoveOrder.Add(move);
            }
        }

        protected void AddMove(Move move)
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
