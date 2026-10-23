using System;
using System.Collections.Generic;

/// <summary>
/// Tracks the reference and the text of the scripture.
/// </summary>
public class Scripture
{
    private Reference _reference;
    private string _verse;

    /// <summary>
    /// Constructor that starts the scripture object by storing its associated reference and verse text.
    /// </summary>
    public Scripture(Reference reference, string verse)
    {
        _reference = reference;
        _verse = verse;
    }

    /// <summary>
    /// Returns the full text string of the scripture verse.
    /// </summary>
    public string GetVerse()
    {
        return _verse;
    }

    /// <summary>
    /// Returns Reference object tied to this scripture.
    /// </summary>
    public Reference GetReference()
    {
        return _reference;
    }

    /// <summary>
    /// Updates or changes the stored verse text.
    /// </summary>
    public void SetVerse(string verse)
    {
        _verse = verse;
    }

    /// <summary>
    /// Updates or changes the stored reference info
    /// </summary>
    public void SetReference(Reference reference)
    {
        _reference = reference;
    }

    /// <summary>
    /// Breaks down the scripture string into individual words and returns as a collection.
    /// </summary>
    public List<Word> GetWordList()
    {
        // TODO: Split _verse string into Word objects
        return new List<Word>();
    }
}