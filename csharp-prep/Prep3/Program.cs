using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("WELCOME TO THE GUESSING GAME! Guess a number between 1-100");
        Random magic = new Random();
        int magicnum = magic.Next(1,100);
        string guess;
        int steps = 0;
        do
        {
            Console.Write("What is your guess? ");
            guess = Console.ReadLine();
            if (int.Parse(guess) > magicnum)
            {
                Console.WriteLine("Lower");
                steps++;
            }
            else if (int.Parse(guess) < magicnum)
            {
                Console.WriteLine("Higher");
                steps++;
            }
        }
        while (int.Parse(guess) != magicnum);
        Console.WriteLine($"You guessed {magicnum} in {steps} step(s)!");
    }
}