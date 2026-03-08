public class Base
{
    protected DateTime startTime;
    protected DateTime futureTime;
    private int _duration;

    private bool _errorInt;

    protected void GetReady()
    {
        Console.Clear();

        // handle int error 
        if (_errorInt)
        {
            Console.WriteLine("Invalid duration input, defaulting to 30 seconds!");
        }

        Console.WriteLine("Get ready...");
        LoadingAnimation(3);
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
    protected int IntroText(string activity, string intro)
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {activity} Activity!");
        Console.WriteLine($"\n{intro}\n");

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
}