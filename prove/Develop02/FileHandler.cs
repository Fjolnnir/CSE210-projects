using System;
using System.IO;

public class FileHandler
{
    public string _filePath;

    public void Save(Journal journal)
    {
        Console.Write("What is the filename? (e.g., journal.csv): ");
        _filePath = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(_filePath))
            {
                // Write CSV Header for Excel
                outputFile.WriteLine("Date,Prompt,Response");

                foreach (Entry entry in journal._entries)
                {
                    string date = EscapeCsvField(entry._date);
                    string prompt = EscapeCsvField(entry._promptText);
                    string response = EscapeCsvField(entry._entryText);

                    outputFile.WriteLine($"{date},{prompt},{response}");
                }
            }
            Console.WriteLine("Journal saved successfully to CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
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

        try
        {
            journal._entries.Clear();
            string[] lines = File.ReadAllLines(_filePath);

            // Skip header if present
            int startLine = 0;
            if (lines.Length > 0 && lines[0].StartsWith("Date,Prompt,Response"))
            {
                startLine = 1;
            }

            for (int i = startLine; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = ParseCsvLine(line);

                if (parts.Length >= 3)
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
            Console.WriteLine("Journal loaded successfully from CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    /// <summary>
    /// Escapes commas, quotes, and newlines for CSV format.
    /// Double quotes inside the string are replaced with "" and wrapped in quotes.
    /// </summary>
    private string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field)) return "\"\"";

        bool requiresQuotes = field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r");

        if (field.Contains("\""))
        {
            field = field.Replace("\"", "\"\"");
        }

        return requiresQuotes ? $"\"{field}\"" : field;
    }

    /// <summary>
    /// Parses a single line from a CSV file respecting quoted fields and internal quotes.
    /// </summary>
    private string[] ParseCsvLine(string line)
    {
        var fields = new System.Collections.Generic.List<string>();
        bool inQuotes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                // Check for escaped quotes ("") inside quotes
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField += '"';
                    i++; // Skip second quote
                }
                else
                {
                    inQuotes = !inQuotes; // Toggle quote mode
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }

        fields.Add(currentField);
        return fields.ToArray();
    }
}