using System;

namespace H05T03
{
    class Program
    {
        static void Main ()
        {
            Company company = new Company();
            
            // Main loop.
            while (true)
            {
                int selection = -1;
                Console.Write("1. Palkkaa. 2. Erota. 3. Listaa 0. Lopeta: ");
                bool status = int.TryParse(Console.ReadLine(), out selection);
                if (status)
                {
                    switch (selection)
                    {
                        // Exit
                        case 0:
                            return;
                        
                        // Hire.
                        case 1:
                            Console.Write("Give name for new employee: ");
                            string name = Console.ReadLine();
                            company.AddEmployee(name);
                            break;
                        
                        // Fire.
                        case 2:
                            company.FireLast();
                            break;
                        
                        // List.
                        case 3:
                            company.PrintAll();
                            break;
                        
                        default:
                            Console.WriteLine("Not valid selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You must give number");
                }
            }
        }
    }
}