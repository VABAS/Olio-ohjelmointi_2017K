using System;
namespace H03T06
{
    class Program
    {
        static void Main ()
        {
            string[] songs = new string[]{
                         "Shudder Before the Beautiful - 06:29",
                         "Weak Fantasy - 05:23",
                         "Elan - 04:45",
                         "Yours Is an Empty Hope - 05:34",
                         "Our Decades in the Sun - 06:37",
                         "My Walden - 04:38",
                         "Endless Forms Most Beautiful - 05:07",
                         "Edema Ruh - 05:15",
                         "Alpenglow - 04:45",
                         "The Eyes of Sharbat Gula - 06:03",
                         "The Greatest Show on Earth - 24:00 "
                     };
            
            CD cd = new CD("Nightwish", "Endless Forms Most Beautiful", "Symphonic metal", 1.11, songs);
            
            Console.WriteLine(cd.getDetails());
        }
    }
}