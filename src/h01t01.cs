using System;
class Program
{
    static void Main()
    {
        int integer = 0;
        
        // Table for converting integers to text.
        string[] conversionTable = {"One", "Two", "Three"};
        Console.Write("Please provide an integer: ");
        integer = int.Parse(Console.ReadLine());
        
        // Checking that integer is in the range we wanted and printing error if
        // not so. Otherwise we print corresponding string from conversionTable.
        if (integer > 0 && integer < 4)
        {
            Console.Write(conversionTable[integer - 1]);
        }
        else
        {
            Console.Write("Integer is not valid");
        }
    }
}
