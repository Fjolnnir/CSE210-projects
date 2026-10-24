using System;

/// <summary>
/// Tracks scripture reference (book, chapter, verse).
/// </summary>
public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;

    /// <summary>
    /// Sets up the book, chapter, and verse details for a single verse reference.
    /// </summary>
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    /// <summary>
    /// Sets up the book, chapter, and verse range details for a multi-verse reference.
    /// </summary>
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse + "-" + endVerse;
    }

    /// <summary>
    /// Returns the formatted reference string (e.g., "Proverbs 3:5" or "Proverbs 3:5-6").
    /// </summary>
    public string GetDisplayText()
    {
        return _book + " " + _chapter + ":" + _verse;
    }

    /// <summary>
    /// Gets the book name ("Proverbs").
    /// </summary>
    public string GetBook() 
    { 
        return _book; 
    }

    /// <summary>
    /// Sets the book name
    /// </summary>
    public void SetBook(string book) 
    { 
        _book = book; 
    }

    /// <summary>
    /// Gets the chapter number as a string.
    /// </summary>
    public string GetChapter() 
    { 
        return _chapter; 
    }

    /// <summary>
    /// Sets the chapter number
    /// </summary>
    public void SetChapter(string chapter) 
    { 
        _chapter = chapter; 
    }

    /// <summary>
    /// Gets the verse number(s) as a string.
    /// </summary>
    public string GetVerse() 
    { 
        return _verse; 
    }

    /// <summary>
    /// Sets the verse number(s).
    /// </summary>
    public void SetVerse(string verse) 
    { 
        _verse = verse; 
    }
}