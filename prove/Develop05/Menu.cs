using System.Dynamic;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;

public class Menu
{
    private List<Goal> _goals = new List<Goal>();
    private string _menu;

    private int _points;
    public Menu(int starting_points)
    {
        _points = starting_points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void GoalMenu()
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            WriteColor("Create a Goal",ConsoleColor.Red);
            Console.WriteLine("\n\n\nGoal Options:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\n  4. Go Back");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    WriteColor("Create a Simple Goal",ConsoleColor.Red);
                    Console.Write("\n\nGoal Name: ");
                    string sname = Console.ReadLine();
                    Console.Write("Goal Description (short): ");
                    string sdesc = Console.ReadLine();
                    Console.Write("Points Gained (on completion): ");
                    int sscore = int.Parse(Console.ReadLine());

                    Goal simple = new SimpleGoal(sname, sdesc, sscore);

                    _goals.Add(simple);
                    break;
                case "2":
                    Console.Clear();
                    WriteColor("Create an Eternal Goal",ConsoleColor.Red);
                    Console.Write("\n\nGoal Name: ");
                    string ename = Console.ReadLine();
                    Console.Write("Goal Description (short): ");
                    string edesc = Console.ReadLine();
                    Console.Write("Points Gained (every time you complete): ");
                    int escore = int.Parse(Console.ReadLine());

                    EternalGoal eternal = new EternalGoal(ename, edesc, escore);

                    _goals.Add(eternal);
                    break;
                case "3":
                    Console.Clear();
                    WriteColor("Create a Checklist Goal",ConsoleColor.Red);
                    Console.Write("\n\nGoal Name: ");
                    string cname = Console.ReadLine();
                    Console.Write("Goal Description (short): ");
                    string cdesc = Console.ReadLine();
                    Console.Write("Points Gained (every time you complete): ");
                    int cscore = int.Parse(Console.ReadLine());
                    Console.Write("Goal Count (number of times to be completed): ");
                    int ctotal = int.Parse(Console.ReadLine());
                    Console.Write($"Bonus Points (upon finishing all {ctotal}): ");
                    int cbonus = int.Parse(Console.ReadLine());

                    ChecklistGoal checklist = new ChecklistGoal(cname, cdesc, cscore, ctotal, cbonus);

                    _goals.Add(checklist);
                    break;
                case "4":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Input! Press enter and try again!");
                    Console.ReadLine();
                    break;
            }

        }
    }

    public void ListGoals()
    {
        Console.Clear();
        WriteColor("Goals List", ConsoleColor.Red);

        Console.WriteLine("\nGoals:");
        int i = 0;
        foreach (Goal goal in _goals)
        {
            i++;
            Console.WriteLine($"{i}. {goal.GoalPretty()}");
        }
        if (_goals.Count() == 0)
        {
            Console.WriteLine("You have no goals! Go make some! Be productive or something. ");
        }

        WriteColor("\nPress enter when finished ", ConsoleColor.Cyan);
        Console.ReadLine();
    }
    
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_points);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GoalToString());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();

        string[] plines = System.IO.File.ReadAllLines(filename);

        _points = int.Parse(plines[0]);

        List<string> lines = new List<string>(plines);

        lines.RemoveAt(0);

        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            string goalType = parts[0];
            string data = parts[1];


            if (goalType == "SimpleGoal")
            {
                string[] subparts = data.Split(",");
                string title = subparts[0];
                string desc = subparts[1];
                int score = int.Parse(subparts[2]);
                bool complete;

                if (subparts[3] == "False")
                {
                    complete = false;
                }
                else
                {
                    complete = true;
                }

                SimpleGoal simple = new SimpleGoal(title, desc, score, complete);
                _goals.Add(simple);
            }
            else if (goalType == "EternalGoal")
            {
                string[] subparts = data.Split(",");
                string title = subparts[0];
                string desc = subparts[1];
                int score = int.Parse(subparts[2]);

                EternalGoal eternal = new EternalGoal(title, desc, score);
                _goals.Add(eternal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string[] subparts = data.Split(",");
                string title = subparts[0];
                string desc = subparts[1];
                int score = int.Parse(subparts[2]);
                int bonus = int.Parse(subparts[3]);
                int count = int.Parse(subparts[4]);
                int complete = int.Parse(subparts[5]);

                ChecklistGoal checklist = new ChecklistGoal(title, desc, score, count, bonus, complete);
                _goals.Add(checklist);
            }
            else
            {
                Console.WriteLine($"Error Reading {line}.. Invalid goalType");
            }
        }
    }

    public void RecordEvent()
    {
        Console.Clear();
        WriteColor("Record an Event", ConsoleColor.Red);

        Console.WriteLine("\nGoals:");
        int i = 0;
        foreach (Goal goal in _goals)
        {
            i++;
            Console.WriteLine($"{i}. {goal.GoalPretty()}");
        }
        if (_goals.Count() == 0)
        {
            Console.WriteLine("You have no goals! Go make some! Be productive or something. ");
            WriteColor("\nEnter to Continue ", ConsoleColor.Cyan);        
        }
        else
        {
            Console.Write("Goal to Record: ");
            // int chosenIndex = int.Parse(Console.ReadLine());
            int chosenIndex;
            string attempt = Console.ReadLine();
            if (int.TryParse(attempt, out chosenIndex) == false) {
                Console.Write("Uh oh! That isn't a valid number... Try again! (hit enter to continue)");
                Console.ReadLine();
            }
            else
            {
                if (chosenIndex > _goals.Count() || chosenIndex < 1)
                {
                    Console.WriteLine("Uh oh! That number isn't an option... Try again! (hit enter to continue)");
                    Console.ReadLine();
                }
                else
                {
                    _points = _points + _goals[chosenIndex - 1].CompleteGoal();
                }
            }
        }
    }

    public void WriteColor(string text_to_write, ConsoleColor color)
    {
        ConsoleColor original_color = Console.ForegroundColor;

        Console.ForegroundColor = color;

        Console.Write(text_to_write);

        Console.ForegroundColor = original_color;
    }

}