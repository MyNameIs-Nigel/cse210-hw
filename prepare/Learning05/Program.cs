using System;

class Program
{
    static void Main(string[] args)
    {
        // Square square = new Square(5, "green");

        // Circle circle = new Circle(3);

        // Rectangle rectangle = new Rectangle(2,6,"blue");

        Populate pop = new Populate();

        List<Shape> shapes = pop.PopulateShapes(); 

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"{s.GetColor()} - {s.GetArea()} ");
        }
    }
}