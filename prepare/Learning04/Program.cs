using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assignment = new MathAssignment("Nigel Smith", "uhhh", "12.3", "7-13");
        
        WritingAssignment writing = new WritingAssignment("Nigel Smith", "Writing Foundations", "Analysis Essay");
        // Math Assignment
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(assignment.GetHomeworkList());

        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}