public class Milestones
{
    private string _name;
    private int _pointCost;

    public Milestones(string name, int pointCost)
    {
        _name = name;
        _pointCost = pointCost;
    }

    public string GetName() => _name;
    public int GetPointRequirement() => _pointCost;

    public string GetSaveInfo()
    {
        return $"Milestone|{_name}|{_pointCost}";
    }
}