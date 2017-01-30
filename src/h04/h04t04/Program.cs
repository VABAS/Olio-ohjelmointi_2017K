using System;
namespace H04T04
{
    class Program
    {
        static void Main ()
        {
            // Creating two instances of bike class.
            Bike bike = new Bike("Jopo", "Street", "Blue", 2016, false, "");
            Bike bike2 = new Bike("Tunturi", "StreetPower", "Black", 2010, true, "Shimano");
            
            // Creating two instances of boat class.
            Boat boat = new Boat("Suvi", "S900", "White", 1990, 3, "Rowboat");
            Boat boat2 = new Boat("Yamaha", "Model 1000", "Yellow", 2010, 5, "Motorboat");
            
            // Printing informations about vehicles declared.
            Console.WriteLine("Bike info");
            Console.WriteLine(bike.ToString());
            Console.WriteLine("Bike2 info");
            Console.WriteLine(bike2.ToString());
            Console.WriteLine("Boat info");
            Console.WriteLine(boat.ToString());
            Console.WriteLine("Boat2 info");
            Console.WriteLine(boat2.ToString());
        }
    }
}
