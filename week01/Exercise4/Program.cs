using System;

using System.Collections.Generic;

using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int>numbers = new List<int>();

        while (true)
        {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        if (number == 0)
        break;
       
        {
            numbers.Add(number);
        }

        

        int sum = numbers.Sum();
  

        double average = (double)sum / numbers.Count;

        int maximum = numbers.Max();

        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositive = positiveNumbers.Min();
        numbers.Sort();
              
        Console.WriteLine($"The sum is: {sum}");

        Console.WriteLine($"The average is: {average}");

        Console.WriteLine($"The largest number is: {maximum}");
        
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        Console.WriteLine("The sorted list is:");
        
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
        
    
    }

}}
