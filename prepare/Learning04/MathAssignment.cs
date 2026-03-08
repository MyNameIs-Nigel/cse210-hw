public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string textbooksection, string problems): base(name, topic)
    {
        _textbookSection = textbooksection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}