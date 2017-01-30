using System;
namespace H04T06
{
    class Chair : Furniture
    {
        // Member variables.
        protected int  numLegs;
        protected bool hasBack;

        // Properties.
        public int NumLegs {
            get { return numLegs; }
            set { numLegs = value; }
        }
        public bool HasBack {
            get { return hasBack; }
            set { hasBack = value; }
        }

        // Constructors.
        public Chair (string name, int height, int numLegs, bool hasBack)
            : base(name, height)
        {
            Height = height;
            NumLegs = numLegs;
            HasBack = hasBack;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - Number of legs: " + NumLegs +
                   "\n - Has back: " + HasBack;
        }
    }
}
