public class Grade
{
    private double _score;
    private string _letter;

    public Grade(double score, string letter)
    {
        _score = score;
        _letter = letter;
    }

    public double GetScore()
    {
        return _score;
    }

    public string GetLetter()
    {
        return _letter;
    }
}