using System;
using System.IO;

public class FileHandler
{
    public string _filePath;

    public void Save(Journal journal)
    {
        Console.Write("What is the filename? ");
        _filePath = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(_filePath))
        {
            foreach (Entry entry in journal._entries)
            {
                // Formats using '|~|' as a unique delimiter
                outputFile.WriteLine($"{entry._date}|~|{entry._promptText}|~|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void Load(Journal journal)
    {
        Console.Write("What is the filename? ");
        _filePath = Console.ReadLine();

        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        journal._entries.Clear();
        string[] lines = File.ReadAllLines(_filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { "|~|" }, StringSplitOptions.None);
            if (parts.Length == 3)
            {
                Entry loadedEntry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };
                journal.AddEntry(loadedEntry);
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}