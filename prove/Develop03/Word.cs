using System;

/// <summary>
/// Tracks an individual word string and its hidden state
/// </summary>
public class Word
{
    private string _word;
    private bool _hidden;

    /// <summary>
    /// Initializes an individual word with its string value and sets its initial hidden status to false.
    /// </summary>
    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    /// <summary>
    /// Updates the text value of the word.
    /// </summary>
    public void SetWord(string word)
    {
        _word = word;
    }

    /// <summary>
    /// Retrieves the text value of the word.
    /// </summary>
    public string GetWord()
    {
        return _word;
    }

    /// <summary>
    /// Changes the internal state of the word so it knows it should now be hidden
    /// </summary>
    public void HideWord()
    {
        _hidden = true;
    }
}