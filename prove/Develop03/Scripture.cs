using System.ComponentModel;

public class Scripture
{
    // Random Class
    private Random _rng = new Random();

    // Reference Class
    private Reference _ref;
    
    // Word class
    private List<Word> _words;
    private bool _allhidden;

    // Constructors
    public Scripture()
    {
        // Without declaring a choice, use the default reference

        _ref = new Reference();
        _words = _ref.GetWords();
        _allhidden = false;
    }

    public Scripture(Reference reference)
    {

        _ref = reference;
        _words = _ref.GetWords();
        _allhidden = false;

    }

    // Setters
    public void SetReference(Reference reference)
    {
        _ref = reference;
        _words = _ref.GetWords();
        _allhidden = false;
    }

    // Method to get the total Display (Reference & Words)
    public string GetDisplayText()
    {
        string output = $"{_ref.RefToString()} - ";
        foreach (Word word in _words)
        {
            output += word.GetDisplayText();
            output += " ";
        }

        return output;
    }

    // Getters
    public bool CheckAllHidden()
    {
        return _allhidden;
    }
    public int CountWords()
    {
        return _words.Count();
    }
    public string ReferenceText()
    {
        return _ref.RefToString();
    }


    public void HideRandomWords(int count)
    {
        List<int> unhiddenIndex = new List<int>();

        for (int i = 0; i < _words.Count(); i++)
        {
            if (_words[i].IsHidden() == false)
            {
                unhiddenIndex.Add(i);
            }
        }

        if (_allhidden == false && count < unhiddenIndex.Count())
        {
            for (int i = 0; i < count; i++)
            {
                int tohide = _rng.Next(0, unhiddenIndex.Count() - 1);

                int indextohide = unhiddenIndex[tohide];

                _words[indextohide].HideWord();
                // Debug:
                // Console.WriteLine($"tohide: {indextohide}");
                unhiddenIndex.Remove(tohide);
            }
        } 
        else if (_allhidden == false && count >= unhiddenIndex.Count()) 
        {
            foreach (int indextohide in unhiddenIndex)
            {
                _words[indextohide].HideWord();
                _allhidden = true;
            }            
        }
        else
        {
            Console.WriteLine("Error!!!");
        }
    }
}