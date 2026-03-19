using System.Reflection;

public class ChecklistGoal : Goal
{
    private int _count;
    private int _complete;
    private int _bonus;
    private bool _supercomplete;
    public ChecklistGoal(string title, string description, int score_for_every, int goal_count, int bonus_score) : base(title, description, score_for_every)
    {
        _supercomplete = false;
        _complete = 0;
        _count = goal_count;
        _bonus = bonus_score;
    }
    public ChecklistGoal(string title, string description, int score_for_every, int goal_count, int bonus_score, int complete) : base(title, description, score_for_every)
    {
        _complete = complete;
        _count = goal_count;
        _bonus = bonus_score;

        if (complete == goal_count)
        {
            _supercomplete = true;
        }
        else
        {
            _supercomplete = false;
        }
    }
    public override int CompleteGoal()
    {
        if (_complete == _count)
        {
            return 0;
        }
        else
        {
            if (_complete == _count - 1)
            {
                _complete++;
                return _score + _bonus;
            }
            else
            {
                _complete++;
                return _score;
            }

        }
    }

    public override string GoalToString()
    {
        return $"ChecklistGoal:{_title},{_desc},{_score},{_bonus},{_count},{_complete}";
    }

    public override string GoalPretty()
    {
        string completeChar = " ";
        if (_complete == _count)
        {
            completeChar = "X";
        }

        return $"[{completeChar}] {_title} ({_desc}) - [{_complete} / {_count}]";
    }
}