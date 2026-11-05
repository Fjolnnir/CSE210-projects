using System;

class Activity
{
    protected string _startingMessage;
    protected string _activityName;
    protected string _activityDescription;
    protected string _finishedMessage;
    protected int _activityDuration;
    protected int _pauseDuration;

    public Activity(string activityName, string activityDescription)
    {
        // Sets shared activity name, description, and default pause duration.
    }

    public void Pause()
    {
        // Pauses execution for a specified number of seconds.
    }

    public void DisplayStartMessage()
    {
        // Clears screen, displays welcome name, description, prompts for duration, 
        // and displays a "Get ready..." spinner.
    }

    public void DisplayFinishedMessage()
    {
        // Displays a well-done message, spinner, and summarizes completed duration and activity name.
    }

    public void StartActivity()
    {
        // Template method coordinating start message, core activity execution, and finish message.
    }

    public int PromptForDuration()
    {
        // Asks user to enter activity duration in seconds, validates input, and returns it.
    }

    public void DisplayDuration()
    {
        // Helper method to format and print remaining or elapsed duration.
    }

    public void Timer()
    {
        // Displays a countdown timer counting down from a given number of seconds.
    }
}