using System;
namespace H04T06
{
    class Computer : Electronic
    {
        // Member variables.
        protected string processor;
        protected int    numUsbPorts;

        // Properties.
        public string Processor {
            get { return processor; }
            set { processor = value; }
        }
        public int NumUsbPorts {
            get { return numUsbPorts; }
            set { numUsbPorts = value; }
        }

        // Constructors.
        public Computer (string name, int inputVoltage, string processor, int numUsbPorts)
            : base(name, inputVoltage)
        {
            Processor = processor;
            NumUsbPorts = numUsbPorts;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - Processor: " + Processor +
                   "\n - Number of USB-ports: " + NumUsbPorts;
        }
    }
}
