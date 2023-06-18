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
    }
}
