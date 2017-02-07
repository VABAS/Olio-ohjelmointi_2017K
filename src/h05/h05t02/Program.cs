using System;

namespace H05T02
{
    class Program
    {
        static void Main ()
        {
            Cd cd1 = new Cd("Nightwish", "Endless Forms Most Beautiful", "Symphonic metal", 6.2);
            Cd cd2 = new Cd("Anssi Kela", "Nummela", "pop", 5.9);
            
            // Adding with objects.
            cd1.AddTrack(new Track("Shudder Before the Beautiful", 6, 29));
            cd1.AddTrack(new Track("Weak Fantasy", 5, 23));
            cd1.AddTrack(new Track("Elan", 4, 45));
            cd1.AddTrack(new Track("Yours Is an Empty Hope", 5, 34));
            cd1.AddTrack(new Track("Our Decades in the Sun", 6, 37));
            cd1.AddTrack(new Track("My Walden", 4, 38));
            
            // Adding with parameters, minutes and seconds.
            cd1.AddTrack("Endless Forms Most Beautiful", 5, 7);
            cd1.AddTrack("Edema Ruh", 5, 15);
            cd1.AddTrack("Alpenglow", 4, 45);
            cd1.AddTrack("The Eyes of Sharbat Gula", 6, 3);
            cd1.AddTrack("The Greatest Show on Earth", 24, 0);
            
            // Adding with parameter, seconds only.
            cd2.AddTrack("Kaksi sisarta", 259);
            cd2.AddTrack("Mikan faijan BMW", 254);
            cd2.AddTrack("Esko Riihelän painajainen", 194);
            cd2.AddTrack("Puistossa", 270);
            cd2.AddTrack("Kaunotar ja basisti", 257);
            cd2.AddTrack("Rva. Ruusunen", 225);
            cd2.AddTrack("Harhaa", 251);
            cd2.AddTrack("Kisanpäivät", 248);
            cd2.AddTrack("Nummela", 329);
            Console.WriteLine(cd1.ToString());
            Console.WriteLine(cd2.ToString());
        }
    }
}