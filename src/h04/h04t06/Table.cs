using System;
namespace H04T06
{
    class Table : Furniture
    {
        // Member variables.
        protected int numLegs;
        protected int width;
        protected int length;

        // Properties.
        public int NumLegs {
            get { return numLegs; }
            set { numLegs = value; }
        }
        public int Width {
            get { return width; }
            set { width = value; }
        }
        public int Length {
            get { return length; }
            set { length = value; }
        }

        // Constructors.
        public Table (string name, int height, int numLegs, int width, int length)
            : base(name, height)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - Number of legs: " + NumLegs +
                   "\n - Dimensions: " + Width + "x" + Height;
        }
    }
}
