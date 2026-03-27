using System.ComponentModel.DataAnnotations;

public class Student {
    private string _name;
    private int _id;
    private string _email;
    public Student(string name, int id, string email)
    {
        _name = name;
        _id = id;
        _email = email;
    }

    public void WriteName(ConsoleColor color)
    {
        ConsoleColor current = Console.ForegroundColor;

        Console.ForegroundColor = color;

        Console.Write(_name);

        Console.ForegroundColor = current;
    }
}