using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

        // Loop to collect numbers until user enters 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            // Only add to the list if it's not the terminating 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Core Requirement 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Core Requirement 2: Compute the average
        // Cast sum to float or double to maintain precise decimal point calculation
        double average = (double)sum / numbers.Count;

        // Core Requirement 3: Find the maximum number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Output results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}