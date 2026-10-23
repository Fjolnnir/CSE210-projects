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
    /// sets up the book, chapter, and verse details for the scripture reference.
    /// </summary>
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    /// <summary>
    /// Gets the book name ("Proverbs").
    /// </summary>
    public string GetBook() { return _book; }

    /// <summary>
    /// Sets the book name
    /// </summary>
    public void SetBook(string book) { _book = book; }

    /// <summary>
    /// Gets the chapter number as a string.
    /// </summary>
    public string GetChapter() { return _chapter; }

    /// <summary>
    /// Sets the chapter number
    /// </summary>
    public void SetChapter(string chapter) { _chapter = chapter; }

    /// <summary>
    /// Gets the verse number(s) as a string.
    /// </summary>
    public string GetVerse() { return _verse; }

    /// <summary>
    /// Sets the verse number(s).
    /// </summary>
    public void SetVerse(string verse) { _verse = verse; }
}