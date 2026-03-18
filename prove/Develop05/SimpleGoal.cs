public class SimpleGoal : Goal
{
    private bool _complete;

    public SimpleGoal(string title, string description, int score) : base(title, description, score)
    {
        _complete = false;
    }

    public override string GoalToString()
    {
        return $"SimpleGoal:{_title},{_desc},{_score},{_complete}";
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