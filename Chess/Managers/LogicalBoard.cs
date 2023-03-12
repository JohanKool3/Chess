using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

namespace Chess.Managers
{
    internal class LogicalBoard
    {
        private Dictionary<string, Piece> contents = new Dictionary<string, Piece>();

        private void createBoard()
        {
            List<string> ranks = new List<string>();
            ranks.Add("A");
            ranks.Add("B");
            ranks.Add("C");
            ranks.Add("D");
            ranks.Add("E");
            ranks.Add("F");
            ranks.Add("G");
            ranks.Add("H");

            foreach(string file in ranks)
            {
                foreach(int rank in Enumerable.Range(1, 8))
                {
                    contents.Add($"{file}{rank}", null);
                }
            }

        }

        private void addPiece(Piece newPiece, string key)
        {
            try
            {
                contents[key] = newPiece;
            }
            catch
            {
                Console.Write($"Key {key} is not compatable");
            }
        }
        private void populateBoard()
        {
            // White Pawns
            for (char file = 'A'; file <= 'H'; file ++)
            {
                addPiece(new Pawn("White", $"{file}2"), $"{file}2");
            }

            // Black Pawns
            for(char file = 'A'; file <= 'H'; file++)
            {
                addPiece(new Pawn("Black", $"{file}7"), $"{file}7");
            }
            
        }
        public LogicalBoard()
        {
            // Create the board
            createBoard();
            populateBoard();
            displayBoard();
        }

        public void customBoardSetup()
        {
        }

        public void displayBoard() 
        { 
            // This method will display the contents that are currently stored inside of this object in a board layout

            // Iterates through the ranks from last to first
            for(int rank = 8; rank > 0; rank--)
            {
                // Iterates through the files from first to last
                for(char file = 'A'; file <= 'H'; file++)
                {
                    string square = $"{file}{rank}"; //Creates the key of the square to be displayed

                    Piece piece = contents[square]; // Fetches the contents of that square
                    string output = "";

                    // Adds readouts for the Ranks
                    if(file == 'A')
                    {
                        output += Convert.ToString(rank);
                    }
                    if (piece == null)
                    {
                        Console.Write($"{output}(   )|");
                    }
                    else
                    {
                        Console.Write($"{output}({piece.getPieceCode()})|");
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
    }
}
