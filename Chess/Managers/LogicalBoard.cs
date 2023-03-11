using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

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
                    contents.Add($"{file}{rank}",null);
                }
            }

        }

        public LogicalBoard()
        {
            // Create the board
            createBoard();

            displayBoard();
        }

        public void customBoardSetup()
        {
        }

        public void displayBoard() 
        { 
            // This method will display the contents that are currently stored inside of this object
            foreach(var item in contents.Values)
            {
                if(item is null)
                {
                    Console.WriteLine("Empty");
                }
                else
                {
                    Console.WriteLine("Item!!!");
                }
            }

        }
    }
}
