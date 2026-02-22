public class Reference
{
    private string _book;
    private int _chapter;
    private List<int> _verses;

    private bool _consecutive;
    private string _text;

    public Reference()
    {
        _book = "Jacob";
        _chapter = 2;
        _verses = new List<int> {18, 19};
        _consecutive = true;
        _text = "But before ye seek for riches, seek ye for the kingdom of God. And after ye have obtained a hope in Christ ye shall obtain riches, if ye seek them; and ye will seek them for the intent to do good—to clothe the naked, and to feed the hungry, and to liberate the captive, and administer relief to the sick and the afflicted.";
    }

    public void SetRef(string book, int chapter, List<int> verses, bool consectutive, string text)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
        _consecutive = consectutive;
        _text = text;
    }
    public List<string> GetTextAsList()
    {
        List<string> _words = _text.Split(" ").ToList();
        return _words;
    }
    public string RefToString()
    {
        if (_consecutive)
        {
            return $"{_book} {_chapter}:{_verses[0]}-{_verses[^1]}";
        }
        else
        {
            string verseRef = "";

            foreach (int verse in _verses)
            {
                verseRef += $"{verse},";
            }

            return $"{_book} {_chapter}:{verseRef[..^1]}";
        }
    }
    
}