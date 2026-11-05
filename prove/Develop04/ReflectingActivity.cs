using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _questions;
    private List<string> _followUpQuestions;

    public ReflectingActivity() : base("Reflecting Activity", "...")
    {
        // Populates lists of reflection prompts and follow-up questions.
    }

    public void DisplayQuestion()
    {
        // Selects and displays a random question, ensuring non-repetition until all are used (Exceeding requirement).
    }

    public string GetUserInput()
    {
        // Captures user confirmation or input during reflection stages.
    }
}