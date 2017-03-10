using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T08H04
{
    class Kiuas
    {
        private readonly double maxTemperature = 1200;
        private readonly double maxHumidity = 100;
        private double temperature;
        private double humidity;

        public double Temperature
        {
            get { return temperature; }
            set
            {
                if (value <= maxTemperature && value >= 0)
                {
                    temperature = value;
                }
                else
                {
                    throw new TemperatureValueOutOfBoundsException("Temperature value of " + value + " is out of bounds!");
                }
            }
        }

        public double Humidity
        {
            get { return humidity; }
            set
            {
                if (value <= maxHumidity && value >= 0)
                {
                    humidity = value;
                }
                else
                {
                    throw new HumidityValueOutOfBoundsException("Humidity value of " + value + " is out of bounds!");
                }
            }
        }

        // Constructor. Just initializes temperature and humidity values to zero.
        public Kiuas()
        {
            Temperature = 0;
            Humidity = 0;
        }

        // Exception classes.
        public class TemperatureValueOutOfBoundsException : Exception
        {
            public TemperatureValueOutOfBoundsException()
            {
            }

            public TemperatureValueOutOfBoundsException(string message)
                : base(message)
            { }
        }
        public class HumidityValueOutOfBoundsException : Exception
        {
            public HumidityValueOutOfBoundsException()
            {
            }

            public HumidityValueOutOfBoundsException(string message)
                : base(message)
            { }
        }
    }
}
