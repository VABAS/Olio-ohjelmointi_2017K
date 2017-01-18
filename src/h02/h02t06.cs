using System;
class Program
{
    static void Main()
    {
        Console.Write("Give word: ");
        string word = Console.ReadLine();

        // Boolean to store word status.
        bool isPalindrome = true;

        // Lets compare letters from start and end towards middle as long as
        // they equal. If they dont equal set palindrome status to false and
        // break.
        for (int i = 0; i < word.Length - 1 - i; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                isPalindrome = false;
                break;
            }
        }
        if (isPalindrome)
        {
            Console.WriteLine("Word is palindrome");
        }
        else
        {
            Console.WriteLine("Word is not palindrome");
        }
    }
}
