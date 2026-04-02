public class NormalAssignment : Assignment
{
    private double _score;
    private bool _late;
    private DateTime _submitted;

    private bool _graded;
    public NormalAssignment(string name, DateTime due_date, double max_points, double score, DateTime submission_date, bool late, bool graded) : base(name, due_date, max_points)
    {
        _score = score;
        _late = late;
        _submitted = submission_date;
        _graded = graded;
    }
}