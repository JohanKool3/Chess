using Microsoft.VisualBasic;
using PieceLibrary.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceLibrary.Managers
{
    public partial class  LogicalBoard
    {
        public void DisplayBoard()
        {
            // This method will display the contents that are currently stored inside of this object in a board layout

            // Iterates through the ranks from last to first
            for (int rank = 8; rank > 0; rank--)
            {
                // Iterates through the files from first to last
                for (char file = 'A'; file <= 'H'; file++)
                {
                    string square = $"{file}{rank}"; //Creates the key of the square to be displayed

                    Piece? piece = Contents[square]; // Fetches the contents of that square
                    string output = "";

                    // Adds readouts for the Ranks
                    if (file == 'A')
                    {
                        output += Convert.ToString(rank);
                    }
                    if (piece == null)
                    {
                        Console.Write($"{output}(   )|");
                    }
                    else
                    {
                        Console.Write($"{output}({piece.PieceCode})|");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(" ------------------------------------------------");
            }
            for (char file = 'A'; file <= 'H'; file++)
            {
                Console.Write($"   {file}  ");
            }
            Console.WriteLine();

        }

        public List<Piece> GetBlackPieces()
        {
            List<Piece> blackPieces = new List<Piece>();

            foreach (Piece piece in Contents.Values)
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
            List<Piece> whitePieces = new List<Piece>();
            foreach (Piece piece in Contents.Values)
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

        public Piece GetPiece(string square) => Contents[square] ?? throw new Exception("No piece found at that square");
    }
}
