using System;
class Program
{
    static void Main()
    {
        string word = "ohjelmointi";
        char[] guesses = new char[0];
        int numGuesses = 0;
        while (true)
        {
            int numUnderScores = 0;
            
            // Go through the word and replace characters with underscore unless
            // it has been guessed right.
            foreach (char character in word)
            {
                bool charFound = false;
                foreach (char guessCharacter in guesses)
                {
                    if (guessCharacter == character)
                    {
                        Console.Write(character);
                        charFound = true;
                        break;
                    }
                }
                
                // If character was not found from char-array of ours print
                // underscore to its place.
                if (!charFound)
                {
                    Console.Write("_");
                    numUnderScores++;
                }
            }
            Console.Write("\n");
            
            // Check if all characters are guessed right.
            if (numUnderScores == 0)
            {
                Console.WriteLine("You have guessed the whole word correctly!");
                Console.WriteLine("Right answer was " + word);
                Console.WriteLine("You guessed total of " +
                                   guesses.Length +
                                   " times.");
                break;
            }
            else if (numGuesses >= 20)
            {
                Console.WriteLine("You have guessed too many times. You lost");
                Console.WriteLine("Right answer was " + word);
                break;
            }
            
            // Asking for guess from user.
            Console.Write("Guess a character: ");
            string guess = Console.ReadLine().ToLower();
            
            // If user has guessed only one character we add it into array of 
            // guessed characters.
            if (guess.Length > 1)
            {
                // If guess equals word then user has win. Otherwise user loses.
                if (guess == word)
                {
                    Console.WriteLine("You have guessed the whole word correctly!");
                    Console.WriteLine("Right answer was " + word);
                    break;
                }
                else
                {
                    Console.WriteLine("Your answer was wrong! You lost!");
                    Console.WriteLine("Right answer was " + word);
                    break;
                }
            }
            else
            {
                bool allreadyGuessed = false;
                
                // Checking if character has been guessed allready and if so do
                // not count that as guess. Also inform user about situation.
                foreach (char guessCharacter in guesses)
                {
                    if (guess[0] == guessCharacter)
                    {
                        allreadyGuessed = true;
                        break;
                    }
                }
                if (!allreadyGuessed)
                {
                    Array.Resize(ref guesses, guesses.Length + 1);
                    guesses[guesses.Length - 1] = guess[0];
                    // Incrementing numGuesses.
                    numGuesses++;
                }
                else
                {
                    Console.WriteLine("You have allready guessed that character!");
                }
            }
        }
    }
}
