public class NormalAssignment : Assignment
{
    private int _score;
    private bool _late;
    private bool _submitted;
    public NormalAssignment(string name, DateTime due_date, int max_points, int score, bool submitted, bool late) : base(name, due_date, max_points)
    {
        _score = score;
        _late = late;
        _submitted = submitted;
    }
}