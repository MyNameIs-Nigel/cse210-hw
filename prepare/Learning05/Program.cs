using System;

class Program
{
    static void Main(string[] args)
    {
        // Square square = new Square(5, "green");

        // Circle circle = new Circle(3);

        // Rectangle rectangle = new Rectangle(2,6,"blue");

        List<Shape> shapes = new List<Shape>
        {
            new Rectangle(2,6, "Blue"),
            new Circle(3, "Green"),
            new Square(5, "Red")
        };

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"{s.GetColor()} - {s.GetArea()} ");
        }
    }
}