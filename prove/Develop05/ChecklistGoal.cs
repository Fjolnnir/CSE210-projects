using System;

public class ChecklistGoal : Goal
{
    private int _completionRequirement;
    private int _timesCompleted;
    private int _bonus;

    public ChecklistGoal(string name, int pointValue, int bonus, int completionRequirement, int timesCompleted = 0) 
        : base(name, pointValue, "ChecklistGoal")
    {
        _bonus = bonus;
        _completionRequirement = completionRequirement;
        _timesCompleted = timesCompleted;
        _completed = _timesCompleted >= _completionRequirement;
    }

    public override int Complete()
    {
        if (_completed) return 0;

        _timesCompleted++;
        int pointsEarned = _pointValue;

        if (_timesCompleted >= _completionRequirement)
        {
            _completed = true;
            pointsEarned += _bonus;
        }

        return pointsEarned;
    }

    public int GetBonus() => _bonus;
    public int GetTimesCompleted() => _timesCompleted;
    public int GetCompletionRequirement() => _completionRequirement;

    public override void Display()
    {
        string status = _completed ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_name} ({_pointValue} pts) -- Completed {_timesCompleted}/{_completionRequirement} times (Bonus: {_bonus} pts)");
    }

    public override string GetSaveInfo()
    {
        return $"{_goalType}|{_name}|{_pointValue}|{_bonus}|{_completionRequirement}|{_timesCompleted}";
    }
}