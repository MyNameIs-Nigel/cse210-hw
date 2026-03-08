public class Circle : Shape
{
    private double _radius;

    public Circle(double radius) : base("None")
    {
        _radius = radius;
    }
    public Circle(double radius, string color) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return _radius * _radius * 3.1415926;
    }
}