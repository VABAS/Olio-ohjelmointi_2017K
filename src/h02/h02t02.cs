using System;
class Program
{
    static void Main()
    {
        // Array to store number of each grade received (0 -- 5).
        int[] grades = {0, 0, 0, 0, 0, 0};
        
        // Asking grades from user.
        Console.WriteLine("Enter -1 to stop giving grades.");
        while (true)
        {
            Console.Write("Supply grade: ");
            int grade = int.Parse(Console.ReadLine());
            if (grade >= 0 && grade <= 5)
            {
                grades[grade]++;
            }
            else if (grade == -1)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid grade");
            }
        }
        Console.WriteLine("Grades:");
        
        // Loop through the grades array.
        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write(i + ": ");
            
            // Writing the 'stars'.
            for (int j = 0; j < grades[i]; j++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }
    }
}
