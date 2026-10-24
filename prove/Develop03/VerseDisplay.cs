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
    /// Takes a scripture instance and prepares its words to be tracked and hidden during
    /// memorization exercise.
    /// </summary>
    public VerseDisplay(Scripture memorizedScripture)
    {
        _words = memorizedScripture.GetWordList();
        _unhiddenWords = _words.Count;
    }

    /// <summary>
    /// Randomly selects active word that is still visible and marks it hidden (Stretch Challenge: selects only from unhidden words).
    /// </summary>
    public void HideRandomWord()
    {
        List<Word> availableWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                availableWords.Add(word);
            }
        }

        if (availableWords.Count > 0)
        {
            Random random = new Random();
            int index = random.Next(availableWords.Count);
            Word selectedWord = availableWords[index];
            selectedWord.HideWord();
            _unhiddenWords = _unhiddenWords - 1;
        }
    }

    /// <summary>
    /// Generate and returns the formatted text string for the console, 
    /// showing visible words and replacing hidden words with underscores.
    /// </summary>
    public string GetDisplayString()
    {
        string displayStr = "";
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                string underscores = "";
                for (int i = 0; i < word.GetWord().Length; i++)
                {
                    underscores += "_";
                }
                displayStr += underscores + " ";
            }
            else
            {
                displayStr += word.GetWord() + " ";
            }
        }
        return displayStr.Trim();
    }

    /// <summary>
    /// Grabs a specific word element from the collection.
    /// </summary>
    public string GetWord()
    {
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