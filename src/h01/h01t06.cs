using System;
class Program
{
    static void Main()
    {
        // Defining variables
        double litersPer100km = 7.02;
        double costPerLiter = 1.595;
        double gasUsed = 0;
        double kilometers;
        
        // Ask kilometers from user.
        Console.Write("Give amount of kilometers driven: ");
        kilometers = int.Parse(Console.ReadLine());
        
        // Print amount of gas used and cost.
        gasUsed = kilometers / 100 * litersPer100km;
        Console.Write("You used " + 
                       Math.Round(gasUsed, 2) +
                       " liters of gas which costs " + 
                       Math.Round(gasUsed * costPerLiter, 2) + 
                       " euros.");
    }
}
