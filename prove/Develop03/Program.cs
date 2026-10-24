using System;

class Program
{
    /// <summary>
    /// Main(string[] args)
    /// The Exceeding requirement is it pulls from a text file
    /// Entry point of the console application, kicking off execution and initializing the core components.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        
        Display display = new Display();
        display.HandleInput();
    }
}