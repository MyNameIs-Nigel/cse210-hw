using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // Obtain class (for getting the references)
        Obtain obtain = new Obtain("scriptures.txt"); // Dear TA, please either replace this with the path to scriptures.txt, or simply copy scriptures.txt INTO bin/Debug/net10.0 or whatever your compiled folder is
        Scripture scripture = new Scripture();
        
        List<string> quitList = new List<string> {"quit", "q", "exit"};

        List<Reference> references = obtain.SetReferenceFromFile();
        Console.WriteLine("\n\nPlease choose one of the following references to memorize: ");
        obtain.DisplayChoices(references);

        // Selection Loop
        string answer = "";
        while (quitList.Contains(answer) == false)
        {
            answer = Console.ReadLine();

            if (int.TryParse(answer, out int index))
            {
                if (index >= 0 && index <= references.Count())
                {                
                    scripture.SetReference(references[index - 1]);
                    break;
                }
                else
                {
                    Console.WriteLine($"Error: Please try again. {answer} is not a valid choice!");
                }
            }
            else
            {
                Console.WriteLine($"Error: Please try again. {answer} is not in the valid format!");
            }
        }
        
        Console.WriteLine($"You chose: {scripture.ReferenceText()}\n\n\nPress Enter to Start");
        Console.ReadLine();
        
        
        int hideamt = 3; // Change this to change how many words you hide at a time! Pretty neat right? (its creativity i swear!!!!)

        // Main Memorizer Loop
        answer = "";
        while (quitList.Contains(answer) == false)
        {
            if (scripture.CheckAllHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                Console.WriteLine($"\n\nThat's it! Press enter to see your results when ready.\n\n");
                Console.ReadLine();
                Console.WriteLine($"\nCongrats on memorizing {scripture.ReferenceText()}!\n\nThat was {scripture.CountWords()} words long, that's impressive!\n");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                
                Console.Write($"\n\nPress Enter to Continue, or 'quit/q/exit' to abort...\n\n");
                answer = Console.ReadLine().ToLower();
                scripture.HideRandomWords(hideamt);
            }
        }
    }
}