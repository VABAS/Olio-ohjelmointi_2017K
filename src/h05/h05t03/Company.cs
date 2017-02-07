using System.Collections.Generic;

namespace H05T03
{
    class Company
    {
        private Stack<Employee> employees;
        
        public Company ()
        {
            employees = new Stack<Employee>();
        }
        
        // Add (hire) new employee.
        public void AddEmployee (string name)
        {
            employees.Push(new Employee(name));
        }
        
        // Fire lastly added employee.
        public void FireLast ()
        {
            System.Console.Write("Employee '");
            employees.Pop().PrintData();
            System.Console.Write("' fired\n");
        }
        
        // Prints all employees.
        public void PrintAll ()
        {
            foreach (Employee employee in employees)
            {
                System.Console.Write("Employee name ");
                employee.PrintData();
                System.Console.Write("\n");
            }
        }
        
        // Destructor.
        ~Company ()
        {
            System.Console.WriteLine("Company destructed");
        }
    }
}