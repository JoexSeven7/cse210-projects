using System;

class Program
{
    static void Main(string[] args)
    {
       Journal journal = new Journal();
        promptGenerator promptGenerator = new promptGenerator();

        // Menu loop
        string choice = "";
        
        while (choice != "5")
        {
           Console.WriteLine("\nWelcome to the Journal Program");
           Console.WriteLine("\nPlease Select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
             Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

              choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": 
                string prompt = promptGenerator.GetRandomPrompt();
                 Console.WriteLine($"\n{prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry entry = new Entry(date, prompt, response);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry saved!");
                    break;

                     case "2":   
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                    
                case "4": 
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                    
                    
                case "5": 
                    Console.WriteLine("Goodbye!");
                    break;
                    
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
                }
        }
    }
}