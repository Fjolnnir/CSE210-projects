using System;

class Program
{
    // Exceeding Requirements Explanation:
    // 1. Implemented a session activity log tracking how many times each activity was performed.
    // 2. Implemented a randomized tracking mechanism ensuring no prompts/questions are repeated until all have been used at least once per session.
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
    }
}