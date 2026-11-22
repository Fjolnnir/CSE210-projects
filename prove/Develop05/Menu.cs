using System;
using System.Collections.Generic;

public class Menu
{
    private List<string> _options;
    private GoalList _goalList;
    private FileManager _fileManager;

    public Menu()
    {
        _goalList = new GoalList();
        _fileManager = new FileManager();
        _options = new List<string>
        {
            "1. Create New Goal",
            "2. List Goals",
            "3. Save Goals",
            "4. Load Goals",
            "5. Record Event",
            "6. View Earned Milestones",
            "7. Quit"
        };
    }

    public void Display()
    {
        Console.WriteLine($"\n=== You have {_goalList.GetPoints()} points ===");
        foreach (string option in _options)
        {
            Console.WriteLine(option);
        }
        Console.Write("Select a choice from the menu: ");
    }

    public void HandleUserInput()
    {
        string choice = "";
        while (choice != "7")
        {
            Display();
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    _fileManager.Save(_goalList);
                    break;
                case "4":
                    _goalList = _fileManager.Load();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayMilestones();
                    break;
                case "7":
                    Console.WriteLine("Keep up the Eternal Quest! Goodbye.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goalList.AddGoal(new SimpleGoal(name, points));
        }
        else if (type == "2")
        {
            _goalList.AddGoal(new EternalGoal(name, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goalList.AddGoal(new ChecklistGoal(name, points, bonus, target));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        var goals = _goalList.GetGoalList();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].Display();
        }
    }

    private void RecordEvent()
    {
        var goals = _goalList.GetGoalList();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
        {
            _goalList.CompleteGoal(goals[index - 1]);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void DisplayMilestones()
    {
        Console.WriteLine("\nUnlocked Milestones:");
        var earned = _goalList.GetEarnedMilestones();
        if (earned.Count == 0)
        {
            Console.WriteLine("None yet. Keep earning points!");
            return;
        }

        foreach (var m in earned)
        {
            Console.WriteLine($"- {m.GetName()} ({m.GetPointRequirement()} pts)");
        }
    }
}