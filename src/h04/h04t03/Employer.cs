namespace H04T03
{
    class Employee
    {
        protected string name;
        protected string profession;
        protected int    salary;
        
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string Profession {
            get { return profession; }
            set { profession = value; }
        }
        public int Salary {
            get { return salary; }
            set { salary = value; }
        }
        
        public Employee (string name, string profession, int salary)
        {
            this.name = name;
            this.profession = profession;
            this.salary = salary;
        }
        
        public override string ToString ()
        {
            return "Employee:\n" +
                   " - Name: " + Name +
                   " Profession: " + Profession +
                   " Salary: " + Salary;
        }
    }
}
