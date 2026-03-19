public class SimpleGoal : Goal
{
    private bool _complete;

    public SimpleGoal(string title, string description, int score) : base(title, description, score)
    {
        _complete = false;
    }
    public SimpleGoal(string title, string description, int score, bool complete) : base(title, description, score)
    {
        _complete = complete;
    }

    public override int CompleteGoal()
    {
        if (_complete)
        {
            return 0;
        }
        else
        {
            _complete = true;
            return _score;
        }
    }

    public override string GoalToString()
    {
        if (_complete)
        {
            return $"SimpleGoal:{_title},{_desc},{_score},True";
        }
        else
        {
            return $"SimpleGoal:{_title},{_desc},{_score},False";
        }
    }

    public override string GoalPretty()
    {
        string completeChar = " ";
        if (_complete)
        {
            completeChar = "X";
        }

        return $"[{completeChar}] {_title} ({_desc})";
    }
}