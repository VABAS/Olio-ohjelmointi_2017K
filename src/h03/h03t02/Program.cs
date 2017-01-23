using System;
namespace H03T02
{
    class Program
    {
        static void Main ()
        {
            Pesukone pesukone = new Pesukone();
            pesukone.lockHatch();
            pesukone.WaterAmount = 20;
            pesukone.Rpm = 9;
            pesukone.openHatch();
            pesukone.WaterAmount = 0;
            pesukone.Rpm = 0;
            pesukone.openHatch();
        }
    }
}