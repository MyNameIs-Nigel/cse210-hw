public class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    
    private int _countdownTime;
    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _countdownTime = 5;
    }
    public Listing(int countdownTimer) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _countdownTime = countdownTimer;
    }


    private List<string> UserInputs(int seconds)
    {
        List<string> userInputs = new List<string>();

        DateTime startTime = DateTime.Now;

        DateTime futureTime = startTime.AddSeconds(seconds);

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            userInputs.Add(response);
            currentTime = DateTime.Now;
        }


        return userInputs;
    }

    public void DisplayActivity()
    {
        int duration = IntroText();

        GetReady();

        RandomPrompt(_prompts);
        Console.WriteLine();
        Console.WriteLine("Now get ready to type out your responses! Press enter to add a new entry\n");

        Console.Write("Get Ready... ");
        Countdown(8);

        Console.Clear();

        List<string> inputs = UserInputs(duration);

        Console.WriteLine($"\n\nWell done, you listed {inputs.Count()} entries!");

        FinishText(duration);
    }
}