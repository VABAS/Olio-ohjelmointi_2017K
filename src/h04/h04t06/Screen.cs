using System;
namespace H04T06
{
    class Screen : Electronic
    {
        // Member variables.
        protected string resolution;

        // Properties.
        public string Resolution {
            get { return resolution; }
            set { resolution = value; }
        }

        // Constructors.
        public Screen (string name, int inputVoltage, string resolution)
            : base(name, inputVoltage)
        {
            Resolution = resolution;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - Resolution: " + Resolution;
        }
    }
}
