using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fractions f1 = new Fractions();
        Fractions f2 = new Fractions(5);
        Fractions f3 = new Fractions(3,4);
        Fractions f4 = new Fractions(1,3);

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
    }


}