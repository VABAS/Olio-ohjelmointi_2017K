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
            return base.ToString() +
                   " SeatCount: " + seatCount +
                   " BoatType: " + boatType;
        }
    }
}
