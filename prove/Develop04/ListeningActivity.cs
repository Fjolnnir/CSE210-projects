using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _listingPrompts;
    private List<string> _entries;
    private List<string> _usedPrompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _listingPrompts = new List<string>();
        _listingPrompts.Add("Who are people that you appreciate?");
        _listingPrompts.Add("What are personal strengths of yours?");
        _listingPrompts.Add("Who are people that you have helped this week?");
        _listingPrompts.Add("When have you felt the Holy Ghost this month?");
        _listingPrompts.Add("Who are some of your personal heroes?");
        _listingPrompts.Add("How has God blessed you this week?");

        _entries = new List<string>();
        _usedPrompts = new List<string>();
    }

    public new void StartActivity()
    {
        DisplayStartMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        Timer(5);
        Console.WriteLine();

        _entries.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                _entries.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_entries.Count} items!");

        DisplayFinishedMessage();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count >= _listingPrompts.Count)
        {
            _usedPrompts.Clear();
        }

        Random random = new Random();
        string selectedPrompt = "";

        while (true)
        {
            int index = random.Next(_listingPrompts.Count);
            selectedPrompt = _listingPrompts[index];

            if (!_usedPrompts.Contains(selectedPrompt))
            {
                _usedPrompts.Add(selectedPrompt);
                break;
            }
        }

        return selectedPrompt;
    }
}