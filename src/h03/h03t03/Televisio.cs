using System;
namespace H03T03
{
    class Televisio
    {
        // Member variables.
        private int channel = 0;
        private int brightness = 10;
        private int volume = 5;
        private bool mute = false;
        
        // Properties.
        int Channel {
            set {
                if (value >= 0 && value <= 200){
                    Console.WriteLine("Set channel to " + value);
                    channel = value;
                }
                else {
                    Console.WriteLine("Channel out of bounds. Set to zero.");
                    channel = 0;
                }
            }
            get { return channel; }
        }
        public int Brightness {
            set {
                if (value >= 0 && value <= 20) {
                    Console.WriteLine("Set brightness to " + value);
                    brightness = value;
                }
                else {
                    Console.WriteLine("Birghtness out of bounds. Set to zero.");
                    brightness = 0;
                }
            }
            get { return brightness; }
        }
        public int Volume {
            set {
                if (value >= 0 && value <= 50) {
                    Console.WriteLine("Set volume to " + value);
                    volume = value;
                }
                else {
                    Console.WriteLine("Volume out of bounds. Set to zero.");
                    volume = 0;
                }
            }
            get { return volume; }
        }
        public bool Mute {
            set { mute = value; }
            get { return mute; }
        }
        
        // Methods.
        public void increaseBrightness ()
        {
            if (brightness < 20)
            {
                brightness++;
                Console.WriteLine("Increased brightness by one.");
            }
        }
        public void decreaseBrightness ()
        {
            if (brightness > 0)
            {
                brightness--;
                Console.WriteLine("Decreased brightness by one.");
            }
        }
        public void increaseVolume ()
        {
            if (volume < 50)
            {
                volume++;
                Console.WriteLine("Increased volume by one.");
            }
            else
            {
                Console.WriteLine("Volume already at maximum level.");
            }
        }
        public void decreaseVolume ()
        {
            if (volume > 0)
            {
                volume--;
                Console.WriteLine("Decreased volume by one.");
            }
        }
        public void toggleMute ()
        {
            if (mute)
            {
                mute = false;
                Console.WriteLine("Unmuted");
            }
            else
            {
                mute = true;
                Console.WriteLine("Muted");
            }
        }
    }
}