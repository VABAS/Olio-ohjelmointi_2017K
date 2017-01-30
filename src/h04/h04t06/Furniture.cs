using System;
namespace H04T06
{
    class Furniture : Item
    {
        // Member variables.
        protected int height;

        // Properties.
        public int Height {
            get { return height; }
            set { height = value; }
        }

        // Constructors.
        public Furniture (string name, int height)
            : base(name)
        {
            Height = height;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - Height: " + Height;
        }
    }
}
