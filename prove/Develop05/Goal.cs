abstract public class Goal
{
    protected string _title;
    protected string _desc;
    protected int _score;

    public Goal(string title, string description, int score)
    {
        _title = title;
        _desc = description;
        _score = score;
    }

    public abstract string GoalToString();

    public virtual string GoalPretty()
    {
        return $"[ ] {_title} ({_desc})";
    }
}