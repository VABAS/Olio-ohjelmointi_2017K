using System;

class Program
{
    static void Main ()
    {
        Person[] p = {
            new Person("3490534059","Jesse","Siekkinen"),
            new Person("0349582095","Sakke","Saastamoinen"),
        };
        Persons persons = new Persons(p);
        persons.AddPerson(new Person("3845205820","Heli","Hillava"));
        persons.AddPerson("5489032931", "Allu", "Kallu");
        persons.PrintData();
        Console.WriteLine();

        // We need to find Heli from persons.
        Person heli = persons.FindPerson("384520582");
        if (heli != null)
        {
            heli.PrintData();
        }
        else
        {
            Console.WriteLine("Not found!");
        }
        // Oops, wrond id... Lets try again.
        heli = persons.FindPerson("3845205820");
        if (heli != null)
        {
            heli.PrintData();
        }
        else
        {
            Console.WriteLine("Not found!");
        }
        
        // Testing GetPerson-method next... trying to get Sakke here.
        Person sakke = persons.GetPerson(13);
        if (sakke != null)
        {
            sakke.PrintData();
        }
        else
        {
            Console.WriteLine("Not found!");
        }
        // Oops, wrond index this time... Lets try again.
        sakke = persons.GetPerson(1);
        if (sakke != null)
        {
            sakke.PrintData();
        }
        else
        {
            Console.WriteLine("Not found!");
        }
        
    }
}