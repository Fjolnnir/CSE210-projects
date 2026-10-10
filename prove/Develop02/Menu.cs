using System;

public class Menu
{
    public int _userInt;

    public void DisplayMenu(Journal journal, PromptGenerator promptGenerator, FileHandler fileHandler)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out _userInt))
            {
                switch (_userInt)
                {
                    case 1:
                        Write(journal, promptGenerator);
                        break;
                    case 2:
                        Display(journal);
                        break;
                    case 3:
                        Load(fileHandler, journal);
                        break;
                    case 4:
                        Save(fileHandler, journal);
                        break;
                    case 5:
                        running = Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a number from 1 to 5.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }
    }

    public void Write(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.ReadPrompt();
        Entry entry = new Entry();
        entry.PresentPrompt(prompt);
        entry.StoreResponse();
        journal.AddEntry(entry);
        Console.WriteLine();
    }

    public void Display(Journal journal)
    {
        journal.DisplayAll();
    }

    public void Load(FileHandler fileHandler, Journal journal)
    {
        fileHandler.Load(journal);
        Console.WriteLine();
    }

    public void Save(FileHandler fileHandler, Journal journal)
    {
        fileHandler.Save(journal);
        Console.WriteLine();
    }

    public bool Exit()
    {
        Console.WriteLine("Goodbye!");
        return false;
    }
}