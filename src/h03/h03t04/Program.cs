using System;
namespace H03T04
{
    class Program
    {
        static void Main ()
        {
            Vehicle veh = new Vehicle();
            veh.Tyres = 3;
            veh.Name = "Riksa";
            veh.Speed = 182;
            
            Console.WriteLine(veh.ToString());
            Console.WriteLine();
            
            veh.Tyres = 4;
            veh.Name = "Ferrari";
            veh.Speed = 83;
            veh.PrintData();
            
        }
    }
}