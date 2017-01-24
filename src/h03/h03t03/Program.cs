using System;
namespace H03T03
{
    class Program
    {
        static void Main ()
        {
            Televisio tv = new Televisio();
            tv.Brightness = 0;
            for (int i = 0; i < 46; i++)
            {
                tv.increaseVolume();
            }
            tv.toggleMute();
            tv.toggleMute();
            tv.Volume = 20;
            for (int i = 0; i < 10; i++)
            {
                tv.increaseBrightness();
            }
        }
    }
}