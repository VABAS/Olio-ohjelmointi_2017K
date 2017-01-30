namespace H04T06
{
    class Book : Item
    {
        // Member variables.
        protected string isbn;
        protected string type;
        protected int    numPages;

        // Properties.
        public string Isbn {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Type {
            get { return type; }
            set { type = value; }
        }
        public int NumPages {
            get { return numPages; }
            set { numPages = value; }
        }

        // Constructors.
        public Book (string name, string isbn, string type, int numPages)
            : base(name)
        {
            Isbn = isbn;
            Type = type;
            NumPages = numPages;
        }

        // Overriding ToString().
        public override string ToString ()
        {
            return base.ToString() +
                   "\n - ISBN: " + Isbn +
                   "\n - Type: " + Type +
                   "\n - Pages: " + NumPages;
        }
    }
}
