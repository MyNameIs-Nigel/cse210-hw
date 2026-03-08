using System.Runtime.CompilerServices;
public class Reflecting : Activity
{
    // Make the random class thing then declar a list of prompts & follow-up questions
    DateTime startTime;
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Declaring private variables
    private int _questionDuration;
    private int _totalDuration;
    private bool _outOfQuestions;

    // Constructors: 
    public Reflecting() : base("Reflecting", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _questionDuration = 5;
    }
    public Reflecting(int questionDuration) : base("Reflecting", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _questionDuration = questionDuration;
    }

    private void AskQuestions()
    {
        if (_questions.Count() > 0)
        {
            int index = _rand.Next(_questions.Count());

            Console.Write($"> {_questions[index]} ");
            _questions.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Out of Questions! That's it.");
            _outOfQuestions = true;
        }
        LoadingAnimation(6);
        Console.WriteLine();
    }
    public void DisplayActivity()
    {
        // Get the duration from the user
        _totalDuration = IntroText();
        // After intro
        GetReady();

        RandomPrompt(_prompts);
        Console.WriteLine("\nNow Ponder on each of the Following qwuestions as they related to this experience.");

        Console.Write("You will begin in: ");
        Countdown(5);
        Console.Clear();
        startTime = DateTime.Now;
        DateTime finishTime = startTime.AddSeconds(_totalDuration);
        while (_outOfQuestions == false)
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime < finishTime) AskQuestions();
            else break;
        }
        Console.Write("\n\nWell done!\n\n");

        FinishText(_totalDuration);
    }
}