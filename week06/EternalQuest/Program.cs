using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalScore = 0;
        int level = 1;
        int xpToNextLevel = 100;
        string filename = "";
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\n--- Eternal Quest ---");
            Console.WriteLine($"Score: {totalScore} | Level: {level} | XP: {totalScore % xpToNextLevel}/{xpToNextLevel}");
            if (string.IsNullOrEmpty(filename))
                Console.WriteLine("No file loaded");
            else
                Console.WriteLine($"File: {filename}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Load Progress");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nGoal Types:");
                Console.WriteLine("1. Simple Goal (one-time completion)");
                Console.WriteLine("2. Eternal Goal (repeats forever)");
                Console.WriteLine("3. Checklist Goal (complete X times for bonus)");
                Console.WriteLine("4. Negative Goal (lose points for bad habits)");
                Console.Write("Choose type: ");
                string type = Console.ReadLine();
                
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Description: ");
                string description = Console.ReadLine();
                Console.Write("Points: ");
                int points = int.Parse(Console.ReadLine());
                
                if (type == "1")
                {
                    goals.Add(new SimpleGoal(name, description, points));
                }
                else if (type == "2")
                {
                    goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "3")
                {
                    Console.Write("Target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                }
                else if (type == "4")
                {
                    goals.Add(new NegativeGoal(name, description, points));
                }
                Console.WriteLine("Goal created!");
            }
            else if (choice == "2")
            {
                if (goals.Count == 0)
                {
                    Console.WriteLine("No goals to record.");
                }
                else
                {
                    Console.WriteLine("\n--- Goals ---");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
                    }
                    Console.Write("Enter goal number to record: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    
                    if (index >= 0 && index < goals.Count)
                    {
                        int points = goals[index].RecordEvent();
                        totalScore += points;
                        if (points > 0)
                            Console.WriteLine($"+{points} points!");
                        else if (points < 0)
                            Console.WriteLine($"{points} points (negative goal)");
                        else
                            Console.WriteLine("No points earned.");
                    }
                }
                
                if (totalScore >= level * xpToNextLevel)
                {
                    level++;
                    Console.WriteLine($"\n*** LEVEL UP! You are now level {level}! ***\n");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("\n--- Goals ---");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
                }
                if (goals.Count == 0)
                    Console.WriteLine("No goals yet.");
            }
            else if (choice == "4")
            {
                if (string.IsNullOrEmpty(filename))
                {
                    Console.Write("Enter filename to save: ");
                    filename = Console.ReadLine();
                }
                
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine($"SCORE:{totalScore}");
                    outputFile.WriteLine($"LEVEL:{level}");
                    outputFile.WriteLine($"XP:{xpToNextLevel}");
                    foreach (Goal goal in goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine($"Progress saved to {filename}!");
            }
            else if (choice == "5")
            {
                Console.Write("Enter filename to load: ");
                string inputFile = Console.ReadLine();
                
                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("File not found.");
                }
                else
                {
                    string[] lines = File.ReadAllLines(inputFile);
                    goals.Clear();
                    
                    totalScore = 0;
                    level = 1;
                    xpToNextLevel = 100;
                    filename = inputFile;
                    
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(":");
                        if (parts.Length < 2) continue;
                        
                        string type = parts[0];
                        string data = parts[1];
                        
                        if (type == "SCORE")
                        {
                            totalScore = int.Parse(data);
                        }
                        else if (type == "LEVEL")
                        {
                            level = int.Parse(data);
                        }
                        else if (type == "XP")
                        {
                            xpToNextLevel = int.Parse(data);
                        }
                        else
                        {
                            string[] goalParts = data.Split(",");
                            
                            if (type == "SimpleGoal")
                            {
                                if (goalParts.Length >= 4)
                                    goals.Add(new SimpleGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2])));
                            }
                            else if (type == "EternalGoal")
                            {
                                if (goalParts.Length >= 3)
                                    goals.Add(new EternalGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2])));
                            }
                            else if (type == "ChecklistGoal")
                            {
                                if (goalParts.Length >= 7)
                                {
                                    ChecklistGoal goal = new ChecklistGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2]), int.Parse(goalParts[3]), int.Parse(goalParts[4]));
                                    goals.Add(goal);
                                }
                            }
                            else if (type == "NegativeGoal")
                            {
                                if (goalParts.Length >= 4)
                                    goals.Add(new NegativeGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2])));
                            }
                        }
                    }
                    Console.WriteLine($"Progress loaded from {inputFile}!");
                }
            }
            else if (choice == "6")
            {
                running = false;
            }
        }
    }
}

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
1. NegativeGoal class - Added a goal type for tracking bad habits that subtract points
2. Level-up system - Added leveling mechanic where user levels up every 100 points
3. XP display - Shows current XP progress toward next level
4. Enhanced checklist display - Shows "Done X times" for negative goals
5. Interactive menu system with all required functionality
6. Full save/load capability using string representation pattern
*/