using System;
namespace H03T02
{
    class Pesukone
    {
        // Class member variables.
        private int waterAmount = 0;
        private int rpm = 0;
        private int rotatingDirection = 0;
        private bool hatchLocked = false;
        
        // Properties.
        public int WaterAmount {
            set {
                if (hatchLocked)
                {
                    Console.WriteLine("WaterAmount changed to " + value + ".");
                    waterAmount = value;
                }
                else
                {
                    Console.WriteLine("Could not change the waterAmount becouse hatch is not locked!");
                }
            }
            get { return waterAmount; }
        }
        public int Rpm {
            set {
                if (hatchLocked)
                {
                    Console.WriteLine("Rpm changed to " + value + ".");
                    rpm = value;
                }
                else
                {
                    Console.WriteLine("Could not change the rpm becouse hatch is not locked!");
                }
            }
            get { return rpm; }
        }

        // Methods.
        // Changes motor direction. Fails if motor is rotating. Returns true on
        // success.
        public bool changeDirection ()
        {
            if (rpm <= 0)
            {
                if (rotatingDirection == 0)
                {
                    rotatingDirection = 1;
                }
                else
                {
                    rotatingDirection = 0;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Cannot change direction when motor is running!");
                return false;
            }
        }

        // Locks hatch.
        public void lockHatch ()
        {
            hatchLocked = true;
        }

        // Opens hatch. Returns true on success. Fails if water level is above zero 
        // or if rpm is above zero.
        public bool openHatch ()
        {
            if (rpm <= 0 && waterAmount <= 0)
            {
                Console.WriteLine("Hatch unlocked.");
                hatchLocked = false;
                return true;
            }
            else
            {
                Console.WriteLine("Hatch could not be unlocked becouse either motor is spining or there is water in machine!");
                return false;
            }
        }
    }
}