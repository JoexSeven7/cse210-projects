using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("===================");
        Console.WriteLine();

        Dictionary<string, Action> activities = new Dictionary<string, Action>
        {
            { "1", () => new BreathingActivity().RunActivity() },
            { "2", () => new ReflectionActivity().RunActivity() },
            { "3", () => new ListingActivity().RunActivity() }
        };

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (activities.ContainsKey(choice))
            {
                Console.Clear();
                activities[choice].Invoke();
            }
            else if (choice == "4")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}