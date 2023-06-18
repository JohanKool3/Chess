using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieceLibrary.Pieces;

namespace PieceLibrary.Managers
{
    public class Side
    {
        private List<Piece> Pieces = new List<Piece>(); // Contents of the side
        private readonly string Color; // Color of the side
        private Piece? King = null;
        public Side(string color)
        {
            Color = color;
        }
        public void AddPiece(Piece piece)
        {
            if(piece.Color == Color)
            {
                Pieces.Add(piece);

                if (King == null && (piece.PieceCode == "W-K" || piece.PieceCode == "B-K"))
                {
                    King = piece;
                }
            }
        }

        public List<Move> GetAllSideMoves()
        {
            List<Move> output = new List<Move>();
            foreach(Piece piece in Pieces)
            {
                output.AddRange(piece.LegalMoves);
            }

            return output;
        }
    }
}
