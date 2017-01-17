using System;
class Program
{
    static void Main()
    {
        int biggest = 0;
        // Asking three integers and checking if it is biggest and saving it to
        // variable biggest if it is.
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Give integer #" + (i + 1) + ": ");
            int integer = int.Parse(Console.ReadLine());
            if (integer > biggest || i == 0)
            {
                biggest = integer;
            }
        }
        // Telling to user which of three was biggest.
        Console.Write("Biggest integer was " + biggest);
    }
}