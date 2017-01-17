using System;
class Program
{
    static void Main()
    {
        int sum = 0;

        // Ask three integers and save them to array.
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Give number #" + (i + 1) + ": ");
            int num = int.Parse(Console.ReadLine());
            sum += num;
        }

        // Print sum and average.
        Console.Write("Sum of given numbers is " + sum + " and average is " + (sum/3) + ".");
    }
}
