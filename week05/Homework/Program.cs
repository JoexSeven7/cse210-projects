using System;

class Program
{
    static void Main(string[] args)
    {
       


        Assignment assignment1 = new Assignment("Mike", "drop");
        assignment1.SetSudentName("John");
        assignment1.SetTopic("Math-Equation");

        MathAssignment assignment2 = new MathAssignment("Mike", "drop","move","holf");
        assignment2.SetTextBook("Quntitative");
        assignment2.SetProblem("2.3");

        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        
    }
}