using System;
namespace H04T06
{
    class Program
    {
        static void Main ()
        {
            // Creating objects to item type of array.
            Item[] items = {
                new Computer("Mylly", 230, "AMD Phenom X4", 6),
                new Computer("Läppis", 12, "Something 4core", 4),
                new Screen("Samsung", 230, "1920x1080"),
                new Screen("Acer", 230, "1600x900"),
                new Chair("Ruokailutuoli", 50, 4, true),
                new Chair("Työtuoli", 50, 1, true),
                new Chair("Keittiöjakkara", 90, 4, false),
                new Furniture("Kirjahylly", 200),
                new Table("Keittiön pöytä", 110, 4, 100, 60),
                new Table("Työpöytä", 100, 2, 150, 50),
                new Book("Somebook", "1234567890112", "Paperback", 382),
                new Book("SomeOtherBook", "1234567890122", "Hardcover", 237),
            };

            // Going through all items in array and printing their properties.
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
        }
    }
}
