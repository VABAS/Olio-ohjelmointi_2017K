namespace H04T04
{
    class Boat : Vehicle
    {
        protected int seatCount;
        protected string boatType;
        
        public Boat (string name, string model, string color, int modelYear, int seatCount, string boatType)
         : base(name, model, color, modelYear)
        {
            this.seatCount = seatCount;
            this.boatType = boatType;
        }
        
        public override string ToString ()
        {
            return " - Name: " + name +
                   " Model: " + model +
                   " ModelYear: " + modelYear +
                   " Color: " + color +
                   " SeatCount: " + seatCount +
                   " BoatType: " + boatType;
        }
    }
}
