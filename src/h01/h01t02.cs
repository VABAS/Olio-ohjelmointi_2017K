using System;
class Program
{
    static void Main()
    {
        int points;
        
        // Ask for points.
        Console.Write("Please provide student points: ");
        points = int.Parse(Console.ReadLine());
        
        // Lets check grade for points. Informing user if points are below zero
        // or too high.
        if (points < 0)
        {
            Console.Write("Too low points");
        }
        else if (points <= 1)
        {
            Console.Write("Grade is 0");
        }
        else if (points <= 3)
        {
            Console.Write("Grade is 1");
        }
        else if (points <= 5)
        {
            Console.Write("Grade is 2");
        }
        else if (points <= 7)
        {
            Console.Write("Grade is 3");
        }
        else if (points <= 9)
        {
            Console.Write("Grade is 4");
        }
        else if (points <= 12)
        {
            Console.Write("Grade is 5");
        }
        else
        {
            Console.Write("Too high points");
        }
    }
}
