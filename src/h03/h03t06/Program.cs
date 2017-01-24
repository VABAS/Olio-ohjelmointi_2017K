using System;
namespace H03T06
{
    class Program
    {
        static void Main ()
        {
            Track[] songs = new Track[] {
                new Track("Shudder Before the Beautiful", 6, 29),
                new Track("Weak Fantasy", 5, 23),
                new Track("Elan", 4, 45),
                new Track("Yours Is an Empty Hope", 5, 34),
                new Track("Our Decades in the Sun", 6, 37),
                new Track("My Walden", 4, 38),
                new Track("Endless Forms Most Beautiful", 5, 7),
                new Track("Edema Ruh", 5, 15),
                new Track("Alpenglow", 4, 45),
                new Track("The Eyes of Sharbat Gula", 6, 3),
                new Track("The Greatest Show on Earth", 24, 0)
            };
                Track[] songs2 = new Track[] {
                    new Track("Kaksi sisarta", 259),
                    new Track("Mikan faijan BMW", 254),
                    new Track("Esko Riihelän painajainen", 194),
                    new Track("Puistossa", 270),
                    new Track("Kaunotar ja basisti", 257),
                    new Track("Rva. Ruusunen", 225),
                    new Track("Harhaa", 251),
                    new Track("Kisanpäivät", 248),
                    new Track("Nummela", 329)
                };

            CD cd1 = new CD("Nightwish", "Endless Forms Most Beautiful", "Symphonic metal", 1.11, songs);
            CD cd2 = new CD("Anssi Kela", "Nummela", "pop", 1.11, songs2);

            Console.WriteLine(cd1.getDetails());
            Console.WriteLine(cd2.getDetails());
        }
    }
}
