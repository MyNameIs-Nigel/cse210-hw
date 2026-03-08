public class Activity
{
    // Private Variables
    private int _duration;

    private bool _errorInt;

    // Inheritable Variables
    protected string _introText;
    protected string _activityName;

    protected Random _rand = new Random();

    public Activity(string activityName, string introText)
    {
        _introText = introText;
        _activityName = activityName;
    }

    protected void GetReady()
    {
        Console.Clear();

        // handle int error 
        if (_errorInt)
        {
            Console.WriteLine("Invalid duration input, defaulting to 30 seconds!");
        }

        Console.WriteLine("Get ready...");
        LoadingAnimation(2);
        Console.WriteLine("\n");
    }
    protected void LoadingAnimation(int iterations)
    {
        List<string> characters = new List<string> {"-","\\","|", "/"};
        
        for (int i = 0; i < iterations; i++)
        {
            foreach (string character in characters)
            {
                Console.Write(character);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }

    protected void RandomPrompt(List<string> prompts)
    {
        
        Console.WriteLine("Consider the following prompt:");

        int index = _rand.Next(prompts.Count());
        Console.WriteLine($"--- {prompts[index]} ---");

        Console.Write("\n\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // Write the second timer then wait a second
            Console.Write(i);
            Thread.Sleep(1000);

            // Go back by character count (to handle anythign larger than 9)
            int charLength = i.ToString().Count();
            for (int j = 0; j < charLength; j++)
            {
                Console.Write("\b \b");
            }
        }
        
    }
    protected int IntroText()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_activityName} Activity!");
        Console.WriteLine($"\n{_introText}\n");

        // Get user input on length of that activity
        Console.Write("How many seconds would you like for your session to last? ");
        string durationInput = Console.ReadLine();

        // Check to see if that input is an int
        if (int.TryParse(durationInput, out _duration))
        {
            _errorInt = false;
            return _duration;
        }
        else
        {
            _errorInt = true;
            return 30;
        }
    }

    protected void FinishText(int duration)
    {
        Console.WriteLine($"\nYou have completed {duration} seconds of the {_activityName} activity!");
        LoadingAnimation(4);        
        Console.Clear();
    }
}