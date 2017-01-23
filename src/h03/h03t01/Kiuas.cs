using System;
namespace Kiuas
{
    class Kiuas
    {
        // Class member variables.
        private int temperature = 0;
        private int humidity = 0;
        private bool isOn = false;

        // Properties.
        public int Temperature {
            get { return temperature;}
            set { temperature = value;}
        }
        public int Humidity {
            get { return humidity;}
            set { himidity = value;}
        }
        public bool isOn {
            get { return isOn; }
        }

        // Methods.
        public void toggle () {
            if (isOn)
            {
                this.isOn = false;
            }
            else
            {
                this.isOn = true;
            }
        }
    }
}