using System;

class Program
{
    // Exceeding Requirements:
    // 1. put in a session logger that tracks and displays how many times each activity was performed during the program run.
    // 2. added a randomized tracking mechanism ensuring no prompts/questions are repeated until all have been used at least once per session.
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
    }
}