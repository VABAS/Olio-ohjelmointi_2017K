using System;
namespace H04T05
{
    class Program
    {
        static void Main ()
        {
            Radio radio = new Radio(9, 2000, 26000);
            Console.WriteLine(radio.ToString());
            radio.IsOn = true;
            radio.Channel = 15200.6;
            Console.WriteLine(radio.ToString());
            radio.Channel = 100000;
            radio.Volume = 5;
            Console.WriteLine(radio.ToString());
        }
    }
}
