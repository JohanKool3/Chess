using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceLibrary
{
    public class Helper
    {
        // Constant readonly values that can be used throughout the program
        public readonly List<string> Files = new ()
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

        public int[] ConvertToIntegers(string square)
        {
            if(square.Length > 2)
            {
                throw new Exception("Invalid square, square must be a valid square");
            }

            int fileNum = Files.IndexOf(square[0].ToString()) + 1;
            int rank = Convert.ToInt32(char.GetNumericValue(square[1]));

            int[] output = new [] { fileNum, rank };

            return output;
        }

        public string ConvertToString(int[] integersIn)
            => $"{Files[integersIn[0] - 1]}{integersIn[1]}";

        public bool BoundsCheck(int[] integersIn)
            => integersIn[0] > 0 && integersIn[0] < 9 && integersIn[1] > 0 && integersIn[1] < 9;
    }
}
