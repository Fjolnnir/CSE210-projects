using System;

public abstract class Goal
{
    protected bool _completed;
    protected string _name;
    protected int _pointValue;
    protected string _goalType;

    public Goal(string name, int pointValue, string goalType)
    {
        _name = name;
        _pointValue = pointValue;
        _goalType = goalType;
        _completed = false;
    }

    public abstract int Complete();
    public abstract string GetSaveInfo();

    public string GetName() => _name;
    public int GetPointValue() => _pointValue;
    public bool IsCompleted() => _completed;

    public virtual void Display()
    {
        string status = _completed ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_name} ({_pointValue} pts)");
    }
}