using System;

class Program
{
    static void Main()
    {
        // Prompt the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        double percent = double.Parse(Console.ReadLine());

        string letter;

        // Determine the letter grade using a single 'letter' variable
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Print the letter grade once
        Console.WriteLine($"Your letter grade is: {letter}");

        // Check if the user passed the course (70 or higher)
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard for next time.");
        }
    }
}