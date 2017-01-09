using System;
class Program
{
    static void Main()
    {
        int sum = 0;
        
        // Ask integers until user gives zero.
        while (true)
        {
            Console.Write("Give integer: ");
            int integer = int.Parse(Console.ReadLine());
            
            // Break if intefer is zero or less. If not, resize array to new
            // size and add provided intefer to array.
            if (integer <= 0)
            {
                break;
            }
            else
            {
                sum += integer;
            }
        }
        Console.Write("Sum is " + sum + ".");
    }
}
