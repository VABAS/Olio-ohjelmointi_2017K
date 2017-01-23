using System;
namespace Kiuas
{
    class Program
    {
        static void main ()
        {
            Kiuas kiuas = new Kiuas();
            kiuas.Temperature = 90;
            kiuas.Humidity = 60;
            kiuas.toggle();
        }
    }
}