using System;
namespace H04T02
{
    class Amplifier
    {
        private int maxVolume;
        private int currentVolume;
        
        // Property for setting and limiting and getting value of currentVolume.
        public int CurrentVolume {
            get {return currentVolume; }
            set {
                if (value < 0)
                {
                    currentVolume = 0;
                    Console.WriteLine("Too low volume - Amplifier volume is set to minimum : 0");
                }
                else if (value > maxVolume)
                {
                    currentVolume = maxVolume;
                    Console.WriteLine("Too much volume - Amplifier volume is set to maximum : " + maxVolume);
                }
                else
                {
                    currentVolume = value;
                    Console.WriteLine("Amplifier volume is set to : " + value);
                }
            }
        }
            
        // Constructor.
        public Amplifier (int maxVolume)
        {
            this.maxVolume = maxVolume;
        }
    }
}
