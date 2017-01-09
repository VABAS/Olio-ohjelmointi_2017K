using System;
class Program
{
    static void Main()
    {
        int[] arvot = { 1, 2, 33, 44, 55, 68, 77, 96, 100 };
        for (int i = 0; i < arvot.Length; i++)
        {
            // If modulo two from from number is zero it is dividable by two.
            if (arvot[i] % 2 == 0)
            {
                Console.Write("HEP");
            }
        }
    }
}
