using System;

class Program
{
    static void Main(string[] args)
    {
        int A = 90;
        int B = 80;
        int C = 70;
        int D = 60;

        Console.Write("To receive your letter grade, type your final class grade percent: ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);
        
        string letter = "";

        // Determine Letter Grade
        if (grade >= A)
        {
            letter = "A";
        }
        else if (grade >= B && grade < A) {
            letter = "B";
        }
        else if (grade >= C && grade < B) {
            letter = "C";
        }
        else if (grade >= D && grade < C) {
            letter = "D";
        }
        else if (grade < D)
        {
            letter = "F";
        }

        // Determine +/-/null
        int modGrade = grade % 10;
        string modString;
        if (modGrade >= 7 && grade >= D && grade < 97) 
        {
            modString = "+";
        }
        else if (( modGrade < 3 && grade > D ) || grade == D)
        {
            modString = "-";
        }
        else
        {
            modString = "";
        }

        // Output

        Console.WriteLine($"Your grade {gradeInput} is a {letter}{modString}");

        // PASS or FAIL
        if (grade < 70)
        {
            Console.WriteLine("Unfortunately, you did not meet the required 70 to pass the class. You FAILED.");
        }
        else
        {
            Console.WriteLine("Congrats, You PASSED! The minimum required grade to pass was a 70.");
        }
    }
}