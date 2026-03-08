using System.ComponentModel.DataAnnotations;

public class Breathing : Base
{
    private int _duration;
    private int _inDuration;
    private int _outDuration;

    private string _introText = "This activity will help you manage your breathing so that you can calm down and relax.";

    public Breathing()
    {
        _inDuration = 3;
        _outDuration = 4;
    }
    public Breathing(int breatheInTime, int breatheOutTime)
    {
        _inDuration = breatheInTime;
        _outDuration = breatheOutTime;
    }

    private void Breathe(bool breatheIn, int duration)
    {
        // Write Breath IN or OUT
        if (breatheIn) Console.Write("Breathe in...");
        else Console.Write("Breathe out...");


        for (int i = duration; i > 0; i--)
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

        Console.WriteLine();
    }

    public void DisplayActivity()
    {
        // Initial Text & get the user input
        _duration = IntroText("Breathing", _introText);
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
        Console.WriteLine($"\nYou have completed {_duration} seconds of the Breathing activity!");
        LoadingAnimation(4);
        Console.Clear();
    }

}