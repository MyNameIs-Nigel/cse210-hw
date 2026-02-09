using System;

class Program
{
    static void Main(string[] args)
    {

        Random rand = new Random();
        Fraction frac = new Fraction();

        // Console.WriteLine($"String: {frac.GetFractionString()}, Decimal: {frac.GetFractionDecimal()}");

        for (int i = 0; i<20; i++)
        {
            
            frac.SetTop(rand.Next(1,8));
            frac.SetBottom(rand.Next(1,8));


            Console.WriteLine($"Fraction {i+1}: String: {frac.GetFractionString()}, Decimal: {frac.GetFractionDecimal()}");
        }
    }
}