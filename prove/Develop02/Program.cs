using System;

class Program
{

    static void Main(string[] args)
    {
        // Create the journal variable!
        Journal _journal = new Journal();

        // Start the index at 1
        _journal._jindex = 1; 


        // Menu Options for the main menu, and input!
        string MainMenu()
        {
            Console.WriteLine("-- Menu Options: --");
            Console.WriteLine("1: Write Entry");
            Console.WriteLine("2: Display Entries");
            Console.WriteLine("3: Load Entries");
            Console.WriteLine("4: Save Entries");
            Console.WriteLine("5: Exit");
            Console.WriteLine("-------------------");
            Console.Write(">");
            string _menuchoice = Console.ReadLine();

            // return the choice as a string!
            return _menuchoice;
        }

        // Menu options for the secondary menu, when deciding to print one entry or ALL
        void DisplayMenu()
        {
            Console.WriteLine("Do you want to display a specific entry[1]? Or ALL[2]?");
            Console.Write(">");
            string displaychoice = Console.ReadLine();
            if (displaychoice == "1")
            {
                _journal.DisplayEntry();
            }
            else if (displaychoice == "2")
            {
                foreach (Entry entry in _journal._entries)
                    {
                        entry.Display();
                    }
            }
            else Console.WriteLine("Invalid Option! Please try again.");
        }

        // Function to create new entries

        void WriteNewEntry()
        {
            _journal.AddEntry(_journal._jindex);
            _journal._jindex++;
        }


        // Main Loop for the Program:

        string choice = "";
        while (choice != "5")
        {
            // Call the MainMenu to get a new choice
            choice = MainMenu();

            switch (choice)
            {
                case "1": 
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayMenu();
                    break;
                case "3":
                    _journal.LoadJournal();
                    break;
                case "4":
                    _journal.SaveJournal();
                    break;
                default:
                    Console.WriteLine("Invalid Option! Please try again.");
                    break;
            
            }
        }
    }

}