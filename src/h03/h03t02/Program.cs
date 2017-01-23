using System;
namespace Pesukone
{
    class Program
    {
        static void main ()
        {
            Pesukone pesukone = new Pesukone();
            pesukone.lockHatch();
            pesukone.waterAmount = 20;
            pesukone.rpm = 9;
            pesukone.openHatch();
            pesukone.waterAmount = 0;
            pesukone.rpm = 0;
            pesukone.openHatch();
        }
    }
}