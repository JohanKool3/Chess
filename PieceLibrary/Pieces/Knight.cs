using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Managers;

namespace PieceLibrary.Pieces
{
    internal class Knight : Piece
    {
        public Knight(string color, string startSquare, LogicalBoard board) : base("Knight", color, startSquare, board)
        {
            SetValue(3); // Knights are worth 3 points
            SetCode($"{char.ToUpper(color[0])}-N");
        }

        public override void GenerateMoves()
        {
            // Wipes moves from the Legal Moves List
            base.GenerateMoves();

            char currentFile = GetSquare()[0];
            int currentRank = Convert.ToInt32(char.GetNumericValue(GetSquare()[1]));

            // This is a list of all the possible moves that a knight can make

            List<string> possibleMoves = new List<string>()
            {
                $"{(char)(currentFile + 1)}{currentRank + 2}", // Up to the Right
                $"{(char)(currentFile - 1)}{currentRank + 2}", // Up to the Left

                $"{(char)(currentFile + 1)}{currentRank - 2}", // Down to the Right
                $"{(char)(currentFile - 1)}{currentRank - 2}", // Down to the Left

                $"{(char)(currentFile + 2)}{currentRank + 1}", // Right then Up
                $"{(char)(currentFile + 2)}{currentRank - 1}", // Right then down

                $"{(char)(currentFile - 2)}{currentRank + 1}", // Left then Up
                $"{(char)(currentFile - 2)}{currentRank - 1}", // Left then Down
            };

            foreach (string newSquare in possibleMoves)
            {
                AddMove(new Move(GetSquare(), newSquare, this, false));
            }


        }
    }
}
