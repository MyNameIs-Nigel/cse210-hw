using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // Program Start
        Console.WriteLine("Please enter numbers, and type 0 to finish");
        string inputnum = ""; // Initialize the string that will be called in the loop
        
        // Create the numbers list
        List<int> numbers;
        numbers = new List<int>();
        

        // Program Loop (exit is 0) to add the numbers
        while (inputnum != "0")
        {
            Console.Write("Number: ");        
            inputnum = Console.ReadLine();
            numbers.Add(int.Parse(inputnum));
        }

        // Purging the 0 that we added, as it causes issues when taking the mean
        numbers.Remove(0);

        // Number functions!
        int sum = numbers.Sum();
        double mean = numbers.Average();
        int largest = numbers.Max();
        
        // Print the output
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {mean}");
        Console.WriteLine($"The largest number is: {largest}");

    }
}