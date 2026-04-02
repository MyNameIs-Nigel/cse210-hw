public abstract class Assignment
{
    private string _name;
    private DateTime _due;
    private double _points;
    public Assignment(string name, DateTime due_date, double max_points)
    {
        _name = name;
        _due = due_date;
        _points = max_points;
    }
}