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

        WritingAssignment assignment3 = new WritingAssignment ("Mike", "drop","move");
        assignment3.SetTitle("The lonely road");

        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine(assignment3. GetWritingInformation());

        
    }
}