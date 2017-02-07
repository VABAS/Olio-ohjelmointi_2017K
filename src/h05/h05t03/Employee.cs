namespace H05T03
{
    class Employee
    {
        private string name;
        
        public Employee (string name)
        {
            this.name = name;
        }
        
        // Prints employee name.
        public void PrintData ()
        {
            System.Console.Write(name);
        }
        
        // Destructor.
        ~Employee ()
        {
            PrintData();
            System.Console.WriteLine(" destructed");
        }
    }
}