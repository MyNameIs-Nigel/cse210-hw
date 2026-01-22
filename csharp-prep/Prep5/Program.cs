using System;

class Program
{
    static void DisplayWelcome() // Displays the welcome message 
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();

    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string number = Console.ReadLine();
        return int.Parse(number);
    }

    static int PromptUserBirthYear()
    {
        Console.Write("Please enter the year you were born: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
        int squared = number * number;
        return squared;
    }

    static void DisplayResult()
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favnum = PromptUserNumber();
        int birthyear = PromptUserBirthYear();
        int age = 2026 - birthyear;

        Console.WriteLine($"{name}, the square of your number is {SquareNumber(favnum)}");
        Console.WriteLine($"{name}, you will turn {age} this year.");    
    }
    static void Main(string[] args)
    {
        DisplayResult();
    }
}