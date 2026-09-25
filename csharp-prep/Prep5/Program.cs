using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message
        DisplayWelcome();

        // Get user details
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        // Get birth year using out parameter
        int birthYear;
        PromptUserBirthYear(out birthYear);

        // Square the favorite number
        int numberSquared = SquareNumber(userNumber);

        // Display final output
        DisplayResult(userName, numberSquared, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        int currentYear = DateTime.Now.Year;
        int ageThisYear = currentYear - birthYear;

        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {ageThisYear} this year.");
    }
}