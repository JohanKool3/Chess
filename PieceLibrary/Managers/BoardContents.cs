using PieceLibrary.Pieces;

namespace PieceLibrary.Managers
{
    public partial class LogicalBoard
    {
        /// <summary>
        /// <para>Creates the Board and makes each square Null</para>
        /// </summary>
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

        /// <summary>
        /// Adds a piece otherwise throws an exception
        /// </summary>
        /// <param name="newPiece">The piece that is being added</param>
        /// <param name="key">The square the piece will be located in</param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// <para> This method is used to populate the chess board with the standard starting position</para>
        /// </summary>
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

        /// <summary>
        /// <para> This method is used to import a position represented in FEN into the chess board</para>
        /// <param name="FENnotation">A string representing the FEN notation of a chess board</param>
        /// </summary>
        private void PopulateBoard(string FENnotation)
        {
            if (FENvalidation(FENnotation))
            {
                #region Important Variables
                List<string> _rows = FENnotation.Split('/').ToList();

                List<string> _files = new ()
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

                Dictionary<char, Type> _pieceTypeMappings = new Dictionary<char, Type>
            {
                {'K' , typeof(King)},
                {'Q', typeof(Queen)},
                {'R', typeof(Rook)},
                {'B', typeof(Bishop)},
                {'N', typeof(Knight)},
                {'P', typeof(Pawn)},
            };

                #endregion


                // Rank starts at 8
                int _rank = 8;
                foreach (string row in _rows) // Scans each row from the initial notation input
                {
                    int _fileIndex = 0; // Scans from File A -> H

                    // For each instruction in the row
                    foreach (char instruction in row)
                    {
                        if (Char.IsDigit(instruction))
                        {
                            // Skips the number of squares specified
                            _fileIndex += Int32.Parse(instruction.ToString());
                        }
                        else
                        {

                            // Populate the board accordingly
                            string _colour = (Char.IsUpper(instruction))
                                ? "White"
                                : "Black";

                            Type _type = _pieceTypeMappings[Char.ToUpper(instruction)];

                            if (Activator.CreateInstance(_type,
                                _colour,
                                $"{_files[_fileIndex]}{_rank}",
                                this) is Piece newPiece)

                                AddPiece(newPiece, $"{_files[_fileIndex]}{_rank}");
                            _fileIndex++;
                        }
                    }
                    _rank--;
                }
            }
        }

        /// <summary>
        /// <param name="FENnotation">Standardized notation of a given position</param>
        /// <para></para>
        /// <exception cref="Exception">Returns information about which part of the validation process went wrong</exception>
        /// </summary>
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
