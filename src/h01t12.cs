using System;
class Program
{
    static void Main()
    {
        int[] integers = new int[5];
        // Ask integers.
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Give integer: ");
            integers[i] = int.Parse(Console.ReadLine());
        }
        // Print in reversed order.
        for (int i = integers.Length - 1; i >= 0; i--)
        {
            Console.Write(integers[i]);
            if (i > 0)
            {
                Console.Write(", ");
            }
            else
            {
                Console.Write(".");
            }
        }
    }
}