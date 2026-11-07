using System;
using System.Threading;

class BreathingActivity : Activity
{
    private int _breathInTime;
    private int _breathOutTime;

    public BreathingActivity(int breathInTime, int breathOutTime) : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breathInTime = breathInTime;
        _breathOutTime = breathOutTime;
    }

    public new void StartActivity()
    {
        DisplayStartMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            Timer(_breathInTime);
            Console.WriteLine();

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Now breathe out... ");
            Timer(_breathOutTime);
            Console.WriteLine();
        }

        DisplayFinishedMessage();
    }
}