using System;
using System.Threading;

class Activity
{
    // Removed unused _startingMessage and _finishedMessage fields
    protected string _activityName;
    protected string _activityDescription;
    protected int _activityDuration;
    protected int _pauseDuration;

    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
        _pauseDuration = 3;
    }

    public void Pause()
    {
        Thread.Sleep(1000);
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        Console.WriteLine();
        _activityDuration = PromptForDuration();
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayFinishedMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_activityName}.");
        ShowSpinner(5);
    }

    public void StartActivity()
    {
        DisplayStartMessage();
        DisplayFinishedMessage();
    }

    public int PromptForDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        string input = Console.ReadLine();
        int duration = 0;
        bool success = int.TryParse(input, out duration);
        if (success && duration > 0)
        {
            return duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Defaulting to 10 seconds.");
            Thread.Sleep(2000);
            return 10;
        }
    }

    public void Timer(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinnerChars = new char[] { '|', '/', '-', '\\' };
        int counter = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[counter % spinnerChars.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            counter++;
        }
    }
}