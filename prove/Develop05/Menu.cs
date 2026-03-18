using System.Dynamic;
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
                    WriteColor("Create a Simple Goal",ConsoleColor.Red);
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
                    break;
                case "4":
                    break;
                default:
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

        WriteColor("\nPress enter when finished ", ConsoleColor.Cyan);
        Console.ReadLine();
    }
    
    public void WriteColor(string text_to_write, ConsoleColor color)
    {
        ConsoleColor original_color = Console.ForegroundColor;

        Console.ForegroundColor = color;

        Console.Write(text_to_write);

        Console.ForegroundColor = original_color;
    }

}