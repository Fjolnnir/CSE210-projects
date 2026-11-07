using System;

class Menu
{
    private int _breathingCount;
    private int _reflectingCount;
    private int _listingCount;

    public Menu()
    {
        _breathingCount = 0;
        _reflectingCount = 0;
        _listingCount = 0;
    }

    public void DisplayMenu()
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            
            Console.WriteLine("[Session Activity Log]");
            Console.WriteLine($"  - Breathing Activities Completed: {_breathingCount}");
            Console.WriteLine($"  - Reflecting Activities Completed: {_reflectingCount}");
            Console.WriteLine($"  - Listing Activities Completed: {_listingCount}");
            Console.WriteLine();
            
            choice = GetChoice();

            if (choice == 1)
            {
                BreathingActivity breathing = new BreathingActivity(4, 4);
                breathing.StartActivity();
                _breathingCount = _breathingCount + 1;
            }
            else if (choice == 2)
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.StartActivity();
                _reflectingCount = _reflectingCount + 1;
            }
            else if (choice == 3)
            {
                ListingActivity listing = new ListingActivity();
                listing.StartActivity();
                _listingCount = _listingCount + 1;
            }
            else if (choice == 4)
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                Pause();
            }
        }
    }

    public int GetChoice()
    {
        Console.Write("Select a choice from the menu: ");
        string input = Console.ReadLine();
        int choice = 0;
        
        bool success = int.TryParse(input, out choice);
        if (success)
        {
            return choice;
        }
        else
        {
            return 0;
        }
    }

    public void Pause()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}