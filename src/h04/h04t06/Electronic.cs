using System;
namespace H04T06
{
    class Electronic : Item
    {
        // Member variables.
        protected int inputVoltage;

        // Properties.
        public int InputVoltage {
            get { return inputVoltage; }
            set { inputVoltage = value; }
        }

        // Constructors.
        public Electronic (string name, int inputVoltage) : base(name)
        {
            InputVoltage = inputVoltage;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - Input voltage: " + InputVoltage + "V";
        }
    }
}
