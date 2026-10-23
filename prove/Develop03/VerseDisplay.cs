using System;
using System.Collections.Generic;

/// <summary>
/// Manages visual state of verse during memorization.
/// </summary>
public class VerseDisplay
{
    private List<Word> _words;
    private int _unhiddenWords;

    /// <summary>
    /// takes a scripture instance and prepares its words to be tracked and hidden during
    /// memorization exercise.
    /// </summary>
    public VerseDisplay(Scripture memorizedScripture)
    {
        // TODO: Populate _words using memorizedScripture.GetWordList()
    }

    /// <summary>
    /// Randomly selects active word that is still visible and marks it hidden.
    /// </summary>
    public void HideRandomWord()
    {
        // TODO: Add random selection logic to hide visible words
    }

    /// <summary>
    /// Generate and returns the formatted text string for the console, 
    /// show visible words and replacing hidden words with underscores.
    /// </summary>
    public string GetDisplayString()
    {
        // TODO: Loop over _words and build display string with underscores for hidden words
        return string.Empty;
    }

    /// <summary>
    /// Grabs a specific word element from the collection.
    /// </summary>
    public string GetWord()
    {
        // TODO: Fetch single word representation
        return string.Empty;
    }

    /// <summary>
    /// Keep track and manages how many words are still visible to the user.
    /// </summary>
    public int GetUnhiddenWords()
    {
        return _unhiddenWords;
    }

    /// <summary>
    /// Sets count of unhidden words remaining.
    /// </summary>
    public void SetUnhiddenWords(int count)
    {
        _unhiddenWords = count;
    }
}