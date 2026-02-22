public class Word
{
    private string _rawtext;

    private bool _isHidden;

    private string _hiddentext;

    public Word()
    {
        _isHidden = false;
    }

    public void SetWord(string word)
    {
        _rawtext = word;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        foreach (char _letter in _rawtext)
        {
            if (Char.IsLetter(_letter))
            {
                _hiddentext += "_";
            }
            else
            {
                _hiddentext += _letter;
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