using System;
namespace H04T03
{
    class Program
    {
        static void Main ()
        {
            Employee employee = new Employee("Kirsi Kernel", "Teacher", 1200);
            Boss boss = new Boss("Jussi Jurkka", "Head of Institute", "Audi", 9000, 5000);
            
            
            
            Console.WriteLine(employee.ToString());
            Console.WriteLine(boss.ToString());
            
            employee.Profession = "Principal Teacher";
            employee.Salary = 2200;
            Console.WriteLine(employee.ToString());
        }
    }
}
