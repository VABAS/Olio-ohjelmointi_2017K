namespace H04T04
{
    class Bike : Vehicle
    {
        protected bool gearWheels;
        protected string gearName;
        
        public Bike (string name, string model, string color, int modelYear, bool gearWheels, string gearName)
         : base(name, model, color, modelYear)
        {
            this.gearWheels = gearWheels;
            this.gearName = gearName;
        }
        
        public override string ToString ()
        {
            return base.ToString() +
                   " GearWheels: " + gearWheels +
                   " Gear Name: " + gearName;
        }
    }
}
