public class Assignment
{
    protected string _studentName;
    private string _topic;

    public Assignment()
    {
        _studentName = "Nigel Smith";
        _topic = "Fractions";
    }
    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}