public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int score): base(title, description, score)
    {
        
    }

    public override string GoalToString()
    {
        return $"SimpleGoal:{_title},{_desc},{_score}";
    }
}