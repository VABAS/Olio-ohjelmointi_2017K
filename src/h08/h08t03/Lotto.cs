using System;
using System.Linq;

namespace H08T03
{
    class Lotto
    {
        private Random rnd;
        
        // Constructor. Just initializing random rnd.
        public Lotto ()
        {
            rnd = new Random();
        }

        // Generates new row and returns it as string.
        public string generateRow()
        {
            // Creating temporary array of seven integers.
            int[] rowInts = new int[7];
            
            // Row return string initialized to empty.
            string row = "";
            
            // Generating seven random integers.
            for (int i = 0; i < 7; i++)
            {
                int rndInt;
                
                // Generating random integer. If integer happens to be duplicate
                // generate again. As long as there happens to be conflict.
                do
                {
                    rndInt = rnd.Next(1, 40);
                }  while (rowInts.Contains(rndInt));
                rowInts[i] = rndInt;
            }
            
            // Sorting array.
            Array.Sort(rowInts);
            
            // Converting array of integers to single string.
            foreach (int rowInt in rowInts)
            {
                if (rowInt < 10)
                {
                    row += "0";
                }
                row += rowInt.ToString() + " ";
            }
            
            // Returning final string of row.
            return row;
        }
    }
}
