public class Populate
{
    private string _menu = "Choose a shape\n  1. Square\n  2. Rectangle\n  3. Circle\n  4. Done";

    public List<Shape> PopulateShapes()
    {
        List<Shape> shapes = new List<Shape>();
        string option = "";
        
        while (option != "4")
        {
            Console.Clear();
            Console.WriteLine(_menu);

            option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Enter one side: ");
                    int side = int.Parse(Console.ReadLine());
                    Console.Write("Enter the color: ");
                    string color = Console.ReadLine();
                    shapes.Add(new Square(side, color));
                    break;
                case "3":
                    Console.Write("Enter one side: ");
                    int radius = int.Parse(Console.ReadLine());
                    Console.Write("Enter the color: ");
                    string color2 = Console.ReadLine();
                    shapes.Add(new Circle(radius, color2));
                    break;            
                case "2":
                    Console.Write("Enter one side: ");
                    int side1 = int.Parse(Console.ReadLine());
                    int side2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the color: ");
                    string color3 = Console.ReadLine();
                    shapes.Add(new Rectangle(side1, side2, color3));
                    break;
                case "4":
                    Console.WriteLine("Goodbye.");
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;            
            }
        }
        return shapes;
    }
}