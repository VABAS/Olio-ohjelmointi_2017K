namespace H04T06
{
    class Item
    {
        // Member variables.
        protected string name;

        // Properties.
        public string Name {
            get { return name; }
            set { name = value; }
        }

        // Constructors.
        public Item () {}
        public Item (string name)
        {
            Name = name;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return Name + ":";
        }
    }
}
