using System;
using System.IO;

public class FileManager
{
    private string _saveLocation;

    public FileManager(string saveLocation = "goals.txt")
    {
        // Automatically stores the full folder path right when FileManager is created
        _saveLocation = Path.GetFullPath(saveLocation);
    }

    public void Save(GoalList goalList)
    {
        Console.Write($"Enter filename (default '{Path.GetFileName(_saveLocation)}'): ");
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            _saveLocation = Path.GetFullPath(input);
        }

        System.IO.File.WriteAllText(_saveLocation, goalList.GetSaveInfo());

        Console.WriteLine($"\nGoals saved successfully to:\n{_saveLocation}");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine(); // Pauses so the message doesn't scroll away
    }

    public GoalList Load()
    {
        Console.Write($"Enter filename (default '{Path.GetFileName(_saveLocation)}'): ");
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            _saveLocation = Path.GetFullPath(input);
        }

        GoalList loadedList = new GoalList();

        if (!System.IO.File.Exists(_saveLocation))
        {
            Console.WriteLine($"\nSave file not found at:\n{_saveLocation}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return loadedList;
        }

        string[] lines = System.IO.File.ReadAllLines(_saveLocation);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string type = parts[0];

            switch (type)
            {
                case "Score":
                    loadedList.AddPoints(int.Parse(parts[1]));
                    break;
                case "SimpleGoal":
                    loadedList.AddGoal(new SimpleGoal(parts[1], int.Parse(parts[2]), bool.Parse(parts[3])));
                    break;
                case "EternalGoal":
                    loadedList.AddGoal(new EternalGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    loadedList.AddGoal(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    break;
            }
        }

        Console.WriteLine($"\nGoals loaded successfully from:\n{_saveLocation}");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        return loadedList;
    }
}