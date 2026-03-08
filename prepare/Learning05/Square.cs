using System.Formats.Asn1;

public class Square : Shape
{
    private double _side;

    public Square(double side) : base("None")
    {
        _side = side;
    }
    public Square(double side, string color) : base(color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}