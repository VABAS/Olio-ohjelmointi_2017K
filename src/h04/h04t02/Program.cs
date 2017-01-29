using System;
namespace H04T02
{
    class Program
    {
        // Static maximum volume for easy access.
        static int maxVolume = 100;
        
        static void Main ()
        {
            Amplifier amp = new Amplifier(maxVolume);
            
            while (true)
            {
                int number;
                Console.Write("Give a new volume value (0-" + maxVolume + "): ");
                bool result = int.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    amp.CurrentVolume = number;
                }
                else
                {
                    Console.WriteLine("Not number. Must give number!");
                }
            }
            
        }
    }
}
