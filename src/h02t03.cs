using System;
class Program
{
    static void Main()
    {
        // Asking tree height from user.
        Console.Write("Give tree height: ");
        int height = int.Parse(Console.ReadLine());
        
        // Substracting the root height from whole tree height to be used in
        // generation (root generated separately).
        height -= 2;
        
        // Generating the tree.
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < (height - i); j++)
            {
                  Console.Write(" ");
            }
            for (int j = 0; j < (2 * i + 1); j++)
            {
                  Console.Write("*");
            }
            Console.Write("\n");
        }
        
        // Generating the root of the tree.
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < height; j++)
            {
                  Console.Write(" ");
            }
            Console.Write("*");
            Console.Write("\n");
        }
    }
}
