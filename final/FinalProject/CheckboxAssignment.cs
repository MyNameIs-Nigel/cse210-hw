public class CheckboxAssignment : Assignment
{
    private bool _complete;
    public CheckboxAssignment(string name, DateTime due_date, int max_points, bool complete) : base(name, due_date, max_points)
    {
        _complete = complete;
    }
}