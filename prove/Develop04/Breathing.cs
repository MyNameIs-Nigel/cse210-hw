using System.ComponentModel.DataAnnotations; // idk where that came from, i didn't put it there :P

public class Breathing : Activity
{
    private int _duration;
    private int _inDuration;
    private int _outDuration;

    public Breathing() : base("Breathing",  "This activity will help you manage your breathing so that you can calm down and relax.")
    {
        // Default Breathing Durations
        _inDuration = 3;
        _outDuration = 4;
    }
    public Breathing(int breatheInTime, int breatheOutTime) : base("Breathing",  "This activity will help you manage your breathing so that you can calm down and relax.")
    {
        _inDuration = breatheInTime;
        _outDuration = breatheOutTime;
    }

    private void Breathe(bool breatheIn, int duration)
    {
        // Write Breath IN or OUT
        if (breatheIn) Console.Write("Breathe in...");
        else Console.Write("Breathe out...");


        Countdown(duration);

        Console.WriteLine();
    }

    public void DisplayActivity()
    {
        // Initial Text & get the user input
        _duration = IntroText();
        // After intro
        GetReady();

        // Find out how many times we will breathe in and out. Then, find out..
        //  ..the remainder so that we can always hit full duration
        int cycleCount = _duration / (_inDuration + _outDuration);
        int durMod = _duration % (_inDuration + _outDuration);

        for (int i = 0; i < cycleCount; i++)
        {
            Breathe(true, _inDuration);
            Breathe(false, _outDuration);
        }
        // Relax with optional timer that goes off to complete the full duration
        Console.Write("Now relax...");
        for (int i = durMod; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
        LoadingAnimation(2);
        FinishText(_duration);
    }

}