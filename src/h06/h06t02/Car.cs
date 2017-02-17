namespace H06T02
{
    public class Car
    {
        private string name;
        private int count;
        public string Name
        {
            get;
            set;
        }

        public Car (string name)
        {
            Name = name;
            count = 0;
        }

        // Method which increments the car count and returns new value.
        public int add ()
        {
            return ++count;
        }

        // Method for setting count to zero.
        public void clear ()
        {
            count = 0;
        }
    }
}
