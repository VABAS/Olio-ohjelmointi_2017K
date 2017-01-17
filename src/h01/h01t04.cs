using System;
class Program
{
    static void Main()
    {
        int age;
        
        // Ask for users age
        Console.Write("Give your age: ");
        age = int.Parse(Console.ReadLine());
        
        // Print message depending on the age
        if (age < 18)
        {
            Console.Write("Underage");
        }
        else if (age < 66)
        {
            Console.Write("Adult");
        }
        else
        {
            Console.Write("Senior");
        }
    }
}
