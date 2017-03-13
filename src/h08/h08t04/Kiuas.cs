using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T08H04
{
    class Kiuas
    {
        // Setting maximum values as readonly parameters.
        private readonly double maxTemperature = 120;
        private readonly double maxHumidity = 100;
        
        // Private properties.
        private double temperature;
        private double humidity;

        /// <summary>
        /// Public property to access the temparature field. If value is out of
        /// bounds throws TemperatureValueOutOfBoundsException.
        /// </summary>
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

        /// <summary>
        /// Public property to access the humidity field. If value is out of
        /// bounds throws HumidityValueOutOfBoundsException.
        /// </summary>
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

        /// <summary>
        /// Constructor. Just initializes temperature and humidity values to
        /// zero.
        /// </summary>
        public Kiuas()
        {
            Temperature = 0;
            Humidity = 0;
        }

        // Exception classes.
        public class TemperatureValueOutOfBoundsException : Exception
        {
            public TemperatureValueOutOfBoundsException()
            { }

            public TemperatureValueOutOfBoundsException(string message) : base(message)
            { }
        }
        public class HumidityValueOutOfBoundsException : Exception
        {
            public HumidityValueOutOfBoundsException()
            { }

            public HumidityValueOutOfBoundsException(string message) : base(message)
            { }
        }
    }
}
