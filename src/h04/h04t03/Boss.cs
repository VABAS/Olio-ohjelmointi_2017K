namespace H04T03
{
    class Boss : Employee
    {
        protected string car;
        protected int    bonus;
        
        public string Car {
            get { return car; }
            set { car = value; }
        }
        public int Bonus {
            get { return bonus; }
            set { bonus = value; }
        }
        
        public Boss (string name, string profession, string car, int salary, int bonus)
        : base(name, profession, salary) {
            this.car = car;
            this.bonus = bonus;
        }
        
        // Overriding ToString() to generate nice summary with it.
        public override string ToString ()
        {
            return base.ToString() +
                   " Car: " + Car +
                   " Bonus: " + Bonus;
        }
    }
}
