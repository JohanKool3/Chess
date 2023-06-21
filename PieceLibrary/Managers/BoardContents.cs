using PieceLibrary.Pieces;

namespace PieceLibrary.Managers
{
    public partial class LogicalBoard
    {
        private void CreateBoard()
        {

            List<string> files = new List<string> {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H"
            };

            foreach (string file in files)
            {
                foreach (int rank in Enumerable.Range(1, 8))
                {
                    Contents.Add($"{file}{rank}", null);
                }

            }

        }
        private void AddPiece(Piece newPiece, string key)
        {
            try
            {
                Contents[key] = newPiece;
            }
            catch (Exception e)
            {
                throw new Exception("Invalid key, key must be a valid square", e);
            }
        }
        private void PopulateBoard()
        {

            // White Pawns
            for (char file = 'A'; file <= 'H'; file++)
            {
                AddPiece(new Pawn("White", $"{file}2", this), $"{file}2");
            }

            // White Rooks
            AddPiece(new Rook("White", "A1", this), "A1");
            AddPiece(new Rook("White", "H1", this), "H1");

            // White Knights
            AddPiece(new Knight("White", "B1", this), "B1");
            AddPiece(new Knight("White", "G1", this), "G1");

            // White Bishops
            AddPiece(new Bishop("White", "C1", this), "C1");
            AddPiece(new Bishop("White", "F1", this), "F1");

            // White Royalty
            AddPiece(new Queen("White", "D1", this), "D1");
            AddPiece(new King("White", "E1", this), "E1");


            // Black Pawns
            for (char file = 'A'; file <= 'H'; file++)
            {
                AddPiece(new Pawn("Black", $"{file}7", this), $"{file}7");
            }
            // Black Rooks
            AddPiece(new Rook("Black", "A8", this), "A8");
            AddPiece(new Rook("Black", "H8", this), "H8");

            // Black Knights
            AddPiece(new Knight("Black", "B8", this), "B8");
            AddPiece(new Knight("Black", "G8", this), "G8");

            // Black Bishops
            AddPiece(new Bishop("Black", "C8", this), "C8");
            AddPiece(new Bishop("Black", "F8", this), "F8");

            // Black Royalty
            AddPiece(new Queen("Black", "D8", this), "D8");
            AddPiece(new King("Black", "E8", this), "E8");



        }

        private void PopulateBoard(string FENnotation)
        {

            if (FENvalidation(FENnotation))
            {
                List<string> _ = FENnotation.Split('/').ToList();

                List<string> files = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H"
            };

                Dictionary<char, Type> pieceTypeMappings = new Dictionary<char, Type>
            {
                {'K', typeof(King)},
                {'Q', typeof(Queen)},
                {'R', typeof(Rook)},
                {'B', typeof(Bishop)},
                {'N', typeof(Knight)},
                {'P', typeof(Pawn)},
                {'k', typeof(King)},
                {'q', typeof(Queen)},
                {'r', typeof(Rook)},
                {'b', typeof(Bishop)},
                {'n', typeof(Knight)},
                {'p', typeof(Pawn)}
            };

                // For each row in the FEN notation
                int _rowIndex = 0;
                foreach (string row in _)
                {
                    int _squareIndex = 0;
                    // For each square in the row
                    foreach (char square in row)
                    {
                        if (Char.IsDigit(square))
                        {
                            // Skips the number of squares specified
                            _squareIndex += Int32.Parse(square.ToString());
                        }
                        else
                        {
                            // Populate the board accordingly
                            AddPiece((Piece)Activator.CreateInstance(pieceTypeMappings[square], new object[] { (Char.IsUpper(square) ? "White" : "Black"), $"{files[_squareIndex]}{8 - _rowIndex}", this }), $"{files[_squareIndex]}{8 - _rowIndex}");
                        }
                        _squareIndex++;
                    }
                    _rowIndex++;
                }
            }
        }

        private bool FENvalidation(string FENnotation)
        {
            List<string> _ = FENnotation.Split('/').ToList();
            List<Char> legalCharacters = new List<Char>
            {
             'K', 'Q', 'R', 'B', 'N', 'P', 'k', 'q', 'r', 'b', 'n', 'p'
            };


            // Remove Illegal Characters
            foreach (string _row in _)
            {
                foreach (char _square in _row)
                {
                    if (!Char.IsDigit(_square) && !legalCharacters.Contains(_square))
                    {
                        throw new Exception("Illegal Characters given in FEN notation");
                    }
                }
            }

            // Check if there are 8 rows
            if (_.Count != 8)
            {
                throw new Exception("Invalid FEN notation");

            }

            // Check to make sure that none of the rows exceed 8 squares
            foreach (string row in _)
            {
                int length = 0;
                foreach (char _fenSquare in row)
                {
                    if (Char.IsDigit(_fenSquare))
                    {
                        // Add the number of squares specified
                        length += Int32.Parse(_fenSquare.ToString());

                    }
                    else
                    {
                        // Normal increment if the square is a piece
                        length++;
                    }
                }
                if (length > 8)
                {
                    throw new Exception("FEN notation indicated more than 8 squares in a row");
                }
            }

            return true;
        }
    }
}
