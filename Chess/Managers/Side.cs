using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

namespace Chess.Managers
{
    internal class Side
    {
        private List<Piece> Pieces = new List<Piece>(); // Contents of the side
        private string Color; // Color of the side
        public Side(string color)
        {
            Color = color;
        }

        public void AddPiece(Piece piece)
        {
            if(piece.GetColor() == Color)
            {
                Pieces.Add(piece);
            }
        }

        public List<Move> GetAllSideMoves()
        {
            List<Move> output = new List<Move>();
            foreach(Piece piece in Pieces)
            {
                output.AddRange(piece.GetMoves());
            }

            return output;
        }
    }
}
