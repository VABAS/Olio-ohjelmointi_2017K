using System;
namespace H03T01
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
            set { humidity = value;}
        }
        public bool IsOn {
            get { return isOn; }
        }

        // Methods.
        public void toggle () {
            if (isOn)
            {
                Console.WriteLine("Toggled kiuas to off");
                this.isOn = false;
            }
            else
            {
                Console.WriteLine("Toggled kiuas to on");
                this.isOn = true;
            }
        }
    }
}