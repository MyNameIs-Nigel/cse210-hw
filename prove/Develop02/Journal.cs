using System.IO;

public class Journal
{
    // not gonna lie, I give up on writing comments. Hopefully my code makes sense :P
    public List<Entry> _entries = new List<Entry>();

    public int _jindex;
    public void AddEntry(int index)
    {
        DateTime time = DateTime.Now;

        Prompt prompt = new Prompt();
        Entry currententry = new Entry();
        
        string defaultprompt = prompt.PromptGenerator();

        Console.Write($"Change Prompt from [{defaultprompt}]? (Hit Enter to keep this one!): ");
        string userprompt = Console.ReadLine();


        if (userprompt == "") currententry._prompt = defaultprompt;
        else currententry._prompt = userprompt; 


        Console.Write("Entry: ");
        currententry._response = Console.ReadLine();

        currententry._date = time.ToShortDateString();

        currententry._entryindex = index;

        Console.WriteLine($"Added Entry #{index} on {currententry._date}");


        _entries.Add(currententry);
    }

    public void DisplayEntry()
    {
        string choice;

        if (_entries.Count() > 0)
        {
            Console.Write($"Choose an entry from 1 to {_entries.Count()}: ");
            choice = Console.ReadLine();
            int chosenIndex = int.Parse(choice);
            
            
            if (chosenIndex <= _entries.Count() && chosenIndex >= 1 )
            {
            Entry chosenentry = new Entry();
            chosenentry = _entries[chosenIndex - 1];

            chosenentry._entryindex = chosenIndex;
            chosenentry.Display();

            }
            else
            {
                Console.WriteLine($"Out of range! You can only choose between 1 and {_entries.Count()}");
            }

        }
        else Console.WriteLine("No Entries found! Add some or load a file!");
    

        
    }

    public void SaveJournal()
    {
        string filename = "journal.csv";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // outputFile.WriteLine($"index,date,prompt,response");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date},{entry._prompt},{entry._response}");
            }
        }
    }

    public void LoadJournal()
    {
        string filename = "journal.csv";

        string[] lines = File.ReadAllLines(filename);

        int entrynum = _jindex;

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            Entry entry = new Entry();

            // entry._entryindex = int.Parse(parts[0]);
            entry._entryindex = entrynum;
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._response = parts[2];            

            _entries.Add(entry);

            entrynum++;

        }
    }

}




