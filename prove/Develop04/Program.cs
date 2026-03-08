using System;

class Program
{
    static void Main(string[] args)
    {
        // Main While Loop, for the Program
        string choice = "";
        Console.Clear();
        while (choice != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity\n  2. Reflecting Activity\n  3. Listing Activity\n  4. Quit");
            Console.Write("Choose an Activity to start: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // to do
                    Breathing breathing = new Breathing();
                    // Console.WriteLine("Breathing Chosen");

                    breathing.DisplayActivity();

                    break;
                case "2":
                    Console.WriteLine("Reflecting Chosen");
                    break;
                case "3":
                    Console.WriteLine("Listing Chosen");
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Incorrect Choice");
                    break;                
            }
        }
    }
}