using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");


     static void DisplayWelcome()
    {
        Console.WriteLine("Welcome To The Program!");

    }

    static string PromptUserName()
    {
        Console.Write("Please Enter Your Name: ");

        string name = Console.ReadLine();
        return name;
    }


    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
   {
       int squared = number * number;
       return squared;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
         Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }


     {
        DisplayWelcome();
        
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    }

    


    

}