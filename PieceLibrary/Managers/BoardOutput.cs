using Microsoft.VisualBasic;
using PieceLibrary.Pieces;
using System.Runtime.CompilerServices;

namespace PieceLibrary.Managers
{
    public partial class  LogicalBoard
    {

        /// <summary>
        /// Displays the board in the console.
        /// </summary>
        public void DisplayBoard()
        {
            string _rankSeperator = "\n ------------------------------------------------";


            for (int rank = 8; rank > 0; rank--)
            {
                foreach (string file in helper.Files)
                {
                    string square = $"{file}{rank}"; //Creates the key of the square to be displayed

                    Piece? piece = contents[square]; // Fetches the contents of that square
                    string output = "";


                    // If the file is A, it is the first file and the rank should be displayed
                    if (file == "A")
                    {
                        output += Convert.ToString(rank);
                    }

                    // Empty Square
                    if (piece == null)
                    {
                        Console.Write($"{output}(   )|");
                    }

                    // Square with a piece in it
                    else
                    {
                        Console.Write($"{output}({piece.PieceCode})|");
                    }
                }
                Console.WriteLine(_rankSeperator);
            }
            foreach (string file in helper.Files)
            {
                Console.Write($"   {file}  ");
            }
            Console.WriteLine();

        }
        public void DisplayMaterial()
        {
            Console.WriteLine($"White Material: {Material[0]}");
            Console.WriteLine($"Black Material: {Material[1]}");
        }
        public List<Piece> GetBlackPieces()
        {
            List<Piece> blackPieces = new ();

            foreach (Piece? piece in contents.Values)
            {
                if (piece != null)
                {
                    if (piece.Color == "Black")
                    {
                        blackPieces.Add(piece);
                    }

                }
            }

            return blackPieces;
        }

        public List<Piece> GetWhitePieces()
        {
            List<Piece> whitePieces = new ();
            foreach (Piece? piece in contents.Values)
            {
                if (piece != null)
                {
                    if (piece.Color == "White")
                    {
                        whitePieces.Add(piece);
                    }
                }
            }
            return whitePieces;
        }

        public Piece GetPiece(string square)
        {
            try
            {
                return contents[square]!;
            }
            catch
            {
                throw new KeyNotFoundException($"Invalid key, key must be a valid square {square}");
            }
        }

    }
}
