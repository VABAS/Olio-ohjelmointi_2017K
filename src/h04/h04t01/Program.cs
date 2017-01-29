using System;
namespace H04T01
{
    class Program
    {
        // Creating static min and max variables for easy use later.
        static int minFloor = 1;
        static int maxFloor = 5;
        
        static void Main ()
        {
            // Creating instance of elevator.
            Elevator elevator = new Elevator(minFloor, maxFloor);
            
            while (true)
            {
                Console.WriteLine("Elevator is now at floor : " + elevator.FloorNow);
                Console.Write("Give a new floor number (" + minFloor + "-" + maxFloor + "): ");
                int number;
                bool result = int.TryParse(Console.ReadLine(), out number);
                
                // Trying to set elevator to given floor if number was given.
                // Informing user about error if non-number was given.
                if (result)
                {
                    elevator.FloorNow = number;
                }
                else
                {
                    Console.WriteLine("Not number. Must give number!");
                }
            }
        }
    }
}
