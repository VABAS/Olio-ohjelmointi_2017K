using System;
namespace H04T03
{
    class Program
    {
        static void Main ()
        {
            // Creating instances of employee class and boss class.
            Employee employee = new Employee("Kirsi Kernel", "Teacher", 1200);
            Boss boss = new Boss("Jussi Jurkka", "Head of Institute", "Audi", 9000, 5000);
            
            // Writing object information to screen.
            Console.WriteLine(employee.ToString());
            Console.WriteLine(boss.ToString());
            
            // Editing employee objects properties.
            employee.Profession = "Principal Teacher";
            employee.Salary = 2200;
            
            // And printing information again. Should be changed.
            Console.WriteLine(employee.ToString());
        }
    }
}
