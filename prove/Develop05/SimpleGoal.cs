public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int pointValue, bool completed = false) 
        : base(name, pointValue, "SimpleGoal")
    {
        _completed = completed;
    }

    public override int Complete()
    {
        if (!_completed)
        {
            _completed = true;
            return _pointValue;
        }
        return 0; // Already completed
    }

    public override string GetSaveInfo()
    {
        return $"{_goalType}|{_name}|{_pointValue}|{_completed}";
    }
}