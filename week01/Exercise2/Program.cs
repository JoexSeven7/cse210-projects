using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("Enter Your Grade Number: ");
        string gradeNumber = Console.ReadLine();

        int grade = int.Parse(gradeNumber);

        if (grade >= 90)
        {
            Console.WriteLine("Your Grade is A");
        }

        else if (grade >= 85)
        {
            Console.WriteLine("Your Grade is A-");
        }

         else if (grade >= 82)
        {
            Console.WriteLine("Your Grade is B+");
        }

        else if (grade >= 80)
        {
            Console.WriteLine("Your Grade is B");
        }

        else if (grade >= 70)
        {
            Console.WriteLine("Your Grade is C");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Your Grade is D");
        }
        else
        {
            Console.WriteLine("Your Grade is F");
        }
    }
}