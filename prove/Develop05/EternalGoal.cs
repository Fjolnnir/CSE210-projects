using System;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, int pointValue, int timesCompleted = 0) 
        : base(name, pointValue, "EternalGoal")
    {
        _timesCompleted = timesCompleted;
    }

    public override int Complete()
    {
        _timesCompleted++;
        return _pointValue;
    }

    public int GetTimesCompleted() => _timesCompleted;

    public override void Display()
    {
        Console.WriteLine($"[ ] {_name} ({_pointValue} pts) -- Completed {_timesCompleted} times");
    }

    public override string GetSaveInfo()
    {
        return $"{_goalType}|{_name}|{_pointValue}|{_timesCompleted}";
    }
}