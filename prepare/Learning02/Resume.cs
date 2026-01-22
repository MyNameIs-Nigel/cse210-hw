using System;
public class Resume
{
    public string _name;
    public List<string> _jobs = new List<string>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");
        for (int i = 0; i < _jobs.Count(); i++) Console.WriteLine(_jobs[i]);        
    }
}