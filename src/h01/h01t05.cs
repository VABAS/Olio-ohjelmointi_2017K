using System;
class Program
{
    static void Main()
    {
        int seconds;
        int minutes;
        int hours;
        
        // Ask for users age
        Console.Write("Give amount of seconds: ");
        seconds = int.Parse(Console.ReadLine());
        
        // Calculate minutes and hours. Seconds must be decremented accordingly
        // for calculations to be right in the end.
        hours = seconds / 60 / 60;
        seconds -= hours * 60 * 60;
        minutes = seconds / 60;
        seconds -= minutes * 60;
        
        // Print it in hours, minutes, and seconds.
        Console.Write("Given seconds can be represented as " + hours + "h " + minutes + "m " + seconds + "s.");
    }
}
