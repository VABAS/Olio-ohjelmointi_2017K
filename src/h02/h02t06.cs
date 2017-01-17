using System;
class Program
{
    static void Main()
    {
        Console.Write("Give word: ");
        string word = Console.ReadLine();
        string wordBackwards = "";
        
        // Go through each character in provided word backwards and insert them
        // to wordBackwards-variable.
        for (int i = word.Length - 1; i >= 0; i--)
        {
            wordBackwards += word[i];
        }
        
        // If word and wordBackwards are same then the word is palindrome.
        if (word == wordBackwards)
        {
            Console.WriteLine("Word is palindrome");
        }
        else
        {
            Console.WriteLine("Word is not palindrome");
        }
    }
}
