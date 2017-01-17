using System;
class Program
{
    static void Main()
    {
        Random rand = new Random();
        
        // Generate the random number.
        int randomInteger = rand.Next(1, 100);
        int guessCount = 1;
        while (true)
        {
            // Ask for guess from user.
            Console.Write("Guess the number: ");
            int guess = int.Parse(Console.ReadLine());
            
            // Check if guess is right or smaller or bigger.
            if (guess == randomInteger)
            {
                Console.WriteLine("Great! your guess was right after " +
                                  guessCount +
                                  " guesses.");
                
                // Breaking out of loop.
                break;
            }
            else if (guess < randomInteger)
            {
                Console.WriteLine("Number is bigger");
            }
            else if (guess > randomInteger)
            {
                Console.WriteLine("Number is smaller");
            }
            
            // Incrementing guessCount if user doesn't guess right.
            guessCount++;
        }
    }
}
