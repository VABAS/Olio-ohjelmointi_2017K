using System;
namespace H04T01
{
    class Elevator
    {
        private int floorNow;
        private int floorMin;
        private int floorMax;
        
        // Property to change the floor number.
        public int FloorNow {
            get { return floorNow; }
            set {
                if (value < floorMin) {
                    Console.WriteLine("Floor is too small!");
                }
                else if (value > floorMax) {
                    Console.WriteLine("Floor is too big!");
                }
                else {
                    floorNow = value;
                }
            }
        }
        
        // Constructor.
        public Elevator (int floorMin, int floorMax)
        {
            this.floorMin = floorMin;
            this.floorMax = floorMax;
            // Also setting current floor to bottom.
            this.floorNow = floorMin;
        }
    }
}
