using System;
namespace H03T01
{
    class Program
    {
        static void Main ()
        {
            Kiuas kiuas = new Kiuas();
            kiuas.Temperature = 90;
            kiuas.Humidity = 60;
            kiuas.toggle();
            kiuas.toggle();
        }
    }
}