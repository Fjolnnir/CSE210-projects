using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 3: Generate a random magic number between 1 and 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // Step 2: Loop until the guess matches the magic number
        while (guess != magicNumber)
        {
            // Ask the user for their guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Step 1: Check if the guess is higher, lower, or correct
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}