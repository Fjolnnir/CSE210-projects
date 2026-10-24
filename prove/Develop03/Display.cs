using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Displays the choices/actions to the user and manages flow.
/// </summary>
public class Display
{
    private List<Scripture> _scriptures;

    /// <summary>
    /// Initializes display and loads scriptures from an external file.
    /// </summary>
    public Display()
    {
        _scriptures = new List<Scripture>();
        LoadScripturesFromFile("scriptures.txt");
    }

    /// <summary>
    /// Loads scriptures from a file (Stretch Challenge / File Loading requirement).
    /// Format per line for single verse: Book|Chapter|Verse|Text
    /// Format per line for verse range: Book|Chapter|StartVerse|EndVerse|Text
    /// </summary>
    private void LoadScripturesFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    string book = parts[0];
                    string chapter = parts[1];
                    string verse = parts[2];
                    string text = parts[3];

                    Reference reference = new Reference(book, chapter, verse);
                    Scripture scripture = new Scripture(reference, text);
                    _scriptures.Add(scripture);
                }
                else if (parts.Length == 5)
                {
                    string book = parts[0];
                    string chapter = parts[1];
                    string startVerse = parts[2];
                    string endVerse = parts[3];
                    string text = parts[4];

                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    Scripture scripture = new Scripture(reference, text);
                    _scriptures.Add(scripture);
                }
            }
        }

        // Fallback default scripture if file is missing or empty
        if (_scriptures.Count == 0)
        {
            Reference defaultRef = new Reference("Proverbs", "3", "5", "6");
            string defaultText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
            _scriptures.Add(new Scripture(defaultRef, defaultText));
        }
    }

    /// <summary>
    /// Prints the user interface, menu choices, scripture text states, and prompts to the console.
    /// </summary>
    public void DisplayMenu()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        Scripture selectedScripture = _scriptures[index];
        VerseDisplay verseDisplay = new VerseDisplay(selectedScripture);

        string input = "";
        while (input.ToLower() != "quit" && verseDisplay.GetUnhiddenWords() > 0)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetReference().GetDisplayText() + " " + verseDisplay.GetDisplayString());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();

            if (input == null || input.ToLower() == "quit")
            {
                break;
            }

            int wordsToHide = 3;
            if (verseDisplay.GetUnhiddenWords() < wordsToHide)
            {
                wordsToHide = verseDisplay.GetUnhiddenWords();
            }

            for (int i = 0; i < wordsToHide; i++)
            {
                verseDisplay.HideRandomWord();
            }

            if (verseDisplay.GetUnhiddenWords() == 0)
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetReference().GetDisplayText() + " " + verseDisplay.GetDisplayString());
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Great job memorizing!");
                break;
            }
        }
    }

    /// <summary>
    /// Waits for user keyboard input, processes menu selections, and 
    /// determines whether to continue memorizing, display a new state, or exit.
    /// </summary>
    public void HandleInput()
    {
        DisplayMenu();
    }
}