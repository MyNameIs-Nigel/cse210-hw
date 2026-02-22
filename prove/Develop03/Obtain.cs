public class Obtain
{
    private string _filepath;
    public Obtain()
    {
        _filepath = "scriptures.txt";
    }

    public Obtain(string filepath)
    {
        _filepath = filepath;
    }
    public List<Reference> SetReferenceFromFile()
    {
        List<Reference> _refList = new List<Reference>(); 
        // Console.Clear();
        // Console.WriteLine("Please choose from the list:");
        string[] mlines = File.ReadAllLines(_filepath);
        List<string> lines = mlines.Skip(1).ToList();
        for (int i = 0; i < lines.Count(); i++)
        {
            bool consecutive = false;
            List<string> _reference = lines[i].Split("|").ToList();
            List<int> verses = new List<int>();
            string book = _reference[0];
            int chapter = int.Parse(_reference[1]);
            string text = _reference[4];
            foreach (string verse in _reference[2].Split(","))
            {
                verses.Add(int.Parse(verse));
            }
            if (_reference[3] == "false")
            {
                consecutive = false;
            }
            else if (_reference[3] == "true")
            {
                consecutive = true;
            }
            else
            {
                Console.WriteLine("Error! Your file is in poor format!");
            }

            Reference reference = new Reference(book, chapter, verses, consecutive, text);

            _refList.Add(reference);
        }
        return _refList;
    }

    public void DisplayChoices(List<Reference> _refList)
    {
        for (int i = 0; i < _refList.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {_refList[i].RefToString()}");
        }
    }
}