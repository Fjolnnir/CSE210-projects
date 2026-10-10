using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void PresentPrompt(string prompt)
    {
        _promptText = prompt;
        Console.WriteLine($"\nPrompt: {_promptText}");
    }

    public void StoreResponse()
    {
        Console.Write("> ");
        _entryText = Console.ReadLine();
        _date = DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}\n");
    }
}