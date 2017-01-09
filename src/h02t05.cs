using System;
class Program
{
    static void Main()
    {
        int[] arrayOne = {10,20,30,40,50};
        int[] arrayTwo = {5,15,25,35,45};
        int[] arrayThree = new int[arrayOne.Length + arrayTwo.Length];
        
        // Combining arrayOne and arrayTwo into arrayThree.
        for (int i = 0; i < arrayOne.Length; i++)
        {
            arrayThree[i * 2 + 1] = arrayOne[i];
            arrayThree[i * 2]  = arrayTwo[i];
        }
        
        // Sorting array using Sort-method from Array.
        Array.Sort(arrayThree);
        
        // Printing sorted arrayThree. Using for-loop instead of foreach to
        // print also nice commas after each integer except last.
        for (int i = 0; i < arrayThree.Length; i++)
        {
            Console.Write(arrayThree[i]);
            if (i < arrayThree.Length - 1)
            {
                Console.Write(", ");
            }
        }
    }
}
