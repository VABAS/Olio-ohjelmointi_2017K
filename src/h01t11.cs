using System;
class Program
{
    static void Main()
    {
        int rows = 0;
        // Asking number of rows.
        Console.Write("Give number of rows: ");
        rows = int.Parse(Console.ReadLine());

        if (rows > 0)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
        else
        {
            Console.Write("Row number must be greater than zero!");
        }
    }
}
