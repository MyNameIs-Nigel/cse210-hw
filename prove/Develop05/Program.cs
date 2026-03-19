using System;

class Program
{

    static void Main(string[] args)
    {
        Menu run = new Menu(0);
        string choice = "";
        while (choice != "6")
        {    
            Console.Clear();
            
            Console.Write("Welcome to the ");
            run.WriteColor("GoalPlanner", ConsoleColor.Red);
            Console.Write(" application!");
            
            Console.WriteLine($"\nYou currently have {run.GetPoints()} points.");

            Console.WriteLine("\nMenu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    run.GoalMenu();
                    break;
                case "2":
                    run.ListGoals();
                    break;
                case "3":
                    run.SaveGoals("goals.txt");
                    break;
                case "4":
                    run.LoadGoals("goals.txt");
                    break;
                case "5":
                    run.RecordEvent();
                    break;
                case "6":
                run.WriteColor("Goodbye!",ConsoleColor.Cyan);
                    break;
                default:
                    break;
            }
        }
        
    }
}