using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _questions;
    private List<string> _followUpQuestions;
    private List<string> _usedQuestions;

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _questions = new List<string>();
        _questions.Add("Think of a time when you stood up for someone else.");
        _questions.Add("Think of a time when you did something really difficult.");
        _questions.Add("Think of a time when you helped someone in need.");
        _questions.Add("Think of a time when you did something truly selfless.");

        _followUpQuestions = new List<string>();
        _followUpQuestions.Add("Why was this experience meaningful to you?");
        _followUpQuestions.Add("Have you ever done anything like this before?");
        _followUpQuestions.Add("How did you get started?");
        _followUpQuestions.Add("How did you feel when it was complete?");
        _followUpQuestions.Add("What made this time different than other times when you were not as successful?");
        _followUpQuestions.Add("What is your favorite thing about this experience?");
        _followUpQuestions.Add("What could you learn from this experience that applies to other situations?");
        _followUpQuestions.Add("What did you learn about yourself through this experience?");
        _followUpQuestions.Add("How can you keep this experience in mind in the future?");

        _usedQuestions = new List<string>();
    }

    public new void StartActivity()
    {
        DisplayStartMessage();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they are related to this experience.");
        Console.Write("You may begin in: ");
        Timer(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(6);
        }

        DisplayFinishedMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    private string GetRandomQuestion()
    {
        if (_usedQuestions.Count >= _followUpQuestions.Count)
        {
            _usedQuestions.Clear();
        }

        Random random = new Random();
        string selectedQuestion = "";

        while (true)
        {
            int index = random.Next(_followUpQuestions.Count);
            selectedQuestion = _followUpQuestions[index];

            if (!_usedQuestions.Contains(selectedQuestion))
            {
                _usedQuestions.Add(selectedQuestion);
                break;
            }
        }

        return selectedQuestion;
    }
}