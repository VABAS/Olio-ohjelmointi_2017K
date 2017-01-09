using System;
class Program
{
    static void Main()
    {
        int sum = 0;
        int biggest = 0;
        int smallest = 0;
        
        // Asking five points values from user and sum them up. Also determining
        // the biggest and smallest points given.
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Give points from judge #" + (i + 1) + ": ");
            int points = int.Parse(Console.ReadLine());
            sum += points;
            if (points < smallest || i == 0)
            {
                smallest = points;
            }
            if (points > biggest || i == 0)
            {
                biggest = points;
            }
        }
        
        // Substracting the smallest and biggest points from sum.
        sum -= (biggest + smallest);
        Console.Write("Points were " + sum + ".");
    }
}
