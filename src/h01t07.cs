using System;
class Program
{
    static void Main()
    {
        int year;
        
        // Ask for year from user.
        Console.Write("Give year: ");
        year = int.Parse(Console.ReadLine());
        
        // Tell user if provided year is leap year or not.
        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            Console.Write(year + " is leap year");
        }
        else
        {
            Console.Write(year + " is not leap year");
        }
    }
}
