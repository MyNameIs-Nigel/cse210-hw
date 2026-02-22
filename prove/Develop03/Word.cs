public class Word
{
    private string _rawtext;

    private bool _isHidden;

    private string _hiddentext;

    public Word(string text)
    {
        _rawtext = text;
        _isHidden = false;
    }

    public Word(string text, bool hidden)
    {
        _rawtext = text;
        _isHidden = hidden;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        foreach (char letter in _rawtext)
        {
            if (Char.IsLetter(letter))
            {
                _hiddentext += "_";
            }
            else
            {
                _hiddentext += letter;
            }
        }
        _isHidden = true;
    }
    
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return _hiddentext;
        }
        else
        {
            return _rawtext;
        }
    }
    
}