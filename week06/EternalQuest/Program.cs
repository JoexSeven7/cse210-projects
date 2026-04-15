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
                CreateGoal(goals);
            }
            else if (choice == "2")
            {
                RecordEvent(goals, ref totalScore);
                CheckLevelUp(ref totalScore, ref level, ref xpToNextLevel);
            }
            else if (choice == "3")
            {
                ListGoals(goals);
            }
            else if (choice == "4")
            {
                SaveGoals(goals, ref totalScore, ref level, ref xpToNextLevel, ref filename);
            }
            else if (choice == "5")
            {
                LoadGoals(goals, ref totalScore, ref level, ref xpToNextLevel, ref filename);
            }
            else if (choice == "6")
            {
                running = false;
            }
        }
    }
    
    static void CreateGoal(List<Goal> goals)
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
    
    static void RecordEvent(List<Goal> goals, ref int totalScore)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }
        
        ListGoals(goals);
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
    
    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("\n--- Goals ---");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
        if (goals.Count == 0)
            Console.WriteLine("No goals yet.");
    }
    
    static void CheckLevelUp(ref int totalScore, ref int level, ref int xpToNextLevel)
    {
        if (totalScore >= level * xpToNextLevel)
        {
            level++;
            Console.WriteLine($"\n*** LEVEL UP! You are now level {level}! ***\n");
        }
    }
    
    static void SaveGoals(List<Goal> goals, ref int score, ref int level, ref int xpToNextLevel, ref string filename)
    {
        if (string.IsNullOrEmpty(filename))
        {
            Console.Write("Enter filename to save: ");
            filename = Console.ReadLine();
        }
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"SCORE:{score}");
            outputFile.WriteLine($"LEVEL:{level}");
            outputFile.WriteLine($"XP:{xpToNextLevel}");
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Progress saved to {filename}!");
    }
    
    static void LoadGoals(List<Goal> goals, ref int score, ref int level, ref int xpToNextLevel, ref string filename)
    {
        Console.Write("Enter filename to load: ");
        string inputFile = Console.ReadLine();
        
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("File not found.");
            return;
        }
        
        string[] lines = File.ReadAllLines(inputFile);
        goals.Clear();
        
        score = 0;
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
                score = int.Parse(data);
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
                Goal goal = CreateGoalFromString(type, data);
                if (goal != null)
                    goals.Add(goal);
            }
        }
        Console.WriteLine($"Progress loaded from {inputFile}!");
    }
    
    static Goal CreateGoalFromString(string type, string data)
    {
        string[] parts = data.Split(",");
        
        if (type == "SimpleGoal")
        {
            if (parts.Length >= 4)
                return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
        }
        else if (type == "EternalGoal")
        {
            if (parts.Length >= 3)
                return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
        }
        else if (type == "ChecklistGoal")
        {
            if (parts.Length >= 7)
            {
                var goal = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
                return goal;
            }
        }
        else if (type == "NegativeGoal")
        {
            if (parts.Length >= 4)
                return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
        }
        return null;
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