using System;
class Pesukone
{
    // Class member variables.
    int waterAmount = 0;
    int rpm = 0;
    int rotatingDirection = 0;
    bool hatchLocked = false;
    
    // Properties.
    int WaterAmount {
        set {
            if (hatchLocked)
            {
                waterAmount = value;
            }
            else
            {
                waterAmount = 0;
            }
        }
        get { return waterAmount; }
    }
    int Rpm {
        set {
            if (hatchLocked)
            {
                rpm = value;
            }
            else
            {
                rpm = 0;
            }
        }
        get { return rpm; }
    }

    // Methods.
    // Changes motor direction. Fails if motor is rotating. Returns true on
    // success.
    bool changeDirection ()
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
          return false;
        }
    }

    // Locks hatch.
    void lockHatch ()
    {
        hatchLocked = true;
    }

    // Opens hatch. Returns true on success. Fails if water level is above zero 
    // or if rpm is above zero.
    bool openHatch ()
    {
        if (rpm <= 0 && waterAmount <= 0)
        {
            hatchLocked = false;
            return true;
        }
        else
        {
          return false;
        }
    }
}

class Program
{
    static void main ()
    {
        Pesukone pesukone = new Pesukone();
        pesukone.lockHatch();
        pesukone.waterAmount = 20;
        pesukone.rpm = 9;
        if (!pesukone.openHatch())
        {
            Console.WriteLine("Could not open hatch!")
        }
        pesukone.waterAmount = 0;
        pesukone.rpm = 0;
        if (pesukone.openHatch())
        {
            Console.WriteLine("Hatch opened succesfully!")
        }
    }
}