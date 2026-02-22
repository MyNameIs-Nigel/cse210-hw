using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();

        List<string> quitList = new List<string> {"quit", "q", "exit"};

        int hideamt = 3;


        // Console.Write("Your choice: ");
        // int chosenReference = int.Parse(Console.ReadLine());


        Console.Write("Enter how many words to hide at a time: ");

        string attempt = Console.ReadLine();
        // scripture.ChooseRef(chosenReference);


        if (attempt.All(char.IsDigit) && string.IsNullOrEmpty(attempt) == false)
        {
            hideamt = int.Parse(attempt);
        }
        else
        {
            Console.WriteLine($"Error! Not a number. Defaulting to {hideamt}. Press Enter to continue.");
            Console.ReadLine();
        }

        string response = "";
        Console.Clear();
        Console.WriteLine("\n\n" + scripture.GetDisplayText());
        Console.WriteLine("\nPlease Press Enter to Continue, or type quit/q/exit to exit!");

        while (quitList.Contains(response) == false)
        {

            response = Console.ReadLine().ToLower();
            Console.Clear();
            if (scripture.CheckAllHidden())
            {
                Console.WriteLine($"\n\nCongrats! You've memorized {scripture.ReturnReference()}\n");
                Console.WriteLine($"Which was {scripture.CountWords()} words long!\n");
                break;
            }
            else
            {
                scripture.HideRandomWords(hideamt);
                Console.WriteLine("\n\n" + scripture.GetDisplayText());
                Console.WriteLine("\nPlease Press Enter to Continue, or type quit/q/exit to exit!");
            }
        }


    }
}