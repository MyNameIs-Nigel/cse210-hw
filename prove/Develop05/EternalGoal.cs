public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int score): base(title, description, score)
    {
        
    }

    public override int CompleteGoal()
    {
        return _score;
    }

    // public override string GoalPretty()
    // {
    //     return $"[ ] {_title} ({_desc}) ~eternal~";
    // }
    public override string GoalToString()
    {
        return $"EternalGoal:{_title},{_desc},{_score}";
    }
}