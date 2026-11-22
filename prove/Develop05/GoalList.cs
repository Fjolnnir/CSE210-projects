using System;
using System.Collections.Generic;
using System.Text;

public class GoalList
{
    private List<Goal> _goalList;
    private int _pointsEarned;
    private List<Milestones> _milestonesEarned;
    private List<Milestones> _existingMilestones;

    public GoalList()
    {
        _goalList = new List<Goal>();
        _pointsEarned = 0;
        _milestonesEarned = new List<Milestones>();
        _existingMilestones = new List<Milestones>
        {
            new Milestones("Bronze Apprentice", 500),
            new Milestones("Silver Disciple", 1500),
            new Milestones("Gold Champion", 3000),
            new Milestones("Level 13 Ninja Unicorn", 5000)
        };
    }

    public void AddGoal(Goal goal) => _goalList.Add(goal);
    public void RemoveGoal(Goal goal) => _goalList.Remove(goal);
    public List<Goal> GetGoalList() => _goalList;
    public List<Milestones> GetEarnedMilestones() => _milestonesEarned;
    public int GetPoints() => _pointsEarned;

    public void AddPoints(int points)
    {
        _pointsEarned += points;
        CheckMilestones();
    }

    private void CheckMilestones()
    {
        foreach (var milestone in _existingMilestones)
        {
            if (_pointsEarned >= milestone.GetPointRequirement() && !_milestonesEarned.Exists(m => m.GetName() == milestone.GetName()))
            {
                _milestonesEarned.Add(milestone);
                Console.WriteLine($"\n*** MILESTONE UNLOCKED: {milestone.GetName()} ({milestone.GetPointRequirement()} pts)! ***");
            }
        }
    }

    public void CompleteGoal(Goal goal)
    {
        int earned = goal.Complete();
        if (earned > 0)
        {
            Console.WriteLine($"Congratulations! You earned {earned} points!");
            AddPoints(earned);
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    public string GetSaveInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Score|{_pointsEarned}");

        foreach (Goal goal in _goalList)
        {
            sb.AppendLine(goal.GetSaveInfo());
        }

        return sb.ToString();
    }
}