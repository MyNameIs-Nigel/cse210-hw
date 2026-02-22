using System.ComponentModel;

public class Scripture
{
    private List<Reference> _refList;
    private List<Word> _words = new List<Word>();
    private Random _rng = new Random();
    private Reference _ref;
    private Obtain _obtain = new Obtain(); 
    private bool _allhidden;
    public Scripture()
    {
        // _refList = _obtain.SetReferenceFromFile();
        _ref = new Reference();
        
    }



    public void ChooseRef(int choice)
    {
        _ref = _refList[choice - 1];
    }

    public int CountWords()
    {
        return _words.Count();
    }

    public string ReturnReference()
    {
        return _ref.RefToString();
    }
    public bool CheckAllHidden()
    {
        return _allhidden;
    }
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