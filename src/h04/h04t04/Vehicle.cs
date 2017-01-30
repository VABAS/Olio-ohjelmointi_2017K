namespace H04T04
{
    class Vehicle
    {
        protected string name;
        protected string model;
        protected int modelYear;
        protected string color;
        
        public Vehicle (string name, string model, string color, int modelYear)
        {
            this.name = name;
            this.model = model;
            this.color = color;
            this.modelYear = modelYear;
        }
        
        public override string ToString ()
        {
            return " - Name: " + name +
                   " Model: " + model +
                   " ModelYear: " + modelYear +
                   " Color: " + color;
        }
    }
}
